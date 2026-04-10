using UnityEngine;
public enum FSMHealthStatus {
    GoodHealth,
    LowHealth,
    DeadState,
}
public class PlayerController : MonoBehaviour {
    // Las variables de health y isDead son públicas, por lo que permiten manipulación 
    [SerializedField] private float health = 100; 
    [SerializedField] private float maxHealth = 100;
    [SerializedField] private bool isDead = false;
    [SerializedField] private FSMHealthStatus healthStatus; 
    // El input está dentro del Update, por lo que cada frame verificará si se está presionando 
    private void Start () {
        switch(health) {
            case health > 50:
                healthStatus = FSMHealthStatus.GoodHealth;
                break;
            case health < 51 && health > 0:
                healthStatus = FSMHealthStatus.LowHealth;
                break;
            case health < 0:
                healthStatus= FSMHealthStatus.DeadState;
                break; 
        }
    }
    private void Update() {
        switch (health) {
            case health > 50:
                healthStatus = FSMHealthStatus.GoodHealth;
                break;
            case health < 51 && health > 0:
                healthStatus = FSMHealthStatus.LowHealth;
                break;
            case health < 0:
                healthStatus = FSMHealthStatus.DeadState;
                break;
        }
        switch (healthStatus) {
            case FSMHealthStatus.GoodHealth:
            case FSMHealthStatus.LowHealth:
                if (Input.GetKeyDown(KeyCode.H)) {
                    health += 50; 
                }
                break;
            case FSMHealthStatus.DeadState:
                break; 
        }
        
    }
    // SaveGame() está de forma pública
    private void SaveGame() {
           PlayerPrefs.SetFloat("PlayerHealth", health); 
    }
    private void ApplyHealing(float amount) {
        if(amount < 0) {
            Debug.log("No se aceptan Valores negativos");
            return; 
        }
        health += Mathf.Clamp(amount, 0, maxHealth);
    }
}
