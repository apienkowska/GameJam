using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
	private int items = 0;
	[SerializeField] private Text collectiblesText;
	[SerializeField] private AudioSource sound;
   private void OnTriggerEnter2D(Collider2D collision)
   {
	   if(collision.gameObject.CompareTag("Items"))
	   {
		   Destroy(collision.gameObject);
		   items++;
		   Debug.Log("Items: "+items);
		   collectiblesText.text="Crystals: "+items;
		   sound.Play();
		   
	   }
   }
}
