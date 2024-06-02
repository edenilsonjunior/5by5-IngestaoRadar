using Models;
using Repositories;

namespace Services
{
    public class PersistService
    {
        private PersistRepository _repository;

        public PersistService()
        {
            _repository = new();
        }


        public List<Radar> LoadData()
        {
            return _repository.LoadData();
        }

        public bool Insert(List<Radar> list)
        {
            return _repository.Insert(list);
        }

    }
}
