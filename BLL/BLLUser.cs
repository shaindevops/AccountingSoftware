using BE;
using BLL.Security;
using DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLUser
    {
        DALUsers dal = new DALUsers();

        /// <summary>
        /// Registers a brand-new user. The plaintext password supplied on
        /// U.password is hashed (PBKDF2) before it reaches the DAL/database.
        /// </summary>
        public string Create(Users U, Usergroup UG)
        {
            U.password = PasswordHasher.HashNew(U.password);
            return dal.Create(U, UG);
        }
        public bool IsRegistered()
        {
            return dal.IsRegistered();
        }
        public bool Read(Users U)
        {
            return dal.Read(U);
        }
        public DataTable Read()
        {
            return dal.Read();
        }
        public DataTable Read(string u, int index)
        {
            return dal.Read(u, index);
        }
        public Users Read(int id)
        {
            return dal.Read(id);
        }
        public Users ReadU(string s)
        {
            return dal.ReadU(s);
        }
        public List<string> ReadUserName()
        {
            return dal.ReadUserName();
        }
        /// <summary>
        /// Updates a user's profile. If U.password is null/empty, the
        /// existing password is left untouched (used by the "edit user"
        /// screen, which no longer pre-fills/displays the password -
        /// PBKDF2 hashes cannot be decoded back to plaintext, unlike the
        /// old Base64 scheme). If a new password is supplied, it is hashed
        /// with PBKDF2 before being persisted.
        /// </summary>
        public string Update(int id, Users U)
        {
            U.password = string.IsNullOrEmpty(U.password) ? null : PasswordHasher.HashNew(U.password);
            return dal.Update(id, U);
        }
        public string Delete(int id)
        {
            return dal.Delete(id);
        }
        public List<Users> ActivityRegistered()
        {
            return dal.ActivityRegistered();
        }
        /// <summary>
        /// Verifies credentials and returns the matching user, or null if
        /// the username/password combination is invalid.
        ///
        /// Backward-compatible password migration: verification accepts
        /// both the new PBKDF2 format and legacy Base64 passwords. On a
        /// successful login with a legacy password, the password is
        /// transparently re-hashed with PBKDF2 and persisted, so the
        /// migration happens gradually as users log in - no bulk migration
        /// or forced password reset is required.
        /// </summary>
        public Users Login(string username, string Pass)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(Pass))
            {
                return null;
            }

            Users user = dal.GetByUsernameWithGroup(username);
            if (user == null || !PasswordHasher.Verify(Pass, user.password))
            {
                return null;
            }

            if (PasswordHasher.IsLegacyFormat(user.password))
            {
                string upgradedHash = PasswordHasher.HashNew(Pass);
                dal.UpdatePasswordHash(user.id, upgradedHash);
                user.password = upgradedHash;
            }

            return user;
        }

        /// <summary>
        /// Verifies a plaintext password against a stored hash (either
        /// format). Used e.g. by "confirm current password" screens, which
        /// previously relied on reversing a Base64 "encoded" password -
        /// that reversal is no longer possible (or safe) once a password is
        /// PBKDF2-hashed, so callers must verify instead of decode.
        /// </summary>
        public bool VerifyPassword(string plainPassword, string storedPassword)
        {
            return PasswordHasher.Verify(plainPassword, storedPassword);
        }
        public bool AccessTo(Users U, string S, int A)
        {
            return dal.AccessTo(U, S, A);
        }
        public string Usercount()
        {
            return dal.Usercount();
        }
        public string ReadUsername()
        {
            return dal.ReadUsername();
        }
        public string Readname()
        {
            return dal.Readname();
        }

        public string UpdateIsActive(int LoggedUserId)
        {
            return dal.UpdateIsActive(LoggedUserId);
        }
    }
}
