using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogs : MonoBehaviour
{
	[SerializeField] public GameObject dialogBox;
	[SerializeField] public Text dialogText;
	[SerializeField] public string dialog;
	[SerializeField] public bool dialogActive;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	void onTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			Debug.Log("Player in range");
		}
	}
	
	void onTriggerExit2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			Debug.Log("Player left range");
		}
	}
}
