using UnityEngine;
using System;

public class SecureResourceManager : MonoBehaviour, IDisposable
{
    private Texture2D _temporarySecretTexture;

    public void LoadSensitiveData()
    {
        // Simulamos la carga de una textura de seguridad/mapa
        _temporarySecretTexture = new Texture2D(1024, 1024);
    }

    // Implementación de IDisposable para asegurar la limpieza manual
    public void Dispose()
    {
        if (_temporarySecretTexture != null)
        {
            // En Unity, Destroy no libera la memoria RAM/VRAM inmediatamente.
            // DestroyImmediate es preferible en lógica de limpieza crítica.
            DestroyImmediate(_temporarySecretTexture);
            _temporarySecretTexture = null;
            Debug.Log("Memoria liberada de forma segura.");
        }
    }

    private void OnDestroy() => Dispose();
}
