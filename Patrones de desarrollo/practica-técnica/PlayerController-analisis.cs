using UnityEngine;

public class PlayerController : MonoBehaviour {
    // Falla: las variables no están cuidadas por
    // el debido principio de encapsulamiento,
    // debido que fueron declaradas como públicas,
    // para ello mejor usar getters/setters.
    public float health = 100; 
    public bool isDead = false;

    // Falla: el Update() no es público, el
    // encapsulamiento de esta función es de tipo privado.
    public void Update() {
        if (Input.GetKeyDown(KeyCode.H)) {
            // Falla: no está clampeado el valor,
            // por lo que puede aumentar su valor
            // indefinidamente.
            health += 50; 
        }
    }

    // Falla: ¿Por qué el Player tiene el guardado?
    // Esto debería ser un componente aparte, por lo que
    // no se respeta el SRP (Principio de Responsabilidad Única).
    public void SaveGame() {
           PlayerPrefs.SetFloat("PlayerHealth", health); 
    }
}
