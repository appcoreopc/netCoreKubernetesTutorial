
using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConnectCD.NetCoreWebApi.WordRank
{
    public class WordRanker : IRanker 
    {
        private static ConcurrentDictionary<string, int>
       _wordsWeUsed = new ConcurrentDictionary<string, int>();

        private WordDataHandler _wordhandler;
        private ILogger _logger;

        public WordRanker(WordDataHandler handler, ILogger logger)
        {
            _wordhandler = handler;
            _logger = logger;
        }

        public async Task Collect(string stream)
        {
            if (stream == null)
                return;

            var distinctWordsFromMessage = await _wordhandler.GetWordsAsync(stream);

            if (distinctWordsFromMessage != null)
            {
                foreach (var wordsElement in distinctWordsFromMessage?.Distinct())
                {
                    var key = wordsElement.ToUpperInvariant();

                    var keyFound = _wordsWeUsed.TryGetValue(key, out int count);
                    if (keyFound)
                    {                        
                        _wordsWeUsed[key] = count + 1;
                        _logger.LogInformation($"*** Found {key}, Current Count: {count} ***");
                    }
                    else
                    {
                        _wordsWeUsed.TryAdd(key, 1);
                        _logger.LogInformation($"Found {key}, Current Count: 1");
                    }
                }
            }
        }

        public async Task<IEnumerable<string>> GetTopWordsAsync(int byTopRowWordMostUsed)
        {
            return await Task.FromResult(_wordsWeUsed.OrderByDescending(x => x.Value).Take(byTopRowWordMostUsed)?.Select(x => x.Key));
        }

        public async Task<IEnumerable<KeyValuePair<string, int>>> GetTopWordCountAsync(int byTopRowWordMostUsed)
        {
            return await Task.FromResult(_wordsWeUsed.OrderByDescending(x => x.Value)?.Take(byTopRowWordMostUsed));
        }
    }
}
