using System;

public class StaminaController {
    //Todas las variables son publicas por lo que pueden ser modificadas por cualquiera
    //No hay límtes para los varoles de las variables 
    public float Current { get; private set; } = 100f;
    public float Max { get; private set; } = 100f;

    //Se pueden agregar datos negativos 
    public void ExecuteAction(float cost) {
        Current -= cost; 
    }
    //Se pueden agregar datos negativos 
    public void SetStats(float current, float max) {
        this.Current = current;
        this.Max = max;
    }
}
