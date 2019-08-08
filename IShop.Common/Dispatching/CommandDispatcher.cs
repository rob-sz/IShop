using System;
using System.Threading.Tasks;

namespace IShop.Common.Dispatching
{
    public class CommandDispatcher<TSender> 
        : ICommandDispatcher<TSender> where TSender : class
    {
//        public async Task<TCommand> Dispatch<TCommand>(TCommand command) where TCommand : ICommand
//            => throw new NotImplementedException();
    }
}
