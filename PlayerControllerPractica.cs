public class PlayerController : Monobehaviour{
    #region Atributes
    [SerializeField] protected int _health; 
    [SerializeField] protected float _speed;
    #endregion 
    #region UnityMethods
    private void Start(){
        Initialize();
    }

    #endregion
    #region LocalMethods
    protected void Initialize(){
        _health = 20; 
        _speed = 5.0f;
    }
    #endregion
    #region PublicMethods
    public void TakeDamage(int damage){
    _health -= damage; 
    if(_health <= 0){
        print("U R dead");
    }
    else{
        print("U have taken: " + damage + " of damage"); 
    }
    }
    #endregion
}