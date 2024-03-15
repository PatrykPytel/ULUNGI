
using UnityEngine;

public class movement : MonoBehaviour
{
    private Rigidbody2D body;
    public float speed;
    public float jumpPower;
    private Animator anim;
    private BoxCollider2D boxCollider;
    public LayerMask groundLayer;
    public LayerMask wallLayer;
    private float wallJumpCooldown;
    private float horizontalInput;
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();

    }
    private void Update()
    {
        
        horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput > 0.01f)
        {
            FindObjectOfType<AudioManager>().Play("chodzenie");
            transform.localScale = new Vector3(8, 8, 1);
            
        }
        else
        {
            if(horizontalInput < -0.01f)
            {
                FindObjectOfType<AudioManager>().Play("chodzenie");
                transform.localScale = new Vector3(-8, 8, 1);
                
            }
        }
        anim.SetBool("run", horizontalInput != 0);
        anim.SetBool("grounded", isGrounded());
        
        if(wallJumpCooldown  > 0.2f)
        {
            FindObjectOfType<AudioManager>().Play("skok");
            body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);
            if (onWall() && !isGrounded())
            {
                body.gravityScale = 0;
                body.velocity = Vector2.zero;
            }
            else
                body.gravityScale = 3;
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
        if (isGrounded())
        {
            FindObjectOfType<AudioManager>().Play("skok");
            body.velocity = new Vector2(body.velocity.x, jumpPower);
            anim.SetTrigger("jump");
        }
        else if(onWall()&&!isGrounded())
        {
            if(horizontalInput==0)
            {
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 10, 0);
                transform.localScale = new Vector3(-Mathf.Sign(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            else
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 3, 6);
            wallJumpCooldown = 0;
        }
    }
    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }
    private bool onWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, wallLayer);
        return raycastHit.collider != null;
    }
}
