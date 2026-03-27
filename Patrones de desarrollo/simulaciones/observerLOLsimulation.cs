using UnityEngine;
using System;

// NÚCLEO DE LÓGICA (Simula el Servidor/Entidad)
public class ChampionLogic : MonoBehaviour
{
    [SerializeField] private string championName = "Ahri";
    [SerializeField] private float currentHealth = 500f;
    [SerializeField] private float maxHealth = 500f;

    // EVENTO: La señal que emite el héroe al recibir daño
    // Enviamos el valor actual y el porcentaje (0 a 1) para la UI
    public static event Action<float, float> OnChampionDamaged;

    public void ReceiveDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        float healthPercent = currentHealth / maxHealth;

        // EMISIÓN DE LA SEÑAL
        // Los observadores (UI, Partículas) reaccionarán a esto
        OnChampionDamaged?.Invoke(currentHealth, healthPercent);

        if (currentHealth <= 0) Die();
    }

    private void Die() => Debug.Log($"{championName} ha sido eliminado.");
}

// OBSERVADOR 1: Barra de Vida (UI)
public class HealthBarUI : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Image healthFill;

    private void OnEnable() => ChampionLogic.OnChampionDamaged += UpdateBar;
    private void OnDisable() => ChampionLogic.OnChampionDamaged -= UpdateBar;

    private void UpdateBar(float rawHealth, float percent)
    {
        healthFill.fillAmount = percent; // Cambia la barra visualmente
    }
}

// OBSERVADOR 2: Sistema de Sangre/Efectos (FX)
public class BloodFXManager : MonoBehaviour
{
    [SerializeField] private ParticleSystem bloodParticles;

    private void OnEnable() => ChampionLogic.OnChampionDamaged += PlayBlood;
    private void OnDisable() => ChampionLogic.OnChampionDamaged -= PlayBlood;

    private void PlayBlood(float raw, float percent)
    {
        bloodParticles.Play(); // Solo visual, no afecta la vida real
    }
}
