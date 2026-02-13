/// Summary: Clase de jugador.
/// Author: Miguel Angel Garcia Elizalde.

public class PlayerController : MonoBehaviour 
{
    #region Attributes

    /// Summary: Atributos modificables y ajustables en inspector.
    [Header("Attributes")]
    [Tootip("Health")]
    [SerializeField] protected int m_hp;
    [Tootip("Speed")]
    [SerializeField] protected int m_speed;

    #endregion

    #region Unity Methods

    /// Summary: Llama a la función de inicialización al comienzo del ciclo de juego.
    private void Awake() 
    {
        InitializePlayer();
    }

    #endregion

    #region Private Methods

    /// Summary: Initializa los atributos del jugador.
    protected void InitializePlayer() 
    {
        if (m_hp <= 0) 
            m_hp = 1;

        if (m_speed <= 0) 
            m_speed = 1;
    }

    /// Summary: Función de recepción de daño
    /// Params: p_damageTodo, cuyo valor se utiliza para bajar la vida del jugador.
    protected void TakeDamage(int p_damageToDo) 
    {
        // Edge case.
        if (p_damageToDo <= 0)
            return;
            
        // Otra forma de resolverlo, en donde saco el mínimo entre valores.
        //m_hp = Math.Min(0, m_hp -= p_damageToDo);

        m_hp -= p_damageToDo;

        CheckDeath();
    }

    /// Summary: Checo muerte.
    protected void CheckDeath() 
    {
        if (m_hp <= 0)
            Debug.log("Muere");
    }

    #endregion
}