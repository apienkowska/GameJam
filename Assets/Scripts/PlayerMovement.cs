using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	private Rigidbody2D rb;
	private SpriteRenderer sprite;
	private BoxCollider2D coll;
	private Animator anim;
	private float dirX=0f;
	private float dirY=0f;
	[SerializeField] public float moveSpeed=7f; //change to public if i want to change it from other scripts
	[SerializeField] private LayerMask jumpableGround;
	private enum MovementState 
	{
		idle, running, up, down
	}
    // Start is called before the first frame update
    void Start()
    {
       rb=GetComponent<Rigidbody2D>();
	   anim=GetComponent<Animator>();
	   sprite=GetComponent<SpriteRenderer>();
	   coll=GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
		dirX=Input.GetAxisRaw("Horizontal");
		dirY=Input.GetAxis("Vertical");
		rb.velocity=new Vector2(dirX*moveSpeed,dirY*moveSpeed);
		
		UpdateAnimationState();
		if (Input.GetKeyDown(KeyCode.Escape)){
			Application.Quit();
		}
		
    }
	private void UpdateAnimationState()
	{
		MovementState state;
		if (dirX>0f)
		{
			state=MovementState.running;
			sprite.flipX = false;
		}
		else if (dirX<0f)
		{
			state=MovementState.running;
			sprite.flipX = true;
		}
		else if (dirY<0f)
		{
			state=MovementState.running;
			sprite.flipX = false;
		}
		else if (dirY>0f)
		{
			state=MovementState.running;
			sprite.flipX = false;
		}
		else
		{
			state=MovementState.idle;
		}
		if (rb.velocity.y > .1f )
		{
			state=MovementState.up;
		}
		else if(rb.velocity.y < -.1f)
		{
			state=MovementState.down;
		}
		anim.SetInteger("state",(int)state);
	}
	

}
