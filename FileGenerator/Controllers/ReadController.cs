using Repositories;
using Models;

namespace Controllers
{
    public class ReadController
    {
        private IDatabaseRepository _repository;

        public ReadController(IDatabaseRepository repository)
        {
            _repository = repository;
        }

        public List<Radar> LoadData()
        {
            return _repository.LoadData();
        }
    }
}
