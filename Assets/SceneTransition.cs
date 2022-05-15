using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
	public string sceneToLoad;
	
	public void onTriggerEnter2D(Collider2D other)
	{
		Debug.Log("New sceneLoad");
		if(other.CompareTag("Player") && ! other.isTrigger)
		{
			SceneManager.LoadScene(sceneToLoad);
		}
	}
	
}
