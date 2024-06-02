using Repositories;
using Models;

namespace Services
{
    public class ReadAndPersistService
    {
        private ReadAndPersistRepository _repository;

        public ReadAndPersistService()
        {
            _repository = new();
        }

        public List<Radar> LoadData()
        {
            return _repository.LoadData();
        }

        public bool InsertData(List<Radar> list)
        {
            return _repository.InsertData(list);
        }
    }
}
