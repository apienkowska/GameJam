using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
	private int items = 0;
	[SerializeField] private Text collectiblesText;
	
	[SerializeField] private AudioSource sound;
	[SerializeField] private GameObject NPC;
	[SerializeField] private GameObject NPC2;
	[SerializeField] private GameObject NPC3;
	[SerializeField] private GameObject NPC4;
	[SerializeField] private GameObject NPC5;
	[SerializeField] private GameObject NPC6;
	[SerializeField] private GameObject world;
	[SerializeField] private Sprite corrupted;
	
	[SerializeField] private Text objective;
	
	[SerializeField] private GameObject[] basic;

	
   private void OnTriggerEnter2D(Collider2D collision)
   {
	   if(collision.gameObject.CompareTag("Items"))
	   {
		   Destroy(collision.gameObject);
		   items++;
		   Debug.Log("Items: "+items);
		   collectiblesText.text="Crystals: "+items;
		   sound.Play();
		   NPC.SetActive(true);
		   NPC2.SetActive(true);
		   NPC3.SetActive(true);
		   NPC4.SetActive(true);
		   NPC5.SetActive(true);
		   NPC6.SetActive(true);
		   for (int i = 0; i<basic.Length; i++){
			   basic[i].SetActive(false);
			   
		   }
		   ChangeGraphics();
		   
	   }
   }
   
   public void ChangeGraphics(){
	   world.GetComponent<SpriteRenderer>().sprite = corrupted;
	   objective.text="Find the Super and deliver the Crystal";
   }
   
}
