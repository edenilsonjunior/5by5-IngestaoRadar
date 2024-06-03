using Models;
using Services;

namespace Controllers
{
    public class ReadController
    {

        private ReadService _service;

        public ReadController()
        {
            _service = new();
        }

        public List<Radar> LoadData() => _service.LoadData();

    }
}
