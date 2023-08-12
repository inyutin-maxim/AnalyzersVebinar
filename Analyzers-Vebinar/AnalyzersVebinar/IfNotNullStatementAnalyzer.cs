using System;
using System.Collections.Immutable;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Diagnostics;

namespace AnalyzersVebinar;

/// <inheritdoc />
[DiagnosticAnalyzer(LanguageNames.CSharp)]
public class IfNotNullStatementAnalyzer : DiagnosticAnalyzer
{
	/// <inheritdoc />
	public override void Initialize(AnalysisContext context)
	{
		context.EnableConcurrentExecution();
		context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.Analyze|GeneratedCodeAnalysisFlags.ReportDiagnostics);

		context.RegisterCompilationStartAction(compilationContext =>
		{
			compilationContext.RegisterSyntaxNodeAction(analysisContext =>
			{
				if (analysisContext.Node.ChildNodes()
					.Any(x => x.IsKind(SyntaxKind.NotEqualsExpression)))
				{
					analysisContext.ReportDiagnostic(Diagnostic.Create(GetSupportedDiagnostic(), analysisContext.Node.GetLocation()));
				}
			}, SyntaxKind.IfStatement);
		});
	}

	/// <inheritdoc />
	public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics { get; } =ImmutableArray.Create(GetSupportedDiagnostic());

	private static DiagnosticDescriptor GetSupportedDiagnostic() => new("Demo000001",
		"Проверка выражения != null должно происходить через выражение is not",
		"Проверка выражения != null должно происходить через выражение is not", "CodeStyle", DiagnosticSeverity.Warning, true);
}