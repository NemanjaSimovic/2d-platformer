using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D Body;
    private BoxCollider2D Collider;
    private SpriteRenderer Sprite;
    private Animator Animat;

    private enum MovementState { idle, running, jumping, falling }

    [SerializeField] private AudioSource JumpSoundEffect;

    [SerializeField] private float MovementSpeed = 7f;
    [SerializeField] private float JumpForce = 6f;
    [SerializeField] private float OutOfBoundsNegativeYAxis = -30f;

    [SerializeField] private LayerMask JumpableGround;

    private float DirectionX = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Body = GetComponent<Rigidbody2D>();
        Sprite = GetComponent<SpriteRenderer>();
        Animat = GetComponent<Animator>();
        Collider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        DirectionX = Input.GetAxisRaw("Horizontal");
        Body.velocity = new Vector2(DirectionX * MovementSpeed, Body.velocity.y);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            JumpSoundEffect.Play();
            Body.velocity = new Vector2(Body.velocity.x, JumpForce);
        }

        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        var state = MovementState.idle;

        if (DirectionX < 0)
        {
            state = MovementState.running;
            Sprite.flipX = true;
        }
        else if (DirectionX > 0)
        {
            state = MovementState.running;
            Sprite.flipX = false;
        }
        else
        {
            state = MovementState.idle;
        }

        if (Body.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        
        if (Body.velocity.y < -.1f)
        {
            state = MovementState.falling;
            if (Body.position.y < OutOfBoundsNegativeYAxis)
            {
                Body.bodyType = RigidbodyType2D.Static;
                Animat.SetTrigger("death");
            }
        }

        Animat.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(Collider.bounds.center, Collider.bounds.size, 0f, Vector2.down, .1f, JumpableGround);
    }
}
