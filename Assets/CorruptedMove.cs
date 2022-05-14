using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorruptedMove : MonoBehaviour
{
   private Rigidbody2D rb;
	private SpriteRenderer sprite;
	private BoxCollider2D coll;
	private Animator anim;
	private float dirX=0f;
	private float dirY=0f;
	[SerializeField] private float moveSpeed=7f; //change to public if i want to change it from other scripts
	[SerializeField] private LayerMask jumpableGround;
	[SerializeField] public int baseAttack;
	[SerializeField] Transform target;
	[SerializeField] public float chaseRaidus;
	[SerializeField] public float attackRaidus;
	private enum MovementState 
	{
		idle, running, up, down
	}
	public Transform homePosition;
    // Start is called before the first frame update
    void Start()
    {
       rb=GetComponent<Rigidbody2D>();
	   anim=GetComponent<Animator>();
	   sprite=GetComponent<SpriteRenderer>();
	   coll=GetComponent<BoxCollider2D>();
	   target=GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        CheckDistance();
		UpdateAnimationState();
    }
	
	void CheckDistance()
	{
		if(Vector3.Distance(target.position, transform.position)<=chaseRaidus && Vector3.Distance(target.position, transform.position)>attackRaidus){
			transform.position = Vector3.MoveTowards(transform.position,target.position,moveSpeed*Time.deltaTime);
			dirX=transform.position.x;
			dirY=transform.position.y;
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
