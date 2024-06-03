using Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Repositories
{
    public class PersistRepository
    {

        public bool InsertData(List<Radar> list)
        {
            IMongoCollection<BsonDocument> collection;

            string conn = "mongodb://root:Mongo%402024%23@localhost:27017/";
            var client = new MongoClient(conn);
            var database = client.GetDatabase("DBRadar");
            collection = database.GetCollection<BsonDocument>("Radar");

            foreach (var r in list)
            {
                var document = new BsonDocument
                {
                    { "ConcessionaryCompany", r.ConcessionaryCompany },
                    { "YearPvnSvn", r.YearPvnSvn },
                    { "RadarType", r.RadarType },
                    { "Highway", r.Highway },
                    { "State", r.State },
                    { "KmM", r.KmM },
                    { "City", r.City },
                    { "LaneType", r.LaneType },
                    { "Direction", r.Direction },
                    { "Situation", r.Situation },
                    { "InactivationDate", string.Join(",", r.InactivationDate) },
                    { "Latitude", r.Latitude },
                    { "Longitude", r.Longitude },
                    { "LightSpeed", r.LightSpeed }
                };
                collection.InsertOne(document);
            }
            return true;
        }
    }
}
