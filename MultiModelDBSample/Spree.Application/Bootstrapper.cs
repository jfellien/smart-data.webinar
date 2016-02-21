using Fluent_CQRS;
using LightInject;
using Serilog;
using Spree.Domain;
using Spree.QueryModel;

namespace Spree.Application
{
    class Bootstrapper
    {
        public static void ApplicationStartup(ServiceContainer container)
        {
            var log = new LoggerConfiguration()
                        .WriteTo.ColoredConsole()
                        .CreateLogger();
            Log.Logger = log;

            Container = container;
            var aggregates = SetupAggreagates();

            Container.RegisterInstance(aggregates);
            Container.Register<WarenkorbCommands>();
        }

        static Aggregates SetupAggreagates()
        {
            var aggregates = Aggregates.CreateWith(new InMemoryEventStore());

            aggregates.PublishNewStateTo(new WarenkorbEvents());

            return aggregates;
        }

        public static ServiceContainer Container { get; private set; }
    }
}