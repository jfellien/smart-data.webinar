using Fluent_CQRS;
using LightInject;
using Serilog;
using Spree.Domain;

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

            Log.Information("Prepare Component Registrations");

            Container.RegisterInstance(aggregates);
            Container.Register<WarenkorbCommands>();

            Log.Information("Components registered");
        }

        static Aggregates SetupAggreagates()
        {
            Log.Information("Prepare Aggregates Repository");

            var aggregates = Aggregates.CreateWith(new InMemoryEventStore());
            
            // EventHandler hinzufügen

            return aggregates;
        }

        public static ServiceContainer Container { get; private set; }
    }
}