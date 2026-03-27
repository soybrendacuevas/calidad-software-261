using UnityEngine;
public class PlayerController : MonoBehaviour {
    #region Atributes
    public float speed = 5.0f;
    private float _inputX, _inputY;
    private RigidBody2D rb; 
    #endregion

    #region UnityMethods
    void Start(){
        rb = GetComponent<RigidBody2D>();
    }
    void FixedUpdate() {
        PlayerMovement();
    }
    #endregion
    
    #region LocalMethods
    private void PlayerMovement(){
        _inputX = Input.GetAxisRaw("Horizontal") * speed; 
        _inputY = Input.GetAxisRaw("Vertical") * speed; 
        rb.velocity = new Vector2(_inputX, _inputX);
    }
    #endregion


}