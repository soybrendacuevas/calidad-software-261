using UnityEngine;
using System.Reflection;
using System.Linq;

public class MaliciousInjector : MonoBehaviour
{
    // Este método simula el "Punto de Entrada" una vez inyectada la DLL
    public static void Inject()
    {
        GameObject hackObject = new GameObject("Injected_Core");
        hackObject.AddComponent<MaliciousInjector>();
        Object.DontDestroyOnLoad(hackObject);
    }

    void Update()
    {
        // Disparador del Exploit (Ej: Al presionar la tecla End)
        if (Input.GetKeyDown(KeyCode.End))
        {
            ExecuteMemoryCorruption();
        }
    }

    private void ExecuteMemoryCorruption()
    {
        // 1. Escaneo de Tipos: Buscamos cualquier clase que maneje "Salud" o "Dinero"
        // sin necesidad de conocer el nombre exacto del script.
        var targetType = System.AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(a => a.GetTypes())
            .FirstOrDefault(t => t.Name.Contains("Player") || t.Name.Contains("Health"));

        if (targetType != null)
        {
            // 2. Localizamos la instancia activa en la jerarquía de Unity
            Object targetInstance = Object.FindObjectOfType(targetType);

            if (targetInstance != null)
            {
                // 3. Inyección de Atributos: Forzamos valores ilegales
                // Buscamos campos que parezcan sensibles (vida, oro, nivel)
                FieldInfo[] fields = targetType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
                
                foreach (var field in fields)
                {
                    if (field.FieldType == typeof(float) || field.FieldType == typeof(int))
                    {
                        // Seteamos un valor extremadamente alto (God Mode)
                        field.SetValue(targetInstance, 999999f);
                        Debug.Log($"<color=red>[ALERTA DE SEGURIDAD]</color> Campo {field.Name} vulnerado.");
                    }
                }
            }
        }
    }
}
