using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConnectCD.NetCoreWebApi.WordRank
{
    public interface IRanker
    {
        Task Collect(string stream);

        Task<IEnumerable<string>> GetTopWordsAsync(int byTopRowWordMostUsed);

        Task<IEnumerable<KeyValuePair<string, int>>> GetTopWordCountAsync(int byTopRowWordMostUsed);

    }
}