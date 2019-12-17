using MySql.Data.MySqlClient;
using NLog;
using System;

namespace LambentLight.Managers
{
    /// <summary>
    /// A manager for the MySQL Database.
    /// </summary>
    public static class DatabaseManager
    {
        /// <summary>
        /// The logger for our current class.
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        /// <summary>
        /// The MySQL connection.
        /// </summary>
        public static MySqlConnection Connection { get; private set; } = null;

        /// <summary>
        /// Tries to connect into the database from the configuration.
        /// </summary>
        public static bool Connect()
        {
            // If the connection is empty, notify the user and return
            if (string.IsNullOrWhiteSpace(Program.Config.MySQL.Connection))
            {
                Logger.Warn("MySQL database is disabled because setting is empty");
                return false;
            }

            // If there is a database running, stop it
            if (Connection != null)
            {
                Connection.Close();
                Logger.Info("The connection to the existing MySQL Database was closed");
            }

            // Try to connect to the MySQL database
            try
            {
                Connection = new MySqlConnection(Program.Config.MySQL.Connection);
                Connection.Open();
                Logger.Info("Connected to MySQL Database!");
                return true;
            }
            // If we got an exception
            catch (Exception ex)
            {
                Connection = null;
                Logger.Error("Error while connecting to MySQL DB: {0}", ex.Message);
                return false;
            }
        }
    }
}
