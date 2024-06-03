using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class PersistDataFileRepository
    {
        private string _path = @"C:\Radar\";

        private string _content;
        private string _extension;
        private string _fileName;

        public PersistDataFileRepository(string content, string extension)
        {
            _content = content;
            _extension = extension;
            _fileName = $"output.{extension}";
        }


        public void SaveToFile()
        {
            CreateDirectory();
            CreateFile();

            using (var sw = new StreamWriter(_path + _fileName))
            {
                sw.WriteLine(_content);
            }
        }

        private void CreateDirectory()
        {
            if (!Directory.Exists(_path))
                Directory.CreateDirectory(_path);

        }
        private void CreateFile()
        {
            if (!File.Exists(_path + _fileName))
            {
                var fs = File.Create(_path + _fileName);
                fs.Close();
            }
        }
    }
}
