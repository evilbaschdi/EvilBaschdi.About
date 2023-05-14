using System.Windows.Controls;

namespace EvilBaschdi.About.Wpf.Tests;

public class AboutControlTests
{
    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Constructor_HasNullGuards(GuardClauseAssertion assertion)
    {
        assertion.Verify(typeof(AboutControl).GetConstructors());
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Constructor_ReturnsInterfaceName(AboutControl sut)
    {
        sut.Should().BeAssignableTo<UserControl>();
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Methods_HaveNullGuards(GuardClauseAssertion assertion)
    {
        assertion.Verify(typeof(AboutControl).GetMethods().Where(method => !method.IsAbstract));
    }
}