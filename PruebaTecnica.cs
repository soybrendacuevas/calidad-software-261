public class PlayerController : MonoBehaviour{

    #region Atributos
    [Serializefield] protected int _life; 
    [Serializefield] protected float _speed;
    #endregion

    #region UnityFunctions
    private void Start(){
        Initialize();
    }
    private void Update(){        
        if(_life <= 0){
            Debug.Log("Moriste carnalillo");
        }
    }
    #endregion

    #region Funciones
    void Initialize(){
        _life = 100f;
        _speed = 5f;
    }
    
    public void TakeDamage(int t_damage){
        _life -= t_damage;
        Debug.Log("Recibiste daño:" + t_damage);
    }
    #endregion
}