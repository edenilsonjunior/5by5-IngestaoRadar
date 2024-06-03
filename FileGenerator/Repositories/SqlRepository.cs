using Microsoft.Data.SqlClient;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class SqlRepository : IDatabaseRepository
    {
        public List<Radar> LoadData()
        {
            string conn = "Data Source=127.0.0.1; Initial Catalog=DBRadar; User Id=sa; Password=SqlServer2019!; TrustServerCertificate=Yes";

            var connection = new SqlConnection(conn);

            var cmd = new SqlCommand("SELECT * FROM Radar", connection);

            List<Radar> list = null;
            try
            {
                connection.Open();

                using var reader = cmd.ExecuteReader();
                list = new List<Radar>();

                while (reader.Read())
                {
                    var r = new Radar
                    {
                        ConcessionaryCompany = reader["concessionaria"].ToString(),
                        YearPvnSvn = int.Parse(reader["ano_do_pnv_snv"].ToString()),
                        RadarType = reader["tipo_de_radar"].ToString(),
                        Highway = reader["rodovia"].ToString(),
                        State = reader["uf"].ToString(),
                        KmM = reader["km_m"].ToString(),
                        City = reader["municipio"].ToString(),
                        LaneType = reader["tipo_pista"].ToString(),
                        Direction = reader["sentido"].ToString(),
                        Situation = reader["situacao"].ToString(),
                        Latitude = double.Parse(reader["latitude"].ToString()),
                        Longitude = double.Parse(reader["longitude"].ToString()),
                        LightSpeed = int.Parse(reader["velocidade_leve"].ToString())
                    };

                    if (DateOnly.TryParse(reader["data_da_inativacao"].ToString(), out _) == false)
                        r.InactivationDate = new DateOnly[] { };
                    else
                        r.InactivationDate = new DateOnly[] { DateOnly.Parse(reader["data_da_inativacao"].ToString()) };

                    list.Add(r);
                }

            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Erro SQL: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
            return list;
        }

    }
}
