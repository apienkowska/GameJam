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
	[SerializeField] private GameObject playerObj;
	void Start()
    {
       rb=GetComponent<Rigidbody2D>();
	   anim=GetComponent<Animator>();
	   sprite=GetComponent<SpriteRenderer>();
	   coll=GetComponent<BoxCollider2D>();
	   
    }
	void Update(){
		anim.ResetTrigger("talk");
	}
	
	private void OnCollisionEnter2D(Collision2D collision)
	{
		anim.SetTrigger("talk");
	}
	
	private void OnTriggerEnter2D(Collider2D collision)
   {
	   if(collision.gameObject.CompareTag("Player"))
	   {
		   anim.SetTrigger("talk");
		   //Here add text
	   }
   }
	
}
