using UnityEngine;

public class PlayerController : MonoBehaviour {
    //Las variables al ser publicas, permiten la manipulacion externa y por lo tanto tambien inyecciones de estado en "isDead"
    public float health = 100; 
    public bool isDead = false;


    //Las funciones nativas de unity ademas de estar publicas estan mal encapsuladas
    public void Update() {
        if (Input.GetKeyDown(KeyCode.H)) {
            health += 50; 
        }
    }

    //El player tiene acceso al guardado, esto deberia ser controlado por otro script
    public void SaveGame() {
           PlayerPrefs.SetFloat("PlayerHealth", health); 
    }
}
