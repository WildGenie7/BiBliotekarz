using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace BiBliotekarz.Class
{
    public static class DatabaseManager
    {
        public static readonly string ConnectionString = ConfigurationManager
            .ConnectionStrings["LibraryDB"]
            .ConnectionString;

        public static int ExecuteNonQuery(string query)
        {
            try
            {
                using (var connection = new SqlConnection(ConnectionString))
                {
                    var command = new SqlCommand(query, connection);
                    connection.Open();
                    return command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Błąd SQL: {ex.Message}");
                return -1; // Kod błędu
            }
        }

        // Wykonanie zapytania zwracającego wyniki (SELECT)
        public static DataTable ExecuteQuery(string query)
        {
            try
            {
                using (var connection = new SqlConnection(ConnectionString))
                {
                    var command = new SqlCommand(query, connection);
                    var dataTable = new DataTable();
                    var adapter = new SqlDataAdapter(command);
                    connection.Open();
                    adapter.Fill(dataTable);
                    return dataTable;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Błąd SQL: {ex.Message}");
                return null; // Zwrócenie null w przypadku błędu
            }
        }
        public static bool TestConnection()
        {
            try
            {
                using (var connection = new SqlConnection(ConnectionString))
                {
                    connection.Open(); // Próba otwarcia połączenia
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd połączenia z bazą danych: {ex.Message}");
                return false;
            }
        }


    }
}
