using NUnit.Framework;

[TestFixture]
public class StaminaSystemTests
{

    [Test]
    public void UseStamina_WhenAmountExceedsCurrent_ShouldClampToZero()
    {
        // ARRANGE (Preparar)
        var sistema = new StaminaSystem();
        float useStaminaAmount = 200f;

        // ACT (Actuar)
        sistema.UseStamina(useStaminaAmount);

        // ASSERT (Afirmar/Verificar)
        Assert.AreEqual(0f, system.CurrentStamina, "La stamina se redujo mas del minimo.");
    }

    [Test]
    public void RegenerateStamina_WhenCurrentAmountExceedsMax_ShouldClampToMaxAmount()
    {
        // ARRANGE (Preparar)
        var sistema = new StaminaSystem();
        float regenStaminaRate = -150f;

        // ACT (Actuar)
        sistema.RegenerateStamina(regenStaminaRate);

        // ASSERT (Afirmar/Verificar)
        Assert.AreEqual(100f, system.MaxStamina, "La stamina nunca se detiene al regenerar");
    }
}
