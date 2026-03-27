using UnityEngine;

public class ServerPositionValidator : MonoBehaviour
{
    [SerializeField] private float maxSpeed = 10f; // Velocidad máx permitida
    private Vector3 lastVerifiedPosition;

    public void OnReceiveClientPosition(Vector3 claimedPosition, float deltaTime)
    {
        // 1. Calculamos la distancia que el cliente dice haber recorrido
        float distance = Vector3.Distance(lastVerifiedPosition, claimedPosition);
        
        // 2. Calculamos la distancia máxima teórica (Velocidad * Tiempo)
        // Añadimos un pequeño margen (Epsilon) para latencia de red
        float maxAllowedDistance = (maxSpeed * deltaTime) + 0.1f;

        if (distance <= maxAllowedDistance)
        {
            // Entrada válida: Actualizamos posición
            lastVerifiedPosition = claimedPosition;
            ApplyPositionToCharacter(claimedPosition);
        }
        else
        {
            // Entrada INVÁLIDA (Posible Cheat): Rechazamos y devolvemos al jugador
            Debug.LogWarning("Sanitization Fail: Movimiento imposible detectado.");
            ResetPlayerToLastValidPosition();
        }
    }

    private void ApplyPositionToCharacter(Vector3 pos) { /* ... */ }
    private void ResetPlayerToLastValidPosition() { /* ... */ }
}
