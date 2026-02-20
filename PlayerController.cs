using UnityEngine;
using UnityEngine.InputSystem;
/// <summary>
/// Clase que maneja el movimiento del player en dos ejes pensado para entornos en 3D
/// </summary>
/// </requirements>
/// Requiere que haya un Input map con la Accion Move de valor Vector2
/// </requirements>

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    #region References
    [SerializeField] protected RigidBody _rb;
    #endregion

    #region Knobs
    [SerializeField] protected float _speed = 5.0f;
    #endregion

    #region RunTimeVariables
    protected Vector2 _moveDirection;
    #endregion

    #region UnityMethods
    void FixedUpdate() { 
    _rb.linearVelocity = new Vector3 (_moveDirection.x, 0, _moveDirection.y) * _speed;
    }
    #endregion

    #region InputMethods

    /// <summary>
    /// lee el valor de la Input Action Move y se la asigna _moveDirection
    /// </summary>
    /// <param name="p_context"></param> el valor que regresa move
    public void OnMove(InputAction.CallbackContext p_context) {
        if (context.performed) {
            _moveDirection = context.ReadValue<Vector2>();
        }
        else {
            _moveDirection = Vector2.zero;
        }
    }

    #endregion
}