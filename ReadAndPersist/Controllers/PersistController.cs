using Services;
using Models;

namespace Controllers
{
    public class PersistController
    {
        private PersistService _service;

        public PersistController()
        {
            _service = new();
        }

        public bool InsertData(List<Radar> list) => _service.InsertData(list);

    }
}
