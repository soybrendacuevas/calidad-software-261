using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float health = 100; 
    public bool isDead = false;

    public void Update() {
        if (Input.GetKeyDown(KeyCode.H)) {
            health += 50; 
        }
    }

    public void SaveGame() {
           PlayerPrefs.SetFloat("PlayerHealth", health); 
    }
}
