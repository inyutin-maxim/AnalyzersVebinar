// ReSharper disable UnusedType.Global
// ReSharper disable UnusedMember.Global

namespace AnalyzersVebinar.Sample;

// If you don't see warnings, build the Analyzers Project.

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