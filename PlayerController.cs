using UnityEngine;}

/// <summary>
/// Players basic movement.
/// </summary>
public class PlayerController : MonoBehaviour
{
    #region Knobs

    public float speed = 5.0f;

    #endregion

    #region Runtime Variables

    private Rigidbody2D m_playerRb;

    private Vector2 m_moveDirection;

    #endregion

    void Update() 
    {
        Move();
    }

    void FixedUpdate()
    {
        m_playerRb.MovePosition(m_playerRb.position + speed * Time.fixedDeltaTime * m_moveDirection)
    }

    private void Move()
    {
        if (m_moveDirection.magnitude  > 0) {
            float m_movementX = Input.GetAxisRaw("Horizontal");
            float m_movementY = Input.GetAxisRaw("Vertical");

            m_moveDirection = new Vector2(m_movementX, m_movementY).normalized;
        }
    }
}