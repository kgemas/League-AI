using System.Threading.Tasks;

namespace LeagueAI.Libraries.Interfaces
{
    public interface IProgram
    {
        Task<int> Main(string[] args);
    }
}
