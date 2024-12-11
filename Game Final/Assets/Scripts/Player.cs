using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D body;
    private BoxCollider2D boxCollider;
    public LayerMask groundLayer;
    public float speed = 5;
    public float jumpPower = 5;
    public float wallJumpCooldown;
    public float horizontalInput;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        
        if(horizontalInput > 0.01f)
        {
            transform.localScale = new Vector3(0.5f,1,0.02f);
        }
        else if (horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-0.5f, 1, 0.02f);
        }
        if(wallJumpCooldown > 0.2f)
        {
            body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

            
            if(OnWall() && !IsGrounded())
            {
                body.gravityScale = 0;
                body.velocity = Vector2.zero;
            }
            else
            {
                body.gravityScale = 1.7f;
            }
            if (Input.GetKey(KeyCode.Space))
            {
                Jump();
            }
        }
        else
        {
            wallJumpCooldown += Time.deltaTime;
        }
    }
    private void Jump()
    {
        if(IsGrounded())
        {
            body.velocity = new Vector2(body.velocity.x, jumpPower);
            IsGrounded();
        }
        else if(OnWall() && !IsGrounded())
        {
            if(horizontalInput == 0)
            {
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 7, 4);
            }
            else
            {
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 4, 6);
            }
            wallJumpCooldown = 0;
            
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    private bool IsGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.05f, groundLayer);
        return raycastHit.collider != null;
    }
    private bool OnWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.05f, groundLayer);
        return raycastHit.collider != null;
    }
}
