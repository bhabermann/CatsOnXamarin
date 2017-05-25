using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;

namespace CatsOnXamarin.Services
{
    public class AzureService<T>
    {
        private const string MyAppServiceUrl = "http://habermann.azurewebsites.net";
        private readonly IMobileServiceTable<T> _table;

        public AzureService()
        {
            IMobileServiceClient client = new MobileServiceClient(MyAppServiceUrl);
            _table = client.GetTable<T>();
        }

        public Task<IEnumerable<T>> GetTable()
        {
            return _table.ToEnumerableAsync();
        }
    }
}
