using UnityEngine;

// INTERFAZ DE ESTADO
public interface ICharacterState
{
    bool IsInvulnerable { get; }
    void HandleAction(PlayerController player);
}

// ESTADO: RODAR (Invulnerable)
public class RollingState : ICharacterState
{
    public bool IsInvulnerable => true; // AQUÍ ESTÁN LOS I-FRAMES

    public void HandleAction(PlayerController player)
    {
        // El jugador no puede atacar mientras rueda (Evita exploits)
        Debug.Log("No puedes atacar mientras ruedas.");
    }
}

// ESTADO: IDLE/MOVIMIENTO (Vulnerable)
public class LocomotionState : ICharacterState
{
    public bool IsInvulnerable => false;

    public void HandleAction(PlayerController player)
    {
        if (Input.GetButtonDown("Fire1")) player.ExecuteAttack();
    }
}

// CONTROLADOR PRINCIPAL
public class PlayerController : MonoBehaviour
{
    private ICharacterState _currentState = new LocomotionState();
    [SerializeField] private float health = 1000f;

    public void TakeDamage(float damage)
    {
        // SEGURIDAD: Validación lógica basada en el estado
        if (_currentState.IsInvulnerable)
        {
            Debug.Log("¡I-FRAMES! Daño evitado.");
            return; 
        }

        health -= damage;
        Debug.Log($"Daño recibido. Vida restante: {health}");
    }

    public void StartRoll() => _currentState = new RollingState();
    public void StopRoll() => _currentState = new LocomotionState();

    public void ExecuteAttack() => Debug.Log("¡Ataque ejecutado!");
}
