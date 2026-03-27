using UnityEngine;

public class PlayerShooter : MonoBehaviour 
{
    [Header("Arquitectura de Disparo")]
    [SerializeField] private ProjectilePool3D _pool; 
    [SerializeField] private Transform _firePoint;   

    void Update() 
    {
        // Disparo mediante Input Sanitized (Fire1 mapeado a Mouse0)
        if (Input.GetButtonDown("Fire1")) 
        {
            Shoot();
        }
    }

    private void Shoot() 
    {
        if (_pool == null || _firePoint == null) return;

        // Inyección de dependencia desde el Pool
        Projectile3D proj = _pool.Get();
        
        proj.transform.position = _firePoint.position;
        proj.transform.rotation = _firePoint.rotation;
    }
}
