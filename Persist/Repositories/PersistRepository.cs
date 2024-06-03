using Microsoft.Data.SqlClient;
using Models;
using Newtonsoft.Json;
using System.Globalization;

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

            return lst?.Lst;
        }

        public bool Insert(List<Radar> list)
        {
            bool works = true;

            List<Task> tasks = new List<Task>();


            int halfCount = list.Count / 2;
            try
            {
                SqlConnection connection = SqlDatabase.GetInstance();
                connection.Open();

                tasks.Add(Task.Run(() =>
                {
                    for (int i = 0; i < halfCount; i++)
                    {
                        var item = list[i];
                        ExecuteSqlCommand(connection, item);
                    }
                }));

                tasks.Add(Task.Run(() =>
                {
                    for (int i = halfCount; i < list.Count; i++)
                    {
                        var item = list[i];
                        ExecuteSqlCommand(connection, item);
                    }
                }));

                Task.WaitAll(tasks.ToArray());

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

        private void ExecuteSqlCommand(SqlConnection connection, Radar item)
        {
            using var cmd = new SqlCommand(SqlDatabase.INSERT, connection)
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

    }
}
