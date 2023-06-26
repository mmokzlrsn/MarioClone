using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float jumpForce = 5f;
    public Transform LeftFoot;
    public Transform RightFoot;
    public float groundCheckRadius = 1f;
    public LayerMask groundLayer;

    [SerializeField] private SpriteRenderer _spriteRenderer;
    private Rigidbody2D rb;
    private bool isJumping = false;
    [SerializeField] private bool isGrounded = false;

    [SerializeField] PlayerAnimationController _animator;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Check if the player is grounded
        GroundCheck(); 

        if (!isGrounded)
        {
            _animator.PlayJumpState();
            return;
        }

        // Handle horizontal movement
        float moveDirection = Input.GetAxis("Horizontal");

        SpriteFlipCheck(moveDirection);

        rb.velocity = new Vector2(moveDirection * movementSpeed, rb.velocity.y);

        if (moveDirection > 0)
            _animator.PlayRunState();
        else if (moveDirection < 0) _animator.PlayRunState();
        
        else if(moveDirection == 0) _animator.PlayIdleState();

        // Handle jumping
        Jump();
    }

    private void GroundCheck()
    {
        isGrounded = Physics2D.OverlapArea(LeftFoot.position, RightFoot.position, groundLayer);
         
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(LeftFoot.position,RightFoot.position);
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
