using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using BiBliotekarz.TransactionOverwiew;
using OfficeOpenXml;

namespace BiBliotekarz.Class
{
    public static class LibraryManager
    {
        public static void AddClient(Client client)
        {
            string query = @"
                INSERT INTO Clients (Name, Surname, PESEL, TelephoneNumber, HomeAddress)
                VALUES (@Name, @Surname, @PESEL, @TelephoneNumber, @HomeAddress);";

            ExecuteNonQuery(query, cmd =>
            {
                cmd.Parameters.AddWithValue("@Name", client.Name);
                cmd.Parameters.AddWithValue("@Surname", client.Surname);
                cmd.Parameters.AddWithValue("@PESEL", client.PESEL);
                cmd.Parameters.AddWithValue("@TelephoneNumber", client.TelephoneNumber);
                cmd.Parameters.AddWithValue("@HomeAddress", client.HomeAddress);
            });
        }

        public static List<Client> GetClients()
        {
            string query = "SELECT * FROM Clients";

            return ExecuteQuery(query, reader =>
                new Client(
                    reader["Name"].ToString(),
                    reader["Surname"].ToString(),
                    reader["PESEL"].ToString(),
                    reader["TelephoneNumber"].ToString(),
                    reader["HomeAddress"].ToString()
                )
                {
                    ClientID = int.Parse(reader["ClientID"].ToString())
                });
        }
        public static void UpdateClient(Client client)
        {
            string query = @"
                UPDATE Clients
                SET Name = @Name,
                    Surname = @Surname,
                    PESEL = @PESEL,
                    TelephoneNumber = @TelephoneNumber,
                    HomeAddress = @HomeAddress
                WHERE ClientID = @ClientID;";

            ExecuteNonQuery(query, cmd =>
            {
                cmd.Parameters.AddWithValue("@ClientID", client.ClientID);
                cmd.Parameters.AddWithValue("@Name", client.Name);
                cmd.Parameters.AddWithValue("@Surname", client.Surname);
                cmd.Parameters.AddWithValue("@PESEL", client.PESEL);
                cmd.Parameters.AddWithValue("@TelephoneNumber", client.TelephoneNumber);
                cmd.Parameters.AddWithValue("@HomeAddress", client.HomeAddress);
            });
        }
        public static void AddBook(Book book)
        {
            string query = @"
        INSERT INTO Books (BookName, Author, ReleaseDate, BookID, NumberOfBooks, AvailableBooks)
        VALUES (@BookName, @Author, @ReleaseDate, @BookID, @NumberOfBooks, @AvailableBooks);
    ";

            using (var connection = new SqlConnection(DatabaseManager.ConnectionString))
            {
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@BookName", book.BookName);
                    command.Parameters.AddWithValue("@Author", book.Author);
                    command.Parameters.AddWithValue("@ReleaseDate", book.ReleaseDate);
                    command.Parameters.AddWithValue("@BookID", book.BookID);
                    command.Parameters.AddWithValue("@NumberOfBooks", book.NumberOfBooks);
                    command.Parameters.AddWithValue("@AvailableBooks", book.AvailableBooks);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        public static List<Book> GetBooks()
        {
            string query = "SELECT * FROM Books";

            return ExecuteQuery(query, reader =>
                new Book(
                    reader["BookName"].ToString(),
                    reader["Author"].ToString(),
                    DateTime.Parse(reader["ReleaseDate"].ToString()),
                    long.Parse(reader["BookID"].ToString()),
                    int.Parse(reader["NumberOfBooks"].ToString()),
                    int.Parse(reader["AvailableBooks"].ToString()) 
                ));
        }

        public static void UpdateBook(Book book)
        {
            string query = @"
        UPDATE Books
        SET BookName = @BookName,
            Author = @Author,
            ReleaseDate = @ReleaseDate,
            NumberOfBooks = @NumberOfBooks,
            AvailableBooks = @AvailableBooks
        WHERE BookID = @BookID;
    ";

            using (var connection = new SqlConnection(DatabaseManager.ConnectionString))
            {
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@BookName", book.BookName);
                    command.Parameters.AddWithValue("@Author", book.Author);
                    command.Parameters.AddWithValue("@ReleaseDate", book.ReleaseDate);
                    command.Parameters.AddWithValue("@NumberOfBooks", book.NumberOfBooks);
                    command.Parameters.AddWithValue("@AvailableBooks", book.AvailableBooks); 
                    command.Parameters.AddWithValue("@BookID", book.BookID);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }


        public static void DeleteClient(int clientId)
        {
            string query = "DELETE FROM Clients WHERE ClientID = @ClientID";

            ExecuteNonQuery(query, cmd =>
            {
                cmd.Parameters.AddWithValue("@ClientID", clientId);
            });
        }
        public static void DeleteBook(long bookID)
        {
            string query = "DELETE FROM Books WHERE BookID = @BookID";

            ExecuteNonQuery(query, cmd =>
            {
                cmd.Parameters.AddWithValue("@BookID", bookID);
            });
        }
        public static void AddTransaction(int clientId, long bookId, DateTime loanDate)
        {
            string loanQuery = @"
        INSERT INTO Transactions (ClientID, BookID, LoanDate)
        VALUES (@ClientID, @BookID, @LoanDate);
    ";

            string updateQuery = @"
        UPDATE Books
        SET AvailableBooks = AvailableBooks - 1
        WHERE BookID = @BookID AND AvailableBooks > 0;
    ";

            using (var connection = new SqlConnection(DatabaseManager.ConnectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        using (var command = new SqlCommand(loanQuery, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@ClientID", clientId);
                            command.Parameters.AddWithValue("@BookID", bookId);
                            command.Parameters.AddWithValue("@LoanDate", loanDate);
                            command.ExecuteNonQuery();
                        }

                        using (var command = new SqlCommand(updateQuery, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@BookID", bookId);
                            int rowsAffected = command.ExecuteNonQuery();
                            if (rowsAffected == 0)
                            {
                                throw new Exception("Brak dostêpnych egzemplarzy ksi¹¿ki.");
                            }
                        }

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
        public static List<Transaction> GetActiveTransactions()
        {
            string query = @"
                SELECT TransactionID, ClientID, BookID, LoanDate
                FROM Transactions
                WHERE ReturnDate IS NULL;";

            return ExecuteQuery(query, reader =>
                new Transaction
                {
                    TransactionID = int.Parse(reader["TransactionID"].ToString()),
                    ClientID = int.Parse(reader["ClientID"].ToString()),
                    BookID = long.Parse(reader["BookID"].ToString()),
                    LoanDate = DateTime.Parse(reader["LoanDate"].ToString())
                });
        }
        public static void ReturnBook(int transactionId, DateTime returnDate)
        {
            string updateTransactionQuery = @"
        UPDATE Transactions
        SET ReturnDate = @ReturnDate
        WHERE TransactionID = @TransactionID;
    ";

            string updateBookQuery = @"
        UPDATE Books
        SET AvailableBooks = AvailableBooks + 1
        WHERE BookID = (
            SELECT BookID FROM Transactions WHERE TransactionID = @TransactionID
        );
    ";

            using (var connection = new SqlConnection(DatabaseManager.ConnectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {

                        using (var command = new SqlCommand(updateTransactionQuery, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@ReturnDate", returnDate);
                            command.Parameters.AddWithValue("@TransactionID", transactionId);
                            command.ExecuteNonQuery();
                        }

                        using (var command = new SqlCommand(updateBookQuery, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@TransactionID", transactionId);
                            command.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
        public static List<TransactionDetails> GetAllTransactions()
        {
            string query = @"
                SELECT 
                    t.TransactionID, 
                    c.Name AS ClientName, 
                    c.Surname AS ClientSurname,
                    b.BookName AS BookTitle,
                    t.LoanDate, 
                    t.ReturnDate
                FROM Transactions t
                INNER JOIN Clients c ON t.ClientID = c.ClientID
                INNER JOIN Books b ON t.BookID = b.BookID";

            return ExecuteQuery(query, reader =>
                new TransactionDetails
                {
                    TransactionID = int.Parse(reader["TransactionID"].ToString()),
                    ClientName = $"{reader["ClientName"]} {reader["ClientSurname"]}",
                    BookTitle = reader["BookTitle"].ToString(),
                    LoanDate = DateTime.Parse(reader["LoanDate"].ToString()),
                    ReturnDate = reader["ReturnDate"] == DBNull.Value
                        ? null
                        : DateTime.Parse(reader["ReturnDate"].ToString())
                });
        }

        // Metody pomocnicze do zapytañ
        private static void ExecuteNonQuery(string query, Action<SqlCommand> parameterize)
        {
            using (var connection = new SqlConnection(DatabaseManager.ConnectionString))
            {
                using (var command = new SqlCommand(query, connection))
                {
                    parameterize(command);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        private static List<T> ExecuteQuery<T>(string query, Func<SqlDataReader, T> readFunc)
        {
            var results = new List<T>();
            using (var connection = new SqlConnection(DatabaseManager.ConnectionString))
            {
                using (var command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            results.Add(readFunc(reader));
                        }
                    }
                }
            }
            return results;
        }
        public static Book GetBookById(long bookID)
        {
            string query = "SELECT * FROM Books WHERE BookID = @BookID";

            using (var connection = new SqlConnection(DatabaseManager.ConnectionString))
            {
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@BookID", bookID);
                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Book(
                                reader["BookName"].ToString(),
                                reader["Author"].ToString(),
                                DateTime.Parse(reader["ReleaseDate"].ToString()),
                                long.Parse(reader["BookID"].ToString()),
                                int.Parse(reader["NumberOfBooks"].ToString()),
                                int.Parse(reader["AvailableBooks"].ToString())
                            );
                        }
                    }
                }
            }


            return null;
        }





        public static Client GetClientById(int clientId)
        {
            string query = "SELECT * FROM Clients WHERE ClientID = @ClientID";

            using (var connection = new SqlConnection(DatabaseManager.ConnectionString))
            {
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ClientID", clientId);
                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Client(
                                reader["Name"].ToString(),
                                reader["Surname"].ToString(),
                                reader["PESEL"].ToString(),
                                reader["TelephoneNumber"].ToString(),
                                reader["HomeAddress"].ToString()
                            )
                            {
                                ClientID = int.Parse(reader["ClientID"].ToString())
                            };
                        }
                    }
                }
            }

            throw new Exception($"Nie znaleziono klienta o ID: {clientId}");
        }


        public static List<TransactionDetails> GetTransactions()
        {
            string query = @"
    SELECT 
        t.TransactionID, 
        t.ClientID,
        t.BookID,
        t.LoanDate, 
        t.ReturnDate
    FROM Transactions t";

            var transactions = new List<TransactionDetails>();

            using (var connection = new SqlConnection(DatabaseManager.ConnectionString))
            {
                using (var command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var bookID = long.Parse(reader["BookID"].ToString());
                            var clientID = int.Parse(reader["ClientID"].ToString());
                            var book = GetBookById(bookID);
                            var client = GetClientById(clientID);


                            if (book == null)
                            {
                                continue; // Pomijamy transakcjê, jeœli ksi¹¿ka nie istnieje
                            }

                            if (client == null)
                            {
                                continue; // Pomijamy transakcjê, jeœli klient nie istnieje
                            }

                            transactions.Add(new TransactionDetails
                            {
                                TransactionID = int.Parse(reader["TransactionID"].ToString()),
                                ClientName = $"{client.Name} {client.Surname}",
                                BookTitle = book.BookName,
                                LoanDate = DateTime.Parse(reader["LoanDate"].ToString()),
                                ReturnDate = reader["ReturnDate"] == DBNull.Value
                                    ? null
                                    : DateTime.Parse(reader["ReturnDate"].ToString())
                            });
                        }
                    }
                }
            }

            return transactions;
        }

        public static void ExportTableToExcel(string tableName, string filePath)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            string query = $"SELECT * FROM {tableName}";

            using (var connection = new SqlConnection(DatabaseManager.ConnectionString))
            using (var command = new SqlCommand(query, connection))
            {
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (!reader.HasRows)
                        throw new Exception($"Tabela {tableName} jest pusta.");

                    using (var package = new ExcelPackage())
                    {
                        var worksheet = package.Workbook.Worksheets.Add(tableName);

                        for (int col = 0; col < reader.FieldCount; col++)
                        {
                            worksheet.Cells[1, col + 1].Value = reader.GetName(col);
                        }

                        int row = 2; // Dane zaczynaj¹ siê od drugiego wiersza
                        while (reader.Read())
                        {
                            for (int col = 0; col < reader.FieldCount; col++)
                            {
                                worksheet.Cells[row, col + 1].Value = reader[col];
                            }
                            row++;
                        }

                        package.SaveAs(new FileInfo(filePath));
                    }
                }
            }
        }
    }
}
