using System;

public class StaminaController {
    public float Current { get; private set; } = 100f;
    public float Max { get; private set; } = 100f;

    public void ExecuteAction(float cost) {
        Current -= cost; 
        ///No hay ningun limitante lo que permite que current sea un valor negativo
        ///Otra nota que tengo es que si cost es un valor negativo se relaizar una operacion de suma
        /// por los signos lo que deriva en que se rellene stamina de forma ilegal.
    }

    public void SetStats(float current, float max) {
        ///Aqui se pueden modificar los valores por positivos o negativos.
        this.Current = current;
        this.Max = max;
    }
}