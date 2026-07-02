using System;
using System.Security.Cryptography;
using System.Text;

namespace BLL.Security
{
    /// <summary>
    /// Handles password hashing/verification for the Users module.
    ///
    /// Historically passwords were stored as plain Base64 (functionally
    /// equivalent to plaintext - trivially reversible, not a real hash).
    /// This class introduces salted PBKDF2 hashing while remaining able to
    /// verify against the old Base64 values, so existing users are not
    /// locked out. New/changed passwords are always stored in the new
    /// format. Legacy passwords are upgraded to the new format the next
    /// time the user logs in successfully (see BLLUser.Login).
    ///
    /// Storage format (all in the existing single "password" nvarchar column,
    /// no schema change required):
    ///   PBKDF2.<iterations>.<saltBase64>.<hashBase64>
    ///
    /// Any stored value that does NOT start with "PBKDF2." is treated as a
    /// legacy Base64 password.
    /// </summary>
    public static class PasswordHasher
    {
        private const string Prefix = "PBKDF2";
        private const char Separator = '.';
        private const int DefaultIterations = 100_000;
        private const int SaltSizeBytes = 16;
        private const int HashSizeBytes = 32;

        /// <summary>
        /// Hashes a plaintext password into the new PBKDF2 storage format.
        /// Use for new users and whenever a user sets/changes their password.
        /// </summary>
        public static string HashNew(string plainPassword)
        {
            if (plainPassword == null)
            {
                throw new ArgumentNullException(nameof(plainPassword));
            }

            byte[] salt = new byte[SaltSizeBytes];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            byte[] hash = ComputeHash(plainPassword, salt, DefaultIterations);

            return string.Join(
                Separator.ToString(),
                Prefix,
                DefaultIterations.ToString(),
                Convert.ToBase64String(salt),
                Convert.ToBase64String(hash));
        }

        /// <summary>
        /// True if the stored value is an old Base64-only password that has
        /// not yet been migrated to PBKDF2.
        /// </summary>
        public static bool IsLegacyFormat(string storedPassword)
        {
            return string.IsNullOrEmpty(storedPassword) || !storedPassword.StartsWith(Prefix + Separator);
        }

        /// <summary>
        /// Verifies a plaintext password against whatever format is stored
        /// (new PBKDF2 or legacy Base64), without needing to know in advance
        /// which one it is.
        /// </summary>
        public static bool Verify(string plainPassword, string storedPassword)
        {
            if (plainPassword == null || string.IsNullOrEmpty(storedPassword))
            {
                return false;
            }

            return IsLegacyFormat(storedPassword)
                ? VerifyLegacyBase64(plainPassword, storedPassword)
                : VerifyPbkdf2(plainPassword, storedPassword);
        }

        private static bool VerifyLegacyBase64(string plainPassword, string storedBase64)
        {
            try
            {
                string candidate = Convert.ToBase64String(Encoding.UTF8.GetBytes(plainPassword));
                return FixedTimeEquals(candidate, storedBase64);
            }
            catch (FormatException)
            {
                // Stored value isn't valid Base64 either - can't match.
                return false;
            }
        }

        private static bool VerifyPbkdf2(string plainPassword, string storedPassword)
        {
            string[] parts = storedPassword.Split(Separator);
            if (parts.Length != 4 || parts[0] != Prefix)
            {
                return false;
            }

            if (!int.TryParse(parts[1], out int iterations))
            {
                return false;
            }

            byte[] salt;
            byte[] expectedHash;
            try
            {
                salt = Convert.FromBase64String(parts[2]);
                expectedHash = Convert.FromBase64String(parts[3]);
            }
            catch (FormatException)
            {
                return false;
            }

            byte[] actualHash = ComputeHash(plainPassword, salt, iterations);
            return FixedTimeEquals(actualHash, expectedHash);
        }

        private static byte[] ComputeHash(string plainPassword, byte[] salt, int iterations)
        {
            using (var pbkdf2 = new Rfc2898DeriveBytes(plainPassword, salt, iterations, HashAlgorithmName.SHA256))
            {
                return pbkdf2.GetBytes(HashSizeBytes);
            }
        }

        private static bool FixedTimeEquals(string a, string b)
        {
            return FixedTimeEquals(Encoding.UTF8.GetBytes(a), Encoding.UTF8.GetBytes(b));
        }

        private static bool FixedTimeEquals(byte[] a, byte[] b)
        {
            if (a.Length != b.Length)
            {
                return false;
            }

            int diff = 0;
            for (int i = 0; i < a.Length; i++)
            {
                diff |= a[i] ^ b[i];
            }

            return diff == 0;
        }
    }
}
