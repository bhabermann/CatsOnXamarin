using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CatsOnXamarin.Services;

namespace CatsOnXamarin.Models
{
    public class Repository
    {
        public async Task<List<Cat>> GetCats()
        {
            var service = new AzureService<Cat>();
            var items = await service.GetTable();
            return items.ToList();
        }
    }
}
