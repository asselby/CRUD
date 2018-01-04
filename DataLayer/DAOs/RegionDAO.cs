using DataLayer.DTOs;
using DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DAOs
{
    public class RegionDAO : IDAO<RegionDTO>
    {
        private SqlConnection sqlConnection = null;
        public void Create(RegionDTO t)
        {
            using(sqlConnection = DatabaseConnectionFactory.GetConnection())
            {
                sqlConnection.Open();
                using(SqlCommand sqlCommand = sqlConnection.CreateCommand())
                {
                    string baseInsertQuery = @"INSERT INTO [NORTHWND].[dbo].[Customer] " +
                                     "(CustomerID, CustomerName) " +
                                     "VALUES ({0}, '{1}')";
                    string realInsertQuery = String.Format(baseInsertQuery,
                        t.CustomerID.ToString(),
                        t.CompanyName);

                    sqlCommand.CommandText = realInsertQuery;
                    sqlCommand.CommandType = CommandType.Text;

                    int result = sqlCommand.ExecuteNonQuery();
                    Console.WriteLine(result);
                }
                sqlConnection.Close();
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public RegionDTO Read(int id)
        {
            RegionDTO regionDTOToReturn = null;
            using (sqlConnection = DatabaseConnectionFactory.GetConnection())
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = sqlConnection.CreateCommand())
                {
                    string baseSelectQuery = @"SELECT * FROM [NORTHWND].[dbo].[Customer] " +
                                     "WHERE [RegionID] = {0}";
                    string realSelectQuery = String.Format(baseSelectQuery, id.ToString());

                    sqlCommand.CommandText = realSelectQuery;
                    sqlCommand.CommandType = CommandType.Text;

                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    if (reader.HasRows)
                    {
                        reader.Read();

                        regionDTOToReturn = new RegionDTO()
                        {
                            CustomerID = reader["CustomerID"].ToString(),
                            CompanyName = reader["CompanyName"].ToString()
                        };
                    }
                }
                sqlConnection.Close();
            }
            return regionDTOToReturn;
        } 

        public ICollection<RegionDTO> Read()
        {
            List<RegionDTO> regionDTOsToReturn = new List<RegionDTO>();
            using (sqlConnection = DatabaseConnectionFactory.GetConnection())
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = sqlConnection.CreateCommand())
                {
                    string realSelectQuery = @"SELECT * FROM [NORTHWND].[dbo].[Customers]";

                    sqlCommand.CommandText = realSelectQuery;
                    sqlCommand.CommandType = CommandType.Text;

                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            regionDTOsToReturn.Add(new RegionDTO()
                            {
                                CustomerID = reader["CustomerID"].ToString(),
                                CompanyName = reader["CompanyName"].ToString()
                            });
                        }                    
                    }
                }
                sqlConnection.Close();
            }
            return regionDTOsToReturn;
        }

        public void Update(RegionDTO t)
        {
            throw new NotImplementedException();
        }
    }
}
