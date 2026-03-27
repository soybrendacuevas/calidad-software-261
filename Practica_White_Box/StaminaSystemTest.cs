using System;
using NUnit.Framework;
[TestFixture]
public class StaminaSystemTest
{
	[Test]
	public void UseStamina_WhenAmountExceedsCurrent_ShouldClampToZero() {
		var sistema = new StaminaSystem();
		sistema.UseStamina(100f);
		Assert.AreEqual(0, sistema.CurrentStamina, "El valor es menos del esperado");
	}

	[Test]
	public void Regenerate_WhenAmountExceedsCurrent_ShouldClampToMaxStamina() {
		var sistema = new StaminaSystem();
        sistema.RegenerateStamina(100f);
        Assert.AreEqual(0, sistema.CurrentStamina, "El valor es mayor del esperado");
    }
}
