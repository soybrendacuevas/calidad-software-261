using UnityEngine;

public class StaminaSystemTest{
    StaminaController _staminaController;

    public void SetUp(){
        _staminaController = new StaminaController();
    }


    ///Testing
    public void Execute_InyectionTest(){

        ///Arrange
        float InitStamina = 50f;
        float negativeCost = -50f;
        _staminaController(InitStamina,100f);

        ///Act
        _staminaController.ExecuteAction(negativeCost);

        ///Assert
        Assert.LessOrEqual(_staminaController.Current,InitStamina,
        "Stamina increase, the system accpet a negative value");
    }

    public void Execute_BelowLimit(){

        ///Arrange
        float InitStamina = 10f; 
        float excessiveCost = 50f;
        _staminaController.SetStats(InitStamina,100f);

        //Act
        _staminaController.ExecuteAction(excessiveCost);

        ///Assert -> Stamina shouls stop at cero and no get any negative value
        Assert.GreaterOrEqual(_staminaController.Current.0f,
        "Stamina is negative, the syustemn dont aplly the limit");
        
    }
    
}