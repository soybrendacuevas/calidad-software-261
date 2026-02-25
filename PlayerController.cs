using UnityEngine;

public class PlayerController : MonoBehaviour {

    #region Variables
    public float speed = 5.0f;
    [SerializeField] RigidBody rb;
    #endregion


    #region Unity Methods

    void Start ()
    {
        Intialize();
    }



    void Update(){

        float moveHor = Input.GetAxis("Horizontal");
        float moveVer  Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHor * speed , rb.velocity.y,moveVer * speed);

        rb.velocity = movement;
    }
    #endregion

    #region Functions
    void Intialize()
    {
        rb = GetComponent<Rigidbody>();
    }
    #endregion
}
