using SubmarineDiagnostics.Core.Services;
using SubmarineDiagnostics.Core.Strategies;

namespace SubmarineDiagnostics.Tests
{
    /// <summary>
    /// Testes unitários do serviço responsável por calcular
    /// o consumo de energia do submarino.
    /// </summary>
    public class PowerConsumptionServiceTests
    {
        [Fact]
        public void Should_Calculate_PowerConsumption_Correctly()
        {
            // Arrange
            List<string> diagnosticReport = new()
            {
                "00100",
                "11110",
                "10110",
                "10111",
                "10101",
                "01111",
                "00111",
                "11100",
                "10000",
                "11001",
                "00010",
                "01010"
            };

            var service = new PowerConsumptionService(
                new GammaRateCalculator(),
                new EpsilonRateCalculator());

            // Act
            var result = service.CalculatePowerConsumption(diagnosticReport);

            // Assert
            Assert.Equal(198, result);
        }

        [Fact]
        public void Should_Throw_Exception_When_Report_Is_Empty()
        {
            // Arrange
            var diagnosticReport = new List<string>();

            var service = new PowerConsumptionService(
                new GammaRateCalculator(),
                new EpsilonRateCalculator());

            // Act & Assert
            Assert.Throws<ArgumentException>(() =>
                service.CalculatePowerConsumption(diagnosticReport));
        }

        [Fact]
        public void Should_Throw_Exception_When_Binary_Lengths_Are_Inconsistent()
        {
            // Arrange
            var diagnosticReport = new List<string>
            {
                "10110",
                "1011",   // tamanho diferente
                "10110"
            };

            var service = new PowerConsumptionService(
                new GammaRateCalculator(),
                new EpsilonRateCalculator());

            // Act & Assert
            Assert.Throws<ArgumentException>(() =>
                service.CalculatePowerConsumption(diagnosticReport));
        }
    }
}
