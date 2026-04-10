using NUnit.Framework;

// EXAMEN PARCIAL II - Miguel Angel Garcia Elizalde

[TestFixture]
public class StaminaSystemTests {
    private StaminaSystemController stamina;

    [SetUp]
    public void Setup() {
        stamina = new StaminaController();
        stamina.SetStats(100f, 100f);
    }

    [Test]
    public void ExecuteAction_NegativeCost_ShouldNotIncreaseStamina() {
        // ARRANGE (Preparar)
        float initialStamina = stamina.Current;
        float costTest = -50.0f;

        // ACT (Actuar)
        stamina.ExecuteAction(costTest);

        // ASSERT (Afirmar/Verificar)
        Assert.LessOrEqual(stamina.Current, initialStamina,
            "La estamina NO debe aumentar con valores negativos, no se puede.");
    }

    [Test]
    public void ExecuteAction_ExcessiveCost_ShouldNotDropBelowZero() {
        // ARRANGE (Preparar)
        float costTest = 250.0f;

        // ACT (Actuar)
        stamina.ExecuteAction(costTest);

        // ASSERT (Afirmar/Verificar)
        Assert.GreaterOrEqual(stamina.Current, 0,
            "La estamina NO debe ser inferior a 0.");
    }
}