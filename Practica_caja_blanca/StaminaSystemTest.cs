using System;
using NUnit.FrameWork; 
[TestFixture]
public class StaminaSystemTest
{
	[Test]
	public void UseStamina_WhenAmountExceedsCurrent_ShouldClampToZero() {
        //ARRANGE 
        var sistema = new StaminaSystem();
        //ACT 
        sistema.UseStamina(1000f);
        //ASSERT 
        Assert.AreEqual(0, sistema.CurrentStamina, "El valor es menos al esperado").
    }

    [Test]
    public void Regenerate_WhenAmountExceedsCurrent_ShouldClampToMaxStamina() {
        //ARRANGE 
        var sistema = new StaminaSystem();
        //ACT 
        sistema.RegenerateStamina(1000f);
        //ASSERT 
        Assert.AreEqual(100, sistema.CurrentStamina, "El valor es mayor al esperado").
    }
}
