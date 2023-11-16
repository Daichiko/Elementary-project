using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float JumpForce;
    [SerializeField] private Transform controladorGolpe;

    [SerializeField] private LayerMask JumpableGround;

    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;
    private BoxCollider2D coll;

    private float dirX;
    private bool Grounded;

    private enum MovementState { idle, running, jumping, falling };

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);


        if (Input.GetKeyDown(KeyCode.W) && isGrounded())
        {
            Jump();
        }

        UpdateAnimationState();
    }

    private void UpdateAnimationState() 
    {
        MovementState state;

        if (dirX > 0)
        {
            if (controladorGolpe.localPosition.x < 0)
                controladorGolpe.SetLocalPositionAndRotation(new Vector3(controladorGolpe.localPosition.x * -1, controladorGolpe.localPosition.y, controladorGolpe.localPosition.z), controladorGolpe.localRotation);
            
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0)
        {
            if (controladorGolpe.localPosition.x > 0)
                controladorGolpe.SetLocalPositionAndRotation(new Vector3(controladorGolpe.localPosition.x * -1, controladorGolpe.localPosition.y, controladorGolpe.localPosition.z), controladorGolpe.localRotation);
            
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("State", (int)state);
    }

    private void Jump()     
    { 
        rb.AddForce(Vector2.up * JumpForce);
    }

    private bool isGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, JumpableGround);
    }
}
