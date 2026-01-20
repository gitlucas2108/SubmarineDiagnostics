/*
 * Ponto de entrada da aplicação utilizando top-level statements (C# 9+).
 * Responsável apenas por orquestrar a execução e exibir o resultado.
 */

using SubmarineDiagnostics.Core.Services;
using SubmarineDiagnostics.Core.Strategies;

// Relatório de diagnóstico binário (entrada do sistema)
var report = new List<string>
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

//Validação simples do relatório
if (!report.Any())
{
    Console.WriteLine("Relatório de diagnóstico vazio. Não é possível calcular o consumo de energia.");
    return;
}

// Estancia o serviço de cálculo de consumo de energia com as estratégias apropriadas
var service = new PowerConsumptionService(
    new GammaRateCalculator(),
    new EpsilonRateCalculator());

// Executa o cálculo
var result = service.CalculatePowerConsumption(report);

// Exibe o resultado
Console.WriteLine($"Consumo de energia: {result}");