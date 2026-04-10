using System;
using NUnit.FrameWork;
[TestFixture]

public class StaminaSystemTest
{
    [Test]
    public void UseStamina_WhenAmountExceedsCurrent_ShouldClampToZero()
    {
        //ARRANGE
        var sistem = new StaminaSystem();
        //ACT
        sistem.UseStamina(150f);
        ///ASSERT
        Assert.AreEqual(0, sistem.CurrentStamina, "El valor es menos al esperado");
    }

    [Test]
    public void Regenerate_WhenAmountExceedCurrent_ShouldClampToMaxStamina()
    {
        ///ARRANGE
        var sistem = new StaminaSystem();
        //ACT
        sistem.RegenerateStamina(150f);
        ///ASSERT
        Assert.AreEqual(0, sistem.CurrentStamina, "El valor es mayor al esperado");
    }

}
