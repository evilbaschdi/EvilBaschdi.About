using Avalonia.Controls;

namespace EvilBaschdi.About.Avalonia.Tests;

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
        assertion.Verify(typeof(AboutControl).GetMethods().Where(method => !method.IsAbstract &
                                                                           !method.Name.StartsWith("set") &
                                                                           !method.Name.StartsWith("add") &
                                                                           !method.Name.StartsWith("remove")));
    }
}