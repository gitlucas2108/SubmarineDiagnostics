
using SubmarineDiagnostics.Core.Interfaces;

namespace SubmarineDiagnostics.Core.Strategies
{
    /// <summary>
    /// Calcula a taxa Épsilon utilizando o bit menos comum
    /// em cada posição do relatório de diagnóstico.
    /// </summary>
    public class EpsilonRateCalculator : IBinaryRateCalculator
    {
        public string Calculate(IEnumerable<string> diagnosticReport)
        {
            // Validação de entrada
            if (diagnosticReport is null || !diagnosticReport.Any())
                throw new ArgumentException("O relatório de diagnóstico não pode ser nulo ou vazio.", nameof(diagnosticReport));

            int length = diagnosticReport.First().Length;
            var result = new char[length];

            for (int i = 0; i < length; i++)
            {
                int ones = diagnosticReport.Count(x => x[i] == '1');
                int zeros = diagnosticReport.Count() - ones;

                result[i] = ones < zeros ? '1' : '0';
            }

            return new string(result);
        }
    }
}
