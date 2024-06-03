using Models;

namespace Repositories
{
    public interface IDatabaseRepository
    {
        public List<Radar> LoadData();
    }
}
