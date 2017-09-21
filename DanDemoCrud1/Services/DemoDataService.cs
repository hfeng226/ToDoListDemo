using DanDemoCrud1.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
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
            using(var reader = cmd.ExecuteReader())
                {
                    var results = new List<DemoMessage>();
                    while (reader.Read())
                    {
                        results.Add(new DemoMessage
                        {
                            Id = (int)reader["id"],
                            Message = (string)reader["message"]
                        });
                    }
                    return results;
                }

            }
        }
    }
}