using UnityEngine;

public enum PlayerStates:
    ALIVESTATE,
    DEATHSTATE

public class PlayerController : MonoBehaviour {

    private float m_maxHealth = 100; 
    private float m_health = 100; 
    private PlayerStates m_state;

    public void ManageLife(float p_amount)
    {
        if (m_state != PlayerStates.DEATHSTATE)
        {
            if (p_amount > 0)
                ApplyHealing(p_amount);
            else
                ApplyDamage(-p_amount);
            m_health = Mathf.Clamp(m_health, 0, m_maxHealth);
            if (m_maxHealth == 0)
                m_state = PlayerStates.DEATHSTATE;
        }
    }

    private void ApplyHealing(float p_amount)
    {
        m_health += p_amount;
    }

    private void ApplyDamage(float p_amount)
    {
        m_health -= p_amount;
    }

    // un pref puede ser modificado de forma externa metiendo valores externos
    public void SaveGame() {
           PlayerPrefs.SetFloat("PlayerHealth", m_health); 
    }
}
