using UnityEngine;

public class PlayerController : MonoBehaviour {

//Las variables son publicas por lo que se pueden modificar desde cualquier script
    public float health = 100; 
    // el booleano dead no es la mejor forma de maneja un estado
    public bool isDead = false;

    // este metodo permitiria conseguir vida de manera infinita incluso sobrepasando la vida maxima y pudiendo obtener vida incluso después de que el valor sea negativo
    public void Update() {
        if (Input.GetKeyDown(KeyCode.H)) {
            health += 50; 
        }
    }

    // un pref puede ser modificado de forma externa metiendo valores externos
    public void SaveGame() {
           PlayerPrefs.SetFloat("PlayerHealth", health); 
    }
}
