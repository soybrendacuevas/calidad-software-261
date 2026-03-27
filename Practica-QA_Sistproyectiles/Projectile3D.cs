using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Projectile3D : MonoBehaviour 
{
    [Header("Security & QA Settings")]
    [Range(1f, 100f)] // Input Sanitization: Evita daño negativo o nulo
    [SerializeField] private float _damage = 10f;
    [SerializeField] private float _speed = 20f;

    // Propiedad de solo lectura: Security by Design (Encapsulamiento)
    public float Damage => _damage; 

    private Rigidbody _rb;

    private void Awake() 
    {
        _rb = GetComponent<Rigidbody>();
        _rb.useGravity = false; // Optimización de rendimiento físico
    }

    private void OnEnable() 
    {
        // Al activarse (desde el pool), reiniciamos la trayectoria en el eje Z (forward)
        _rb.linearVelocity = transform.forward * _speed;
    }

    private void OnTriggerEnter(Collider other) 
    {
        // Log de auditoría en consola
        Debug.Log($"QA Log: Impacto con {other.name} | Daño registrado: {_damage}");
        Deactivate();
    }

    public void Deactivate() 
    {
        gameObject.SetActive(false); // Retorno al Object Pool
    }
}
