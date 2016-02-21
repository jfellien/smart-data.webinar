using System;
using Fluent_CQRS;
using Fluent_CQRS.Extensions;
using Spree.Domain.Commands;
using Spree.Domain.Model;
using Serilog;

namespace Spree.Domain
{
    public class WarenkorbCommands
    {
        private readonly Aggregates _aggregates;

        public WarenkorbCommands(Aggregates aggregates)
        {
            _aggregates = aggregates;
        }

        public void Handle(ProduktInDenWarenkorbLegen command)
        {
            Log.Information("Begin ProduktInDenWarenkorbLegen");
            _aggregates
                .Provide<Warenkorb>()
                .With(command)
                .Try(warenkorb => warenkorb.ProduktHinzufügen(command.ProduktId))
                .CatchFault(handleFaults)
                .CatchException(handleExceptions);

            Log.Information("End ProduktInDenWarenkorbLegen");
        }

        private void handleFaults(Fault obj)
        {
            Log.Warning(obj.Message);
        }

        private void handleExceptions(Exception obj)
        {
            Log.Error(obj.Message);
        }
    }
}
