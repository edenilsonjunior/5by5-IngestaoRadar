using Models;
using Repositories;

namespace Services
{
    public class ReadService
    {
        private ReadRepository _repository;

        public ReadService()
        {
            _repository = new();
        }

        public List<Radar> LoadData() => _repository.LoadData();

    }
}
