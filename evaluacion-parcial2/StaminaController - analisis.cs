using System;

public class StaminaController {
    // Las variables son publicas lo que permite que se modifican desde cualquier repositorio
    public float Current { get; private set; } = 100f;
    public float Max { get; private set; } = 100f;

    // No hay ningún limite en la resta o en el valor lo que permitiria sumar en lugar de restar y llegar a valores negativos
    public void ExecuteAction(float cost) {
        Current -= cost; 
    }

    //No hay ninguna verificación en los valores lo que permitiría poner valores muy altos o incluso valores negativos
    public void SetStats(float current, float max) {
        this.Current = current;
        this.Max = max;
    }
}
