using Newtonsoft.Json;
using PElementServer.Thrift;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PElementServer
{
    public class PElementServiceImplementation : PElementService.IAsync
    {
        public async Task<PElement> GetAsync(string name, CancellationToken cancellationToken = default)
        {
            string json = await File.ReadAllTextAsync("PeriodicTable.json");
            List<PElement> elements = JsonConvert.DeserializeObject<List<PElement>>(json);
            return elements.SingleOrDefault(e => string.Equals(e.Name, name, System.StringComparison.OrdinalIgnoreCase));
        }

        public async Task<List<PElement>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            string json = await File.ReadAllTextAsync("PeriodicTable.json");
            List<PElement> elements = JsonConvert.DeserializeObject<List<PElement>>(json);
            return elements;
        }
    }
}
