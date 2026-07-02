using System;
using System.Configuration;

namespace DAL
{
    /// <summary>
    /// Single source of truth for the database connection string used by
    /// raw ADO.NET code in the DAL layer (SqlConnection/SqlCommand/SqlDataAdapter).
    /// EF6 access via <see cref="DB"/> already reads the same "SSG" entry
    /// from App.config by name; this class exists so ad-hoc ADO.NET code
    /// stops hardcoding the connection string in dozens of places.
    /// </summary>
    public static class ConnectionHelper
    {
        private const string ConnectionStringName = "SSG";

        private static readonly Lazy<string> ConnectionStringLazy = new Lazy<string>(Load);

        public static string ConnectionString => ConnectionStringLazy.Value;

        private static string Load()
        {
            var entry = ConfigurationManager.ConnectionStrings[ConnectionStringName];
            if (entry == null || string.IsNullOrWhiteSpace(entry.ConnectionString))
            {
                throw new InvalidOperationException(
                    $"Connection string '{ConnectionStringName}' was not found in the application configuration file. " +
                    "Check that <connectionStrings> in App.config contains an entry named \"SSG\".");
            }

            return entry.ConnectionString;
        }
    }
}
