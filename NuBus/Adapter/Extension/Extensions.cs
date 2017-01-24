using System;

namespace NuBus.Adapter.Extension
{
    public static class Extensions
    {
        public static IBusConfigurator UseRabbitMQ(
           this IBusConfigurator cfg, string host, Action<IBusConfigurator, IEndPointConfiguration> func)
        {
            var endpoint = new EndPointConfiguration(host, new RabbitMQAdapter(host));
            cfg.AddEndpoint(endpoint);
            func(cfg, endpoint);

            return cfg;
        }
    }
}
