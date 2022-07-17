using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private float jumpForce = 5f;
    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Jump(InputAction.CallbackContext inputContext)
    {
        if (inputContext.performed)
        {
            _rigidbody.velocity = transform.up * jumpForce;
        }
    }
}
