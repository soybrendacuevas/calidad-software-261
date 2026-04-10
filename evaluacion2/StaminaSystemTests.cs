using NUnit.Framework;

public class StaminaSystemTests
{
    private StaminaController staminaController;

    [Test]
    public void ExecuteAction_NegativeInjection_DoesNotIncreaseStamina()
    {
        // ARRANGE
        staminaController = new StaminaController();
        float initialStamina = staminaController.Current;

        // ACT
        staminaController.ExecuteAction(-50f);

        // ASSERT
        float finalStamina = staminaController.Current;
        Assert.LessOrEqual(finalStamina, initialStamina, 
            "La estamina no debe de aumentar");
    }

    [Test]
    public void ExecuteAction_ExcessiveCost_StaminaNotBelowZero()
    {
        // ARRANGE
        staminaController = new StaminaController();

        // ACT
        staminaController.ExecuteAction(150f);

        // ASSERT
        float finalStamina = staminaController.Current;
        Assert.GreaterOrEqual(finalStamina, 0f, 
            "La estamina no debe ser menor a 0");
    }
}