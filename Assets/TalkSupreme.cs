using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkSupreme : MonoBehaviour
{
	private Rigidbody2D rb;
	private BoxCollider2D coll;
	[SerializeField] public float talkRaidus;
	[SerializeField] Transform target;
	[SerializeField] public GameObject dialogBox;
	[SerializeField] public Text dialogText;
	private string dialog="Hello";
	[SerializeField] public bool playerInRange;
	private int num=0;
	[SerializeField] string[] DialogList={"You managed to flee from the Corrupter!",
"Amazing feat for a human!",
 "Thank you for retrieving the Seed! We are now one step closer to maintain the balance.",
 "The journey just began, there are plenty of more Seeds to be found and we cannot ensure the balance until all Seeds will be placed in their respective containers.",
 "We are forever in your debt, fellow human!" };
 

	void Start()
    {
       rb=GetComponent<Rigidbody2D>();
	   coll=GetComponent<BoxCollider2D>();
	   
    }
	void Update()
	{
		CheckDistance();
		
		if( playerInRange)
		{
				ChangeText();
				dialogBox.SetActive(true);
				dialogText.text=dialog;
		}
	}
	private void ChangeText()
	{
		
		dialog=DialogList[num];
		
		Debug.Log(dialog);
		Debug.Log(num);
		if (Input.GetKeyDown(KeyCode.Space))
		{
			num++;
		}
		if(num==DialogList.Length){
			dialogBox.SetActive(false);
			playerInRange=false;
			num=0;
		}else{
			
			dialogBox.SetActive(true);
			

		}
		dialogText.text=dialog;
	}
	private void CheckDistance()
	{

		if(Vector3.Distance(target.position, transform.position)<=talkRaidus){
			playerInRange=true;
			
			dialogBox.SetActive(true);
			dialogText.text=dialog;

			
		}
		else{
			playerInRange=false;
			dialogBox.SetActive(false);
		}
	}
}
