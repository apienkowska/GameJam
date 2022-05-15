using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Talk : MonoBehaviour
{
	private enum MovementState 
	{
		idle, talk
	}
	private Rigidbody2D rb;
	private SpriteRenderer sprite;
	private BoxCollider2D coll;
	private Animator anim;
	[SerializeField] public float talkRaidus;
	[SerializeField] Transform target;
	[SerializeField] public GameObject dialogBox;
	[SerializeField] public Text dialogText;
	private string dialog;
	[SerializeField] public bool dialogActive;
	private float TimeChangeText=0.005f;
	private float TimerText=0.0f;
	private int num=0;
	string[] DialogList={"...mmhhmm !!!", 
		" I know you! / I don’t recognize you!", 
		"Pinch me! Could this be a dream?",
		"So tired! Can’t wait to get some sleep!" };
	void Start()
    {
       rb=GetComponent<Rigidbody2D>();
	   anim=GetComponent<Animator>();
	   sprite=GetComponent<SpriteRenderer>();
	   coll=GetComponent<BoxCollider2D>();
	   
    }
	void Update(){
		
			TimerText+=Time.deltaTime;
			if (dialogBox.activeInHierarchy)
			{
				dialogBox.SetActive(false);
			}
			else{
				dialogText.text = dialog;
				dialogBox.SetActive(true);
			}
		CheckDistance();
	}
	

	int RandomAtMoment()
	{
		if (TimerText>TimeChangeText)
		{
			return num;
		}
		else
		{
			return new System.Random().Next(DialogList.Length);
		}
	}
	void CheckDistance()
	{
		if(Vector3.Distance(target.position, transform.position)<=talkRaidus){
			anim.SetTrigger("talk");
			dialogActive=true;
			dialogBox.SetActive(true);
			num=RandomAtMoment();
			dialogText.text =DialogList[num];
		}
		else{
			anim.ResetTrigger("talk");
			dialogBox.SetActive(false);
			dialogActive=false;
			if(TimeChangeText<TimerText) {
				TimerText=0.0f;
			}
		}
	}
}
