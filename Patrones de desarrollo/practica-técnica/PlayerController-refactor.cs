using UnityEngine;

public enum PlayerStates { None, Idle, Dead}

public class PlayerController : MonoBehaviour {

    private float health = 100; 
    private bool isDead = false;

    private float m_maxHealth = 100;
    private PlayerStates m_currentPlayerState = PlayerStates.Idle;

    public static event Action<float> OnHealthChange;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.H)) {
            ApplyHealing();
        }
        MovePlayer();
    }

    public void MovePlayer()
    {
        if (m_currentPlayerState == PlayerStates.Dead) return;

        //...
    }

    public void ApplyHealing(float p_healthAmount)
    {
        if (m_currentPlayerState == PlayerStates.Dead) return;
        if (p_healthAmount < 1) return;

        health += p_healthAmount;
        health = Mathf.Clamp(health, 0, m_maxHealth);

        OnHealthChange?.Invoke(health);
    }

    public float GetHealth() { return health; }
    public bool IsDead() { return isDead; }


    public class HealthUI : MonoBehaviour
    {
        private void OnEnable() => ChampionLogic.OnHealthChange += UpdateBar;
        private void OnDisable() => ChampionLogic.OnHealthChange -= UpdateBar;

        private void UpdateUI(float health)
        {
            //...
        }
    }

    public class SaveComponent : MonoBehaviour
    {

        [SerializedField] private PlayerController m_playerController;

        public void SaveGame()
        {
            PlayerPrefs.SetFloat("PlayerHealth", m_playerController.GetHealth());
        }
    }
}
