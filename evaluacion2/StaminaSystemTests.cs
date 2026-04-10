using NUnit.Framework;

// Nombre de la clase: SistemaQuePruebo + Tests
[TestFixture]
public class StaminaSystemTests
{

    [Test]
    // Estructura: Metodo_Escenario_ResultadoEsperado
    public void ExecuteAction_WhenRecivesNegativeVaue_ShouldNotGetStamina()
    {
        // ARRANGE (Preparar)
        var system = new StaminaController();
        float staminaAmount = -50f
        // ACT (Actuar)
        system.ExecuteAction(staminaAmount);

        // ASSERT (Afirmar/Verificar)

        Assert.AreEqual(150f, system.Current, "La stamina no debería de aumentar.");
    }

    [Test]
    // Estructura: Metodo_Escenario_ResultadoEsperado
    public void ExecuteAction_WhenExceedsVaue_ShouldNotGetNegativeValue()
    {
        // ARRANGE (Preparar)
        var system = new StaminaController();
        float staminaAmount = 150f
        // ACT (Actuar)
        system.ExecuteAction(staminaAmount);

        // ASSERT (Afirmar/Verificar)
        
        Assert.AreEqual(0f, system.Current, "La stamina no debería ser menor a 0.");
    }
}