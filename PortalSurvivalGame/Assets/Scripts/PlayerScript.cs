using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    private PlayerControls controls; //the input system C# class
    private Vector2 movementInput;
    public float speed = 5f;
    private Rigidbody2D rb;

    private void Awake()
    {
        controls = new PlayerControls();
        rb = GetComponent<Rigidbody2D>();

        controls.Player.Move.performed += ctx => movementInput = ctx.ReadValue<Vector2>();
        controls.Player.Move.canceled += ctx => movementInput = Vector2.zero;
    }

    private void OnEnable()
    {
        controls.Enable(); //enable the action map
    }

    private void OnDisable()
    {
        controls.Disable(); //disable the action map
    }

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementInput.x, 0f, movementInput.y);
        rb.AddForce(movement * speed * Time.deltaTime, ForceMode2D.Impulse);
    }
}
