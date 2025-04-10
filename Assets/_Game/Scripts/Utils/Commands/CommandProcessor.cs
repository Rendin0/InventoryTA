
using System;
using System.Collections.Generic;
using UnityEngine;

public class CommandProcessor : ICommandProcessor
{
    private readonly Dictionary<Type, object> handlersMap = new();

    public bool Process<TCommand>(TCommand command) where TCommand : ICommand
    {
        if (handlersMap.TryGetValue(typeof(TCommand), out var handler))
        {
            var typedHandler = (ICommandHandler<TCommand>)handler;

            var result = typedHandler.Handle(command);

            return result;
        }

        Debug.LogError($"Handler for {typeof(TCommand)} not found");
        return false;
    }

    public void RegisterHandler<TCommand>(ICommandHandler<TCommand> commandHandler) where TCommand : ICommand
    {
        handlersMap[typeof(TCommand)] = commandHandler;
    }
}