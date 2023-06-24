using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float jumpForce = 5f;
    public Transform groundCheck;
    public float groundCheckRadius = 1f;
    public LayerMask groundLayer;

    [SerializeField] private SpriteRenderer _spriteRenderer;
    private Rigidbody2D rb;
    private bool isJumping = false;
    [SerializeField] private bool isGrounded = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Check if the player is grounded
        GroundCheck();

        if (!isGrounded)
            return;

        // Handle horizontal movement
        float moveDirection = Input.GetAxis("Horizontal");

        SpriteFlipCheck(moveDirection);

        rb.velocity = new Vector2(moveDirection * movementSpeed, rb.velocity.y);

        // Handle jumping
        Jump();
    }

    private void GroundCheck()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    private void SpriteFlipCheck(float moveDirection)
    {
        if (moveDirection > 0)
            _spriteRenderer.flipX = true;
        if (moveDirection < 0)
            _spriteRenderer.flipX = false;
    }
}
