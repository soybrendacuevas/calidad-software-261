public class PlayerController : MonoBehaviour
{
    //Atributos del jugador
    #region Atributtes
    [SerializeField] protected float p_velocity;
    [SerializeField] protected int p_health;
    #endregion

    #region UnityMethods
    private void Start()
    {
        p_velocity = 30f;
        p_health = 100;
    }
    #endregion



    #region  LocalMethods
    public void LoseHealth(int e_damage)
    {
        if(p_health >= 0){
            p_health -= e_damage;
            Debug.Log("Ouch!");
        }
        else{
            Debug.Log("Game Over");
        }        
    }
    #endregion
}