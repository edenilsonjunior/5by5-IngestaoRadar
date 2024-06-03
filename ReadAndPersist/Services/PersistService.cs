using Repositories;
using Models;

namespace Services
{
    public class PersistService
    {
        private PersistRepository _repository;

        public PersistService()
        {
            _repository = new();
        }

        public bool InsertData(List<Radar> list) => _repository.InsertData(list);

    }
}
