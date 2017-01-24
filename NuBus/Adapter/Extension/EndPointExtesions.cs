﻿using System;
using System.Linq;

namespace NuBus.Adapter.Extension
{
    public static class EndPointExtesions
    {
        public static void RegisterAssemblyMessages(this IEndPointConfiguration endpoint)
        {
            var baseEventType = typeof(IEvent);
            var baseCommandType = typeof(ICommand);

            AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => (p.GetInterfaces().Contains(baseEventType)
                             || p.GetInterfaces().Contains(baseCommandType))
                       && !p.IsInterface && !p.IsAbstract)
                .ToList()
                .ForEach(endpoint.AddMessage);
        }

        public static void RegisterAssemblyHandlers(this IEndPointConfiguration endpoint)
        {
            var baseHandlerType = typeof(IHandler<>);
            AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p =>
                    !p.IsAbstract
                    && !p.IsInterface
                    && p.GetInterfaces()
                        .Any(x =>
                            x.IsGenericType
                             && x.GetGenericTypeDefinition() == baseHandlerType))
                .ToList()
                .ForEach(endpoint.AddHandler);
        }
    }
}
