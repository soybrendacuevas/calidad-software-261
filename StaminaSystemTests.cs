using NUnit.Framework;

public class StaminaSystemTests
{
    private StaminaController stamina;
    [Test]
    public void Test_Inyección_No_Esta_Aumentando_La_Stamina()
    {
        //ARRANGE 
        stamina = new StaminaController();
        float staminaInicial = stamina.Current;

        //ACT
        stamina.ExecuteAction(-50f);

        //ASSERT
        Assert.AreEqual(staminaInicial, stamina.Current);

    }
    [Test]
    public void Test_Limite_Inferior_No_Es_Menor_A_0()
    {
        // ARRANGE
        stamina = new StaminaController();

        // ACT
        stamina.ExecuteAction(9999f);

        // ASSERT
        Assert.GreaterOrEqual(stamina.Current, 0f);

    }
}

