using UnityEngine;

public class PlayerController : MonoBehaviour {

    //Las variables publicas permiten manipulacion externa y por lo tanto tambien inyecciones de estado en "isDead".
    public float health = 100; 
    public bool isDead = false;

    //Funciones nativas de unity mal encapsuladas.
    public void Update() {
        if (Input.GetKeyDown(KeyCode.H)) {
            health += 50; 
        }
    }

    //No hay desacoplamiento.
    public void SaveGame() {
           PlayerPrefs.SetFloat("PlayerHealth", health); 
    }
}
