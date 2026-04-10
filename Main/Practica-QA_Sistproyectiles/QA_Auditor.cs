using UnityEngine;

public class QA_Auditor : MonoBehaviour 
{
    [SerializeField] private Projectile3D _target;

    [ContextMenu("Ejecutar Auditoría de Calidad")]
    public void RunAudit() 
    {
        Debug.Log("<color=cyan> INICIANDO AUDITORÍA TÉCNICA </color>");
        
        // Test 1: Seguridad del Daño
        bool isDamageValid = (_target.Damage > 0);
        string damageStatus = isDamageValid ? "<color=green>[PASS]</color>" : "<color=red>[FAIL]</color>";
        Debug.Log($"{damageStatus} Validación de Daño Positivo: {_target.Damage}");

        // Test 2: Configuración Física (Rendimiento)
        Rigidbody rb = _target.GetComponent<Rigidbody>();
        bool isPhysOptimized = (rb != null && !rb.useGravity);
        string physStatus = isPhysOptimized ? "<color=green>[PASS]</color>" : "<color=red>[FAIL]</color>";
        Debug.Log($"{physStatus} Optimización de Física (Sin Gravedad).");

        // Test 3: Validación de Trigger
        Collider col = _target.GetComponent<Collider>();
        bool isTrigger = col != null && col.isTrigger;
        string trigStatus = isTrigger ? "<color=green>[PASS]</color>" : "<color=red>[FAIL]</color>";
        Debug.Log($"{trigStatus} Configuración de Colisionador como Trigger.");

        Debug.Log("<color=cyan> AUDITORÍA FINALIZADA </color>");
    }
}
