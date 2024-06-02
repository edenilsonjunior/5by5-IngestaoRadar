using Models;
using Services;

namespace Controllers
{
    public class PersistController
    {
        private PersistService _service;

        public PersistController()
        {
            _service = new();
        }

        public List<Radar> LoadData()
        {
            return _service.LoadData();
        }

        public bool Insert(List<Radar> list)
        {
            return _service.Insert(list);
        }

    }
}
