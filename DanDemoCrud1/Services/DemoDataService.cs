using DanDemoCrud1.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DanDemoCrud1.Services
{
    public class DemoDataService : IDemoDataService
    {
        public List<DemoMessage> GetAllMessages()
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["DemoDBConnection"].ConnectionString))
            {
                //open connection to talk to the database server
                con.Open();

                var cmd = con.CreateCommand();
                cmd.CommandText = "GetAllMessages";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                //execute the command
                using (var reader = cmd.ExecuteReader())
                {
                    var results = new List<DemoMessage>();
                    while (reader.Read())
                    {
                        results.Add(new DemoMessage
                        {
                            Id = (int)reader["Id"],
                            Title = (string)reader["Title"],
                            Message = (string)reader["Message"]
                        });
                    }
                    return results;
                }

            }
        }
        public int InsertMessages(InsertMessages model)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["DemoDBConnection"].ConnectionString))
            {
                //open connection to talk to the database server
                con.Open();

                var cmd = con.CreateCommand();
                cmd.CommandText = "InsertMessages";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Title", model.Title);
                cmd.Parameters.AddWithValue("@Message", model.Message);

                SqlParameter idParam = cmd.Parameters.Add("@Id", SqlDbType.Int);
                idParam.Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();

                return (int)idParam.Value;
            }
        }
        public void UpdateMessages(UpdateMessages model)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["DemoDBConnection"].ConnectionString))
            {
                //open connection to talk to the database server
                con.Open();

                var cmd = con.CreateCommand();
                cmd.CommandText = "UpdateMessages";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", model.Id);
                cmd.Parameters.AddWithValue("@Title", model.Title);
                cmd.Parameters.AddWithValue("@Message", model.Message);

                cmd.ExecuteNonQuery();
            }
        }
        public void Delete(int Id)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["DemoDBConnection"].ConnectionString))
            {
                //open connection to talk to the database server
                con.Open();

                var cmd = con.CreateCommand();
                cmd.CommandText = "DeleteMessages";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", Id);

                cmd.ExecuteNonQuery();

            }
        }
    }
}