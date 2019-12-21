using MySql.Data.MySqlClient;
using NLog;
using System;
using System.Data;

namespace LambentLight.Managers.Database
{
    /// <summary>
    /// A manager for the MySQL Database.
    /// </summary>
    public static class DatabaseManager
    {
        #region Private Fields

        /// <summary>
        /// The logger for our current class.
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        #endregion

        #region Public Properties

        /// <summary>
        /// The MySQL connection.
        /// </summary>
        public static MySqlConnection Connection { get; private set; } = null;

        #endregion

        #region Public Functions

        /// <summary>
        /// Connects to the MySQL Database specified in the Configuration.
        /// </summary>
        public static bool Connect()
        {
            // If the user has not provided a MySQL Connection URL, notify him and return
            if (string.IsNullOrWhiteSpace(Program.Config.MySQL.Connection))
            {
                Logger.Warn("MySQL database is disabled because setting is empty");
                return false;
            }

            // Disconnect the existing connection if is present
            Disconnect();

            // Now, is time to connect to the database
            try
            {
                // Create the new MySQL Connection object
                Connection = new MySqlConnection(Program.Config.MySQL.Connection);
                // And open the connection
                Connection.Open();
                // Notify the user
                Logger.Info("Connection established to MySQL Database!");
                // And return success
                return true;
            }
            // If we got an exception
            catch (Exception ex)
            {
                // Set connection to null
                Connection = null;
                // Notify the user
                Logger.Error("Error while connecting to MySQL DB: {0}", ex.Message);
                // And return failure
                return false;
            }
        }
        /// <summary>
        /// Disconnects the MySQL Connection if is active.
        /// </summary>
        public static void Disconnect()
        {
            // If no connection exists or is closed, return
            if (Connection == null || Connection.State == ConnectionState.Closed)
            {
                return;
            }

            // Close the connection
            Connection.Close();
            Logger.Info("The connection to the existing MySQL Database was closed");
        }

        #endregion
    }
}
