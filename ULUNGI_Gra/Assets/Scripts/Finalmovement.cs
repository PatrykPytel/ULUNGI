using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Finalmovement : MonoBehaviour
{
    public float m_JumpForce = 20f;
	public float startjumpforce = 20f;
	public float slowedjumpforce = 40f;// Amount of force added when the player jumps.
	//[SerializeField] private bool m_AirControl = false;							// Whether or not a player can steer while jumping;
	[SerializeField] private LayerMask m_WhatIsGround;							// A mask determining what is ground to the character
	[SerializeField] private Transform m_GroundCheck;	
	[SerializeField] private Transform wallCheck;
	[SerializeField] private LayerMask wallLayer;	
	[SerializeField] public Rigidbody2D rb;		
	[SerializeField] public GameObject player;			// A position marking where to check if the player is grounded.
	const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
	public bool m_Grounded;            // Whether or not the player is grounded.
	private bool m_FacingRight = true;  // For determining which way the player is currently facing.
	//private Vector3 m_Velocity = Vector3.zero;
	public Animator animator;

    public float runSpeed;
    float  horizontalMove;
	private float slidingspeed = 2f;
	private bool isWallSliding;
	private bool isWallJumping;
	private float wallJumpingDirection;
	private float wallJumpingTime =0.2f;
	private float wallJumpingCounter;
	private float wallJumpingDuration = 0.4f;
	private Vector2 wallJumpingPower = new Vector2(8f, 16f);
	private bool noconstrains = true;
	public int playerscale=1;

    //bool jump= false;

    public float dashtime=0.5f;

    public float cooldown;
    private float timepassed;

    public float mnoznikspeed;
    public float startspeed;
	public float doublespeed;

    // Start is called before the first frame update
    [Header("Events")]
	[Space]

	public UnityEvent OnLandEvent;
	private void Awake()
	{

		if (OnLandEvent == null)
			OnLandEvent = new UnityEvent();
	}

    private void FixedUpdate()
	{
       // Move(horizontalMove * Time.fixedDeltaTime, jump);
	   rb.velocity = new Vector2(horizontalMove * runSpeed, rb.velocity.y);
       // jump= false;

		bool wasGrounded = m_Grounded;
		m_Grounded = false;
		Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);	// The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
		for (int i = 0; i < colliders.Length; i++) // This can be done using layers instead but Sample Assets will not overwrite your project settings.
		{
			if (colliders[i].gameObject != gameObject)
			{
				m_Grounded = true;
				if (!wasGrounded)
					OnLandEvent.Invoke();
			}
		}
		if (m_Grounded){
			animator.SetBool("onfloor", true);
		}
		else {
			animator.SetBool("onfloor", false);
		}
	}
    private void Flip()
	{
		if(m_FacingRight &&  horizontalMove <0f ||!m_FacingRight && horizontalMove > 0f) {
			m_FacingRight = !m_FacingRight; 		// Switch the way the player is labelled as facing.
			Vector3 theScale = player.transform.localScale;  	// Multiply the player's x local scale by -1.
			theScale.x *= -1;
			playerscale *= -1;
			player.transform.localScale = theScale;			
		}
	}
    void stopdash()
    {
        runSpeed = runSpeed/mnoznikspeed;
        animator.SetBool("Isdashing", false);
 //       animator.SetBool("IsJumping",true);

    }
    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }
    void Start()
    {
        startspeed = runSpeed;
		doublespeed = runSpeed * 2;
    }

    // Update is called once per frame
    void Update()
    {
		if(DialogMenadzer.isActive == true) { 
			return;
		}
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        horizontalMove = Input.GetAxisRaw("Horizontal");
        if(Input.GetButtonDown("Jump") && m_Grounded && noconstrains == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, m_JumpForce);
            animator.SetBool("IsJumping",true);
        } 
		if (Input.GetButtonUp("Jump") && rb.velocity.y >0f) { 
			rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
		}
        if (timepassed <= 0) {  
            if(Input.GetKeyDown(KeyCode.LeftShift))
            {
                timepassed =cooldown;
                animator.SetBool("Isdashing", true);
                animator.SetBool("IsJumping", false);
                runSpeed = runSpeed * mnoznikspeed;
            	Invoke("stopdash", dashtime);   
            } 
        }
        else { 
            timepassed -= Time.deltaTime;
        }
		WallSlide();
		WallJump();
		if (!isWallJumping && noconstrains == true) { 
			Flip();
		}
		
        
    }
	private bool IsWalled() { 
		return Physics2D.OverlapCircle(wallCheck.position, 0.2f, wallLayer);
	}
	private void WallSlide() {
		isWallSliding = true;
		if (IsWalled() && !m_Grounded && horizontalMove != 0f) { 
		rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -slidingspeed, float.MaxValue));
		}else { 
			isWallSliding= false;
		}
	}
	private void WallJump() { 
		if ( isWallSliding) { 
			isWallJumping = false;
			wallJumpingDirection = -transform.localScale.x;
			wallJumpingCounter = wallJumpingTime;
			CancelInvoke(nameof(StopWallJumping));
		} else { 
			wallJumpingCounter -= Time.deltaTime;
		}
		if (Input.GetButtonDown("Jump") && wallJumpingCounter> 0f) { 
			isWallJumping = true;
			rb.velocity = new Vector2(wallJumpingDirection * wallJumpingPower.x, wallJumpingPower.y);
			wallJumpingCounter = 0f;

			if(transform.localScale.x != wallJumpingDirection) { 
				m_FacingRight = !m_FacingRight;
				Vector3 localScale = transform.localScale;
				localScale.x *= -1f;
				transform.localScale = localScale;
			}
			Invoke(nameof(StopWallJumping), wallJumpingDuration);
		}
	}
	private void StopWallJumping() { 
		isWallJumping = false;
	}
	public void Stopmoving() { 
//		runSpeed = 0f;
//		m_JumpForce = 0f;
//		animator.SetBool("IsJumping", false);
		rb.constraints = RigidbodyConstraints2D.FreezeAll;
		noconstrains = false;
	}
	public void Startmoving() { 
		rb.constraints = RigidbodyConstraints2D.None;
		rb.constraints = RigidbodyConstraints2D.FreezeRotation;
	 	noconstrains = true;
	}
}
