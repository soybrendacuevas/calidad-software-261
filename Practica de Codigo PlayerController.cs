public class PlayerController : MonoBehaviour {
    #region Knobs
    [Header("Atributos")]
    [SerializeField] protected float _speed;
    [SerializeField] protected float _maxLife;
    #endregion

    #region RunTimeVariables
    protected float _life
    #endregion

    #region UnityMethods
    private void Start(){
        InitializePlayer();
    }
    #endregion


    #region LocalMethods
    ///<summary>
    /// Checa que los valores del Player no sean invalidos, en caso de que lo sean los modifica
    ///<summary>
    protected void InitializePlayer(){
        if (_speed == 0){
            _speed = 7;
        }
        if (_maxLife == 0){
            _maxLife = 10;
        }
        _life = _maxLife;
    }
    #endregion

    #region PublicMethods
    ///<summary>
    /// Modifica el valor de vida del Player
    ///<summary>
    ///<parameters>
    /// p_modify: el valor que se va a sumar a la vida, en caso de que sea daño el valor es negativo, si es para curar el valor es positivo
    ///<parameters>
    public void ModifyHealth(float p_modify){
        _life += p_modify;
        if (_life <= 0){
            Debug.Log(gameObject.name + "ha muerto");
        }
        if (_life > _maxLife){
            _life = _maxLife;     
        }
    }
    #endregion
}