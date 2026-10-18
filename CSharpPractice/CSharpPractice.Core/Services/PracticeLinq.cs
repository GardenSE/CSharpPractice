using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using MySqlConnector;


namespace CSharpPractice.Core.Services
{
    internal class PracticeLinq
    {
        private readonly IConfiguration _configuration;

        internal PracticeLinq(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        internal async Task GetItineraryListAsync()
        {
            using (MySqlConnection cn = new MySqlConnection())
            {
                cn.ConnectionString = _configuration.GetConnectionString("Default");
                await cn.OpenAsync();

                using (MySqlCommand cmd = cn.CreateCommand())
                {
                    StringBuilder sql = new StringBuilder();
                    sql.AppendLine("SELECT ITN.PlanID");
                    sql.AppendLine("    ,  PLN.PlanName");
                    sql.AppendLine("    ,  PLN.CustomerID");
                    sql.AppendLine("    ,  CONCAT(CTM.CustomerLastName, ' ', CTM.CustomerFirstName) AS CustomerName");
                    sql.AppendLine("    ,  ITN.TravelDate");
                    sql.AppendLine("FROM   TD_Itinerary ITN");
                    sql.AppendLine("       LEFT JOIN TD_Plan PLN");
                    sql.AppendLine("              ON ITN.PlanID = PLN.PlanID");
                    sql.AppendLine("       LEFT JOIN TM_Customer CTM");
                    sql.AppendLine("              ON PLN.CustomerID = CTM.CustomerID");

                    using (MySqlDataReader dr = await cmd.ExecuteReaderAsync())
                    {
                        while (await dr.ReadAsync())
                        {

                        }
                    }
                }
            }
        }
    }
}
