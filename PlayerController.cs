///
/// Summary Código base de Player Controller con C#
/// Author: Miguel Angel Garcia Elizalde


/// Enum de los estados del jugador.
public enum PlayerStates
{
    NONE,
    IDLE,
    MOVING
}

using UnityEngine;
public class PlayerController : MonoBehaviour {

    #region References

    /// Summary: Variable que guarda un código de input del jugador, en donde se supone que debe
    /// guardarse los valores de los inputs.
    [Header("Referencias")]
    [ToolTip("Toma el código de input del jugador y lea los distintos valores")]
    [SerializeField] protected PlayerInput m_playerInputReference;

    [ToolTip("Toma la referencia del RigidBody")]
    [SerializeField] protected RigidBody m_playerRB;

    #endregion

    #region Runtime Variables

    /// Summary: Variable que maneja el estado actual del jugador.
    protected PlayerStates m_currentState = PlayerStates.IDLE;

    /// Summary: Variable que maneja el estado actual del jugador.
    protected Vector2 m_movementDirection = Vector2.zero;


    #endregion

    #region  Knobs
    [Header("Variables")]
    [ToolTip("Variable que controla la velocidad")]
    [SerializeField] protected float m_speed = 5.0f;

    #endregion
    
    #region Unity Methods

    /// Summary: Calculamos el movimiento del jugador.
    void FixedUpdate() 
    {        
        MovePlayer();
    }
    #endregion

    #region Public Methods
    
    /// Summary: Función que actualiza el estado de la máquina de
    /// estados finita del jugador.
    public void ChangeState(PlayerStates p_newState) 
    {
        if (m_currentState == p_newState)
            return;

        m_currentState == p_newState;
    }

    #endregion

    #region Local Methods

    /// Summary: Función que mueve al jugador, tomando.
    protected void MovePlayer()
    {

        // Asumimos que hay una función o getter en el otro código donde se lee el input.
        m_movementDirection = PlayerInput.GetMovementInput();
        
        //Checamos la magnitud, ya que sino, va a moverse. Así prevenimos problemas de drift.
        if (m_movementDirection.magnitude >= 0.1f)
        {
            ChangeState(PlayerStates.MOVING);
            m_playerRB.velocity = m_movementDirection * m_speed;
        }
        else if (m_movementDirection.magnitude <= 0.1f)
        {
            ChangeState(PlayerStates.IDLE;
            m_playerRB.velocity = m_movementDirection * 0.0f;
        }
    }

    #endregion
}