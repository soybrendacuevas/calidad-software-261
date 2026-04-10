using System.Collections.Generic;
using UnityEngine;

public class ProjectilePool3D : MonoBehaviour 
{
    [SerializeField] private Projectile3D _prefab;
    [SerializeField] private int _initialSize = 20;
    
    private Queue<Projectile3D> _pool = new Queue<Projectile3D>();

    private void Start() 
    {
        // Pre-llenado del pool para evitar picos de CPU en runtime
        for (int i = 0; i < _initialSize; i++) 
        {
            AddProjectileToPool();
        }
    }

    private void AddProjectileToPool() 
    {
        Projectile3D obj = Instantiate(_prefab, transform);
        obj.Deactivate();
        _pool.Enqueue(obj);
    }

    public Projectile3D Get() 
    {
        // Si el pool está vacío, lo expandimos dinámicamente
        if (_pool.Count == 0) AddProjectileToPool();

        Projectile3D proj = _pool.Dequeue();
        proj.gameObject.SetActive(true);
        return proj;
    }

    public void ReturnToPool(Projectile3D proj) 
    {
        _pool.Enqueue(proj);
    }
}
