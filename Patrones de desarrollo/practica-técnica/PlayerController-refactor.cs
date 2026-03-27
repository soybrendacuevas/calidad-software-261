using UnityEngine;

public enum PlayerStates
{
    Alive,
    Dead
}

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float m_currentHealth = 100;
    [SerializeField] private float m_maxHealth = 100;

    public static event Action<float, float> OnPlayerDamaged;
    public static event Action<float, float> OnPlayerHealed;

    private PlayerStates m_currentPlayerStates = PlayerStates.Alive;

    private void Update()
    {
        ManageInputs();
    }

    private void ManageInputs()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            ApplyHealing(10f);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(10f);
        }

        Move();
    }

    private void ChangeState(PlayerStates p_newState)
    {
        if (p_newState == m_currentPlayerStates) return;

        m_currentPlayerStates = p_newState;
    }

    private void Death()
    {
        // Player dies...
        ChangeState(PlayerStates.Dead);
    }

    public void TakeDamage(float p_damage)
    {
        m_currentHealth -= p_damage;
        m_currentHealth = Mathf.Clamp(m_currentHealth, 0, m_maxHealth);
        OnPlayerDamaged?.Invoke(m_currentHealth, healthPercent);

        if (m_currentHealth <= 0)
            Death();
    }

    public void ApplyHealing(float p_healAmount)
    {
        if (m_currentPlayerStates == PlayerStates.Dead) return;

        m_currentHealth += p_healAmount;
        m_currentHealth = Mathf.Clamp(m_currentHealth, 0, m_maxHealth);
        OnPlayerHealed?.Invoke(m_currentHealth, healthPercent);
    }

    private void Move()
    {
        if (m_currentPlayerStates == PlayerStates.Dead) return;

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        transform.Translate(movement * speed * Time.deltaTime);
    }

    public float GetHealth => m_currentHealth;
}

public class PlayerUI : MonoBehaviour
{
    private void OnEnable() => PlayerController.OnPlayerDamaged += UpdateBar;
    private void OnDisable() => PlayerController.OnPlayerDamaged -= UpdateBar;

    private void UpdateBar(float rawHealth, float percent)
    {
        healthFill.fillAmount = percent;
    }
}


public class SaveGameScript : MonoBehaviour
{
    [SerializeField] private PlayerController m_playerController;

    public void SaveGame()
    {
        PlayerPrefs.SetFloat("PlayerHealth", m_playerController.GetHealth);
    }
}