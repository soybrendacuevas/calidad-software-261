using System;

public class StaminaController {
    //Las variable son publicas osea pueden ser moficiadas por cualquier persona
    public float Current { get; private set; } = 100f;
    public float Max { get; private set; } = 100f;

    // No hay control de límites: Current puede ser menor a 0
    public void ExecuteAction(float cost) {
        Current -= cost; 
    }

    //No hay validacion de limites ni clamp al maximo
    public void SetStats(float current, float max) {
        this.Current = current;
        this.Max = max;
    }
}
