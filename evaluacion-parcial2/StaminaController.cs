using System;

// EXAMEN PARCIAL II - Miguel Angel Garcia Elizalde

public class StaminaController {
    public float Current { get; private set; } = 100f;
    public float Max { get; private set; } = 100f;

    // Fallo: no hay clampeo de valores, por lo que puede haber valores negativos al final para current.
    // Fallo: no hay verificación / condición centinela para checar si no se ingresa un valor negativo
    // (cosa que llevaría a que se sumen los valores).
    public void ExecuteAction(float cost) {
        Current -= cost; 
    }

    // Fallo: no hay verificación / condición centinela para checar si no se ingresa un valor negativo
    // ya sea en current o en max, lo que puede provocar bugs graves en el futuro.
    public void SetStats(float current, float max) {
        this.Current = current;
        this.Max = max;
    }
}
