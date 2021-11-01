using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Laba1
{
    public class SqlService
    {
        private SqlConnection _sqlConnection;
        public void InitConnection(string username, string password, string dataBase)
        {
            string connString = $"Data Source=.\\SQLEXPRESS;Initial Catalog={dataBase};" +
                                "Integrated Security=True;";
            // $"User ID={username};" +
            //  $"Password={password}";

            _sqlConnection = new SqlConnection(connString);
        }

        public void InsertTable()
        {
            try
            {
                _sqlConnection.Open();
                var query = "INSERT INTO Train VALUES " +
                            "(1,'Shwydkisnyi')," +
                            "(2,'Intercity')," +
                            "(3,'Shwydkisnyi')," +
                            "(4,'Passager')," +
                            "(5,'Shwydkisnyi')";
                using var cmd = new SqlCommand(query, _sqlConnection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                _sqlConnection.Close();
            }
        }

        public void DeleteData(string tableName)
        {
            try
            {
                _sqlConnection.Open();
                var query = $"DELETE FROM {tableName}";
                using var cmd = new SqlCommand(query, _sqlConnection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                _sqlConnection.Close();
            }
        }

        public void PrintBookingTickets()
        {
            try
            {
                _sqlConnection.Open();
                var query = $"SELECT Passeger.[Name],Passeger.[Last Name],DirectionInformation.Destination,DirectionInformation.Cost,DirectionInformation.DateDeparture,DirectionInformation.DateArrival " +
                            $"FROM Passeger " +
                            $"JOIN BookingTicket ON BookingTicket.PassegerId=Passeger.Id " +
                            $"JOIN DirectionInformation ON BookingTicket.Id=DirectionInformation.Id";
                using var cmd = new SqlCommand(query, _sqlConnection);
                using var rdr = cmd.ExecuteReader();

                var table = new DataTable();
                table.Load(rdr);

                foreach (DataRow row in table.Rows)
                {
                    row.ItemArray.ToList().ForEach(column => Console.Write(column.ToString() + "   "));
                    Console.WriteLine();
                }

                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                _sqlConnection.Close();
            }
        }

        public void PrintTable(string tableName)
        {
            try
            {
                _sqlConnection.Open();
                var query = $"SELECT * FROM {tableName}";
                using var cmd = new SqlCommand(query, _sqlConnection);
                using var rdr = cmd.ExecuteReader();

                var table = new DataTable();
                table.Load(rdr);

                foreach (DataRow row in table.Rows)
                {
                    row.ItemArray.ToList().ForEach(column => Console.Write(column.ToString() + "   "));
                    Console.WriteLine();
                }

                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                _sqlConnection.Close();
            }
        }
    }
}
