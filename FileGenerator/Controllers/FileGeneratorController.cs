using Models;
using Services;

namespace Controllers
{
    public class FileGeneratorController
    {
        private FileGeneratorService _service;

        public FileGeneratorController()
        {
            _service = new();
        }

        public string GenerateJson(List<Radar> list) => _service.GenerateJson(list);

        public string GenerateCsv(List<Radar> list) => _service.GenerateCsv(list);

        public string GenerateXml(List<Radar> list) => _service.GenerateXml(list);

    }
}
