using Microsoft.Data.SqlClient;
using Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.Serialization;

namespace Repositories
{
    public class PersistRepository
    {

        public List<Radar> LoadData()
        {
            // Ler os dados do JSON e voltar um list<Radar>

            using var reader = new StreamReader(@"C:\ingestaoRadarJson\dados_dos_radares.json");

            string jsonStr = reader.ReadToEnd();

            var settings = new JsonSerializerSettings
            {
                Culture = new CultureInfo("pt-BR"),
                DateFormatString = "dd/MM/yyyy"
            };

            var lst = JsonConvert.DeserializeObject<RadarList>(jsonStr, settings);

            if (lst == null)
                return null;

            return lst.Lst;

        }

        public bool Insert(List<Radar> list)
        {
            string conn = "Data Source=127.0.0.1; Initial Catalog=DBRadar; User Id=sa; Password=SqlServer2019!; TrustServerCertificate=Yes";
            bool works = true;

            try
            {
                using var connection = new SqlConnection(conn);
                connection.Open();

                foreach (var item in list)
                {
                    string sql = "INSERT INTO Radar VALUES ";

                    sql += "(@concessionaria, " +
                            "@ano_do_pnv_snv, " +
                            "@tipo_de_radar, " +
                            "@rodovia, " +
                            "@uf, " +
                            "@km_m, " +
                            "@municipio, " +
                            "@tipo_pista, " +
                            "@sentido, " +
                            "@situacao, " +
                            "@data_da_inativacao, " +
                            "@latitude, " +
                            "@longitude, " +
                            "@velocidade_leve)";

                    using var cmd = new SqlCommand(sql, connection)
                    {
                        Parameters =
                        {
                            new SqlParameter("@concessionaria", item.ConcessionaryCompany),
                            new SqlParameter("@ano_do_pnv_snv", item.YearPvnSvn),
                            new SqlParameter("@tipo_de_radar", item.RadarType),
                            new SqlParameter("@rodovia", item.Highway),
                            new SqlParameter("@uf", item.State),
                            new SqlParameter("@km_m", item.KmM),
                            new SqlParameter("@municipio", item.City),
                            new SqlParameter("@tipo_pista", item.LaneType),
                            new SqlParameter("@sentido", item.Direction),
                            new SqlParameter("@situacao", item.Situation),
                            new SqlParameter("@latitude", item.Latitude),
                            new SqlParameter("@longitude", item.Longitude),
                            new SqlParameter("@velocidade_leve", item.LightSpeed)
                        }
                    };

                    if (item.InactivationDate.Length != 0)
                        cmd.Parameters.Add(new SqlParameter("@data_da_inativacao", item.InactivationDate[0]));
                    else
                        cmd.Parameters.Add(new SqlParameter("@data_da_inativacao", DBNull.Value));

                    cmd.ExecuteNonQuery();
                }


                connection.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Erro SQL: {ex.Message}");
                works = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
                works = false;
            }

            return works;
        }
    }
}
