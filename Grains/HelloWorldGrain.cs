using System;
using System.Threading;
using System.Threading.Tasks;
using GrainsInterface;
using Orleans;
using Orleans.CodeGeneration;

namespace Grains
{
    public class HelloWorldGrain : Grain, IHelloWorldGrain
    {
        private int counter = 0;

        public Task<string> Hello()
        {
            return Task.FromResult($"Hi, from {this.GetPrimaryKeyString()}. That my first project on Orleans, you called me {++counter} times.");
        }

        public async Task<string> HelloByName(string name)
        {
            await Delay();

            return string.IsNullOrEmpty(name) ? await Hello() : $"Hi, {name} from {this.GetPrimaryKeyString()} , you called me {++counter} times";
        }

        private Task Delay()
        {
            return Task.Delay(TimeSpan.FromSeconds(10));
        }
    }
}