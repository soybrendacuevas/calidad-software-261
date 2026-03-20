using NUnit.Framework;

// Nombre de la clase: SistemaQuePruebo + Tests
[TestFixture]
public class StaminaSystemTest {

    [Test]
    // Estructura: Metodo_Escenario_ResultadoEsperado
    public void UseStamina_WhenAmountExceedsCurrent_ShouldClampToZero()
    {
        // ARRANGE (Preparar)
        var system = new StaminaSystem(); // Stamina: 100
        float drainAmount = 150f;

        // ACT (Actuar)
        system.UseStamina(drainAmount);

        // ASSERT (Afirmar/Verificar)
        // La stamina dreanada era 150 y el mana total era 100, el resultado debería de ser un clamp en 0
        Assert.AreEqual(0f, system.CurrentStamina, "La stamina debería de ser 0 incluso despues del drenado excesivo");
    }

    [Test]
    // Estructura: Metodo_Escenario_ResultadoEsperado
    public void RegenerateStamina_WhenAmountExceedsMax_ShouldClampToMax()
    {
        // ARRANGE (Preparar)
        var system = new StaminaSystem(); // Stamina: 100, MaxStamina:100
        float regenerateAmount = 15f;

        // ACT (Actuar)
        system.RegenerateStamina(regenerateAmount);

        // ASSERT (Afirmar/Verificar)
        // La stamina dreanada era 150 y el mana total era 100, el resultado debería de ser un clamp en 0
        Assert.AreEqual(system.CurrentStamina, system.MaxStamina, "La stamina debería de ser igual a max Stamina incluso despues de que regenere mas del maximo");
    }
}