using Microsoft.Data.SqlClient;

namespace Models
{
    public class SqlDatabase
    {
        public static readonly string INSERT = "INSERT INTO Radar VALUES (@concessionaria, @ano_do_pnv_snv, @tipo_de_radar, @rodovia, @uf, @km_m, @municipio, @tipo_pista, @sentido, @situacao, @data_da_inativacao, @latitude, @longitude, @velocidade_leve)";
        public static readonly string SELECT = "SELECT * FROM Radar";

        private static string connStr = "Data Source=127.0.0.1; Initial Catalog=DBRadar; User Id=sa; Password=SqlServer2019!; TrustServerCertificate=Yes";

        private static SqlConnection instance;

        private SqlDatabase()
        {
            
        }

        public static SqlConnection GetInstance()
        {
            if (instance == null)
                instance = new SqlConnection(connStr);

            return instance;
        }
    }
}
