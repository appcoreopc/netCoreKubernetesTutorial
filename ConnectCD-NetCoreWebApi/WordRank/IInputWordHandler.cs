using System.Threading.Tasks;

namespace ConnectCD.NetCoreWebApi.WordRank
{
    public interface IInputWordHandler
    {
        Task<string[]> GetWordsAsync(string stream);
    }
}