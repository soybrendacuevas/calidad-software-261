public class StaminaSystem {
    public float CurrentStamina = 100f;
    public float MaxStamina = 100f;

    public void UseStamina(float amount) {
        // BUG
        CurrentStamina -= amount;
    }

    public void RegenerateStamina(float rate) {
        // BUG
        CurrentStamina += rate;
    }
}
