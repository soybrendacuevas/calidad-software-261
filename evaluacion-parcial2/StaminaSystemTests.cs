using System;
using UnityEngine.Assertions;

[TestFixture]
public class StaminaSystemTests {

    [Test]
    public void ExecuteAction_WhenRecievingANegativeValue_StaminaShouldNotIncrease()
    {
        //Arrange
        var system = new StaminaController();
        system.SetStats(100.0f, 100.0f);
        float testValue = -50.0f;

        //Act
        system.ExecuteAction(testValue);

        //Assert
        Assert.AreEqual(system.Current, system.Max, "La stamina debería de ser igual a Max ya que los valores negativos no deberían de ser considerados por ExecuteAction.");
    }

    [Test]
    public void ExecuteAction_WhenRecievingABigValue_StaminaShouldNotBeLessThanZero()
    {
        //Arrange
        var system = new StaminaController();
        system.SetStats(10.0f, 100.0f);
        float testValue = 500.0f;

        //Act
        system.ExecuteAction(testValue);

        //Assert
        Assert.IsTrue(system.Current < 0, "La stamina no debería de ser menor a 0 incluso despues de restarle un valor elevado");
    }
}
