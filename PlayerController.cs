using UnityEngine;
public class PlayerController : MonoBehaviour
{
    #region AxisVariables
    protected float dirX;
    protected float dirY;
    #endregion

    #region AvatarVariables
    protected Vector2 avatarMovement;
    public float speed = 5.0f;
    #endregion

    void Update()
    {
        dirX = Input.GetAxis("Horizontal");
        dirY = Input.GetAxis("Vertical");

    }
    void FixedUpdate() {
        avatarMovement = new Vector2 (dirX, dirY);
        this.transform.position += avatarMovement * speed * Time.fixedDeltaTime
    }
}
