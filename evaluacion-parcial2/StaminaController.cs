using System;

public class StaminaController {
    public float Current { get; private set; } = 100f;
    public float Max { get; private set; } = 100f;

    // Deberia verificar valores positivos y clampear el maximo y minimo del Current.
    public void ExecuteAction(float cost) {
        Current -= cost; 
    }

    public void SetStats(float current, float max) {
        this.Current = current;
        this.Max = max;
    }
}
