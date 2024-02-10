namespace EvilBaschdi.About.Wpf.Tests;

public class AboutControlTests
{
    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Constructor_HasNullGuards(GuardClauseAssertion assertion)
    {
        assertion.Verify(typeof(AboutControl).GetConstructors());
    }
}