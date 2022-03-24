using System.Threading;
using System.Threading.Tasks;
using Orleans;
using Orleans.CodeGeneration;

namespace GrainsInterface
{
    public interface IHelloWorldGrain : IGrainWithStringKey
    {
        Task<string> Hello();
        
        Task<string> HelloByName(string name);
    }
}