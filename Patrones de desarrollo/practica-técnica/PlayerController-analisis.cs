using UnityEngine;

public class PlayerController : MonoBehaviour {

    ///Las variables son publicas por lo que cualquier script tiene acceso a las variables.
    ///El jugador podria tener vda infinita debido a que no hay un limite.
    public float health = 100; 
    //No hay una comprobacion de muerte para el jugador, osea no tiene un inidcador que cambie el estado del booleano
    public bool isDead = false;

    ///Las funciones de unity son publicas cuando deberian de ser privadas.
    public void Update() {
        if (Input.GetKeyDown(KeyCode.H)) {
            health += 50; 
        }
    }

    ///El player guardda su propia informacion cuando lo deberia de hacer un Script externo que maneje datos del juego.
    public void SaveGame() {
           PlayerPrefs.SetFloat("PlayerHealth", health); 
    }
}
