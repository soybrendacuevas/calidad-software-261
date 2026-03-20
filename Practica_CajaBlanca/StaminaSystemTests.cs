using NUnit.Framework;

[TestFixture]
public class StaminaSystemTests
{
    [Test]
    // Estructura: Metodo_Escenario_ResultadoEsperado
    public void UseStamina_WhenAmountExceedsCurrent_ShouldClampToZero()
    {
        // ARRANGE (Preparar)
        var system = new StaminaSystem();
        float staminaAmountToUse = 100f;

        // ACT (Actuar)
        system.UseStamina(staminaAmountToUse);

        // ASSERT (Afirmar/Verificar)
        Assert.AreEqual(0f, system.CurrentStamina, "La estamina es inferior al limite establecido.");
    }

    [Test]
    // Estructura: Metodo_Escenario_ResultadoEsperado
    public void RegenerateStamina_WhenAmountExceedsMax_ShouldClampToMax()
    {
        // ARRANGE (Preparar)
        var system = new StaminaSystem();
        float staminaForRegeneration = -100f;

        // ACT (Actuar)
        system.RegenerateStamina(staminaForRegeneration);

        // ASSERT (Afirmar/Verificar)
        Assert.AreEqual(system.MaxStamina, system.CurrentStamina, "La estamina sobrepasa el limite.");
    }
}
