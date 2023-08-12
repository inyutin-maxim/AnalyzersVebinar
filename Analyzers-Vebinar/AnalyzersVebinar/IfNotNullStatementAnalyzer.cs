using System;
using System.Collections.Immutable;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace AnalyzersVebinar;

[DiagnosticAnalyzer(LanguageNames.CSharp)]
public class IfNotNullStatementAnalyzer : DiagnosticAnalyzer
{
	/// <inheritdoc />
	public override void Initialize(AnalysisContext context)
	{
		context.EnableConcurrentExecution();
		context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.Analyze|GeneratedCodeAnalysisFlags.ReportDiagnostics);

		throw new NotImplementedException();
	}

	/// <inheritdoc />
	public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics { get; } = new()
	{
		new("Demo000001", "Проверка выроажение != null должно происходить через выражение is not",
			"Проверка выроажение != null должно происходить через выражение is not", "CodeSyle", DiagnosticSeverity.Warning, true)
	};
}