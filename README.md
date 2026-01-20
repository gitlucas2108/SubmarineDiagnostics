Submarine Diagnostics – Power Consumption
## 📌 Objetivo

Este projeto resolve o desafio Submarine Diagnostics – Power Consumption, cujo objetivo é calcular o consumo de energia de um submarino a partir de um relatório de diagnóstico binário, seguindo regras bem definidas para extração das métricas.

O foco da solução está em clareza de código, boa organização, testabilidade e extensibilidade, além da correta implementação do algoritmo proposto.

## 🧠 Descrição da Solução

A partir de um conjunto de números binários, a aplicação calcula:

Taxa Gama (Gamma Rate)
Formada pelo bit mais comum em cada posição do relatório.

Taxa Épsilon (Epsilon Rate)
Formada pelo bit menos comum em cada posição do relatório.

O consumo de energia é obtido multiplicando os valores decimais das duas taxas.

## 🏗 Estrutura da Solução

A solução está organizada em três projetos distintos, promovendo separação de responsabilidades:
```text
SubmarineDiagnostics
 ├── SubmarineDiagnostics.Console   // Aplicação Console (entry point)
 ├── SubmarineDiagnostics.Core      // Regras de negócio e domínio
 └── SubmarineDiagnostics.Tests     // Testes unitários (xUnit)
```
Responsabilidades

Console: ponto de entrada da aplicação e execução do fluxo.

Core: regras de negócio, estratégias de cálculo e utilitários.

Tests: validação automática do comportamento esperado.

## 🧩 Arquitetura e Padrões Adotados
Strategy Pattern

O Strategy Pattern foi utilizado para encapsular as regras de cálculo das taxas:

GammaRateCalculator

EpsilonRateCalculator

Benefícios:

Código desacoplado

Facilidade de manutenção

Possibilidade de adicionar novas métricas sem alterar o serviço principal

Application Service

A classe PowerConsumptionService atua como um Application Service, sendo responsável por:

Orquestrar o fluxo de cálculo

Delegar responsabilidades às estratégias

Centralizar o caso de uso do domínio

Dependency Injection

As estratégias são injetadas via construtor, promovendo:

Baixo acoplamento

Testabilidade

Conformidade com o princípio Dependency Inversion (SOLID)

## 🛠 Tecnologias Utilizadas

.NET 8

C#

xUnit

Git

Programação Orientada a Objetos

Padrões de Projeto

## 🔍 Algoritmo (Visão Geral)

Valida o relatório de diagnóstico

Percorre cada posição dos números binários

Conta a ocorrência de bits 0 e 1

Aplica a regra correspondente à estratégia

Converte os valores binários para decimal

Calcula o consumo de energia

## ✅ Testes

O projeto de testes utiliza xUnit e valida:

O cálculo correto do consumo de energia a partir de um relatório válido

A integração entre o serviço de cálculo e as estratégias de taxa (Gamma e Épsilon)

O comportamento esperado diante de entradas inválidas, como:

Relatório de diagnóstico vazio

Valores binários com tamanhos inconsistentes

Segurança contra regressões futuras por meio de testes automatizados

Os testes podem ser executados via:

Visual Studio (Test Explorer)

CLI (.NET): dotnet test

## 🚀 Execução

Defina o projeto Console como projeto de inicialização

Execute a aplicação

O valor do consumo de energia será exibido no console

## 🧩 Considerações Finais

Esta solução prioriza:

Código limpo e legível

Separação clara de responsabilidades

Uso consciente de padrões de projeto

Estrutura escalável, mesmo para um desafio simples

O resultado é uma implementação fiel ao desafio, porém estruturada como seria esperado em um ambiente profissional.
