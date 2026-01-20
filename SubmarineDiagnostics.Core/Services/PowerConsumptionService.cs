using SubmarineDiagnostics.Core.Interfaces;
using SubmarineDiagnostics.Core.Utils;

namespace SubmarineDiagnostics.Core.Services
{
    public class PowerConsumptionService
    {
        private readonly IBinaryRateCalculator _gammaCalculator;
        private readonly IBinaryRateCalculator _epsilonCalculator;

        /// <summary>
        /// Serviço responsável por calcular o consumo de energia do submarino
        /// a partir do relatório de diagnóstico binário.
        /// </summary>
        public PowerConsumptionService(IBinaryRateCalculator gammaCalculator,IBinaryRateCalculator epsilonCalculator)
        {
            _gammaCalculator = gammaCalculator;
            _epsilonCalculator = epsilonCalculator;
        }

        public int CalculatePowerConsumption(IEnumerable<string> diagnosticReport)
        {
            if (diagnosticReport == null || !diagnosticReport.Any())
                throw new ArgumentException("Diagnostic report cannot be null or empty.");

            int length = diagnosticReport.First().Length;

            if (diagnosticReport.Any(x => x.Length != length))
                throw new ArgumentException("All binary values must have the same length.");

            var gammaBinary = _gammaCalculator.Calculate(diagnosticReport);
            var epsilonBinary = _epsilonCalculator.Calculate(diagnosticReport);

            int gamma = BinaryConverter.ToDecimal(gammaBinary);
            int epsilon = BinaryConverter.ToDecimal(epsilonBinary);

            return gamma * epsilon;
        }
    }
}
