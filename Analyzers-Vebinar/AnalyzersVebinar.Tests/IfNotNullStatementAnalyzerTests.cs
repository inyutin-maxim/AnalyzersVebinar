using System.Threading.Tasks;
using Xunit;
using Verifier = Microsoft.CodeAnalysis.CSharp.Testing.XUnit.AnalyzerVerifier<AnalyzersVebinar.IfNotNullStatementAnalyzer>;

namespace AnalyzersVebinar.Tests;

public class IfNotNullStatementAnalyzerTests
{
	[Fact]
	public async Task ClassWithMyCompanyTitle_AlertDiagnostic()
	{
		const string text = """
							using System;

							namespace AnalyzersVebinar.Sample;

							public class Spaceship
							{
							    public void SetSpeed(long speed)
							    {
							        if (speed > 299_792_458)
							            throw new ArgumentOutOfRangeException(nameof(speed));
							    }
							}

							public class Examples
							{
							    public class MyCompanyClass
							    {
							    }

							    public void ToStars(Spaceship spaceship)
							    {
							        if (spaceship != null)
							        {
							            spaceship.SetSpeed(300000000);
							            spaceship.SetSpeed(42);
							        }
							    }
							}

							""";

		var expected = Verifier.Diagnostic()
			.WithLocation(22, 9);

		await Verifier.VerifyAnalyzerAsync(text, expected)
			.ConfigureAwait(false);
	}
}