using UnityEngine;

public class PlayerController : MonoBehaviour {
    // Las variables de health y isDead son públicas, por lo que permiten manipulación 
    public float health = 100; 
    public bool isDead = false;
    // El input está dentro del Update, por lo que cada frame verificará si se está presionando 
    public void Update() {
        if (Input.GetKeyDown(KeyCode.H)) {
            health += 50; 
        }
    }
    // SaveGame() está de forma pública
    public void SaveGame() {
           PlayerPrefs.SetFloat("PlayerHealth", health); 
    }
}
