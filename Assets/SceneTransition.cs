using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
	public string sceneToLoad;
	public Vector2 playerPosition;
	public VectorValue playerStorage;
	
	public void onTriggerEnter2D(Collider2D other)
	{
		Debug.Log("New sceneLoad");
		if(other.CompareTag("Player") && ! other.isTrigger)
		{
			playerStorage.initialValue=playerPosition;
			SceneManager.LoadScene(sceneToLoad);
		}
	}
	
}
