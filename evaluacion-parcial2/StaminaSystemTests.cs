using NUnit.Framework;

[TestFixture]
public class StaminaSystemTests
{

    [Test]
    public void ExecuteAction_WhenStaminaCostIsNegative_ShouldNotAddToCurrentStaminaAmount() {
        // ARRANGE
        var system = new StaminaController();
        float staminaCostAmount = -50f;

        // ACT
        system.SetStats(100f, 100f);
        system.ExecuteAction(staminaCostAmount);

        // ASSERT
        Assert.Greater(100f, system.Current, "La estamina no deberia aumentar con valores negativos.");
    }

    [Test]
    public void ExecuteAction_WhenStaminaCostIsExcessive_CurrentStaminaShouldStayAtZero() {
        // ARRANGE
        var system = new StaminaController();
        float staminaCostAmount = -500f;

        // ACT
        system.SetStats(100f, 100f);
        system.ExecuteAction(staminaCostAmount);

        // ASSERT
        Assert.Less(0f, system.Current, "La estamina no deberia bajar de 0.");
    }
}
