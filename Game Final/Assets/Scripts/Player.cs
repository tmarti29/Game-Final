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
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float  horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        if(Input.GetKey(KeyCode.Space) && IsGrounded())
        {
            Jump();
        }
        if(horizontalInput > 0.01f)
        {
            transform.localScale = new Vector3(0.5f,1,0.02f);
        }
        else if (horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-0.5f, 1, 0.02f);
        }
        print(OnWall());
    }
    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, jumpPower);
        IsGrounded();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    private bool IsGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }
    private bool OnWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, groundLayer);
        return raycastHit.collider != null;
    }
}
