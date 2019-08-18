using System;

namespace IShop.Common.Messaging.Command
{
    public class CommandHandlerNotFoundException : Exception
    {
        public ICommand Command { get; }

        public CommandHandlerNotFoundException(ICommand command)
            : base($"Command handler not found for: {nameof(command)}.")
        {
            Command = command;
        }
    }
}
