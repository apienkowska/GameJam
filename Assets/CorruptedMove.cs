using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
	[SerializeField] public Text dialogText;
	[SerializeField] public GameObject dialogBox;
	private string dialog;
	[SerializeField] public bool dialogActive;
	private int num=0;
	private float TimeChangeText=0.05f;
	private float TimerText=0.0f;
	string[] DialogListCorrupted={
		"What you are looking for doesn’t exist! It is just an illusion, not even a fragment of what the truth is!",
"All lies spoken by halfwits in order to pursue a hopeless and selfish dream.",
 "What truly matters is to never sleep again!",
 "Come join me in the process!"
	};

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
	   dialogText.text=DialogListCorrupted[num];
    }

    // Update is called once per frame
    void Update()
    {
		TimerText+=Time.deltaTime;
        
		if (dialogActive){
			ShowDialog(true);
			num=RandomAtMoment();
			dialog=DialogListCorrupted[num];
			dialogText.text =dialog;
			
			Debug.Log(dialog);
		}else
		{
			ShowDialog(false);
			//Debug.Log("Hide1");
		}
		CheckDistance();
		UpdateAnimationState();
    }
	
	void CheckDistance()
	{
		if(Vector3.Distance(target.position, transform.position)<=chaseRaidus && Vector3.Distance(target.position, transform.position)>attackRaidus){
			transform.position = Vector3.MoveTowards(transform.position,target.position,moveSpeed*Time.deltaTime);
			dirX=transform.position.x;
			dirY=transform.position.y;
			num=RandomAtMoment();
			dialog=DialogListCorrupted[num];
			dialogText.text =dialog;
			Debug.Log(dialog);
			ShowDialog(true);

		}
		else{
			ShowDialog(false);
			
			if(TimeChangeText<TimerText) {
				TimerText=0.0f;
			}
		}
	}
	
	int RandomAtMoment()
	{
		
		if (TimerText>TimeChangeText)
		{
			return num;
		}
		else
		{
			
			return new System.Random().Next(DialogListCorrupted.Length);
		}
	}
	
	private void ShowDialog(bool value)
	{
		dialogBox.SetActive(value);
		dialogActive=value;
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
