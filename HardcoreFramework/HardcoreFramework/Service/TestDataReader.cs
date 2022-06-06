using HardcoreFramework.Models;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace HardcoreFramework.Service
{
    public class TestDataReader
    {
        public static async Task<ComputeEngine> GetForm(string path)
        {
            using (FileStream file = new FileStream(path, FileMode.OpenOrCreate))
            {
                ComputeEngine form = await JsonSerializer.DeserializeAsync<ComputeEngine>(file);
                return form;
            }
        }
    }
}
