using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace InductionPush.Controllers
{
    public class RawContentReader
    {
        public static async Task<string> Read(HttpRequestMessage req)
        {
            using (var contentStream = await req.Content.ReadAsStreamAsync())
            {
                contentStream.Seek(0, SeekOrigin.Begin);
                using (var sr = new StreamReader(contentStream))
                {
                    return sr.ReadToEnd();
                }
            }
        }
    }
}