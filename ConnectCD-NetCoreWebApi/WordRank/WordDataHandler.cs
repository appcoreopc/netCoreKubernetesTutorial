using System.Threading.Tasks;

namespace ConnectCD.NetCoreWebApi.WordRank
{
    public class WordDataHandler : IInputWordHandler
    {
        private const string Spacer = " ";
        public async Task<string[]> GetWordsAsync(string stream)
        {
            return await Task.FromResult(stream.Split(Spacer));
        }
    }
}
