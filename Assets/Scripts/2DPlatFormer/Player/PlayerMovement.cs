using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{   
    [SerializeField] private float moveSpeed;
    [SerializeField] private ColorManager colorManager;
    private Rigidbody2D rb;
    private Vector2 horizontalMovement;

    private void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement();
    }

    private void movement()
    {
        rb.linearVelocity = new Vector2(
            horizontalMovement.x * moveSpeed,
            rb.linearVelocity.y
        );
    }


    private void OnMove(InputValue value)
    {
        horizontalMovement = value.Get<Vector2>();
    }

    public void chgGravity()
    {
        rb.gravityScale *= -1;
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, -rb.linearVelocity.y);
    }
}
