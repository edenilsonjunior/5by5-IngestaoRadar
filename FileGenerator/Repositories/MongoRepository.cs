using Models;
using MongoDB.Bson;
using MongoDB.Driver;


namespace Repositories
{
    public class MongoRepository : IDatabaseRepository
    {
        private string _connectionStr = "mongodb://root:Mongo%402024%23@localhost:27017/";
        private IMongoCollection<BsonDocument> collection;

        public MongoRepository()
        {
            var client = new MongoClient(_connectionStr);
            var database = client.GetDatabase("DBRadar");
            collection = database.GetCollection<BsonDocument>("Radar");
        }

        public List<Radar> LoadData()
        {
            var list = new List<Radar>();
            try
            {
                var documents = collection.AsQueryable();

                foreach (var item in documents)
                {
                    var r = new Radar
                    {
                        ConcessionaryCompany = (string)item.GetValue("ConcessionaryCompany", ""),
                        YearPvnSvn = (int)item.GetValue("YearPvnSvn", 0),
                        RadarType = (string)item.GetValue("RadarType", ""),
                        Highway = (string)item.GetValue("Highway", ""),
                        State = (string)item.GetValue("State", ""),
                        KmM = (string)item.GetValue("KmM", ""),
                        City = (string)item.GetValue("City", ""),
                        LaneType = (string)item.GetValue("LaneType", ""),
                        Direction = (string)item.GetValue("Direction", ""),
                        Situation = (string)item.GetValue("Situation", ""),
                        InactivationDate = Array.Empty<DateOnly>(),
                        Latitude = (double)item.GetValue("Latitude", 0.0),
                        Longitude = (double)item.GetValue("Longitude", 0.0),
                        LightSpeed = (int)item.GetValue("LightSpeed", 0),
                    };
                    list.Add(r);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: " + e.Message);
                throw;
            }
            return list;
        }
    }
}
