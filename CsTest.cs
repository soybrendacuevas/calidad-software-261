

public class PlayerController : MonoBehaviour {

    #region Runtime Variables

    [SerializedField] protected float m_speed;
    [SerializedField] protected int m_health;

    #endregion

    #region Local Methods

    ///
    /// Inicializa los datos del jugador.
    /// 
    private void InitializePlayerData() {
        
    }

    ///
    /// El player recibe dano.
    /// 
    protected void GetDamage(int p_damage) {
        if (m_health > 0)
            m_health -= p_damage;
        else
            Debug.Log("Muerto");
    }
    #endregion

}