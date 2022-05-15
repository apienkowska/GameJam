using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerLife : MonoBehaviour
{
	private Animator anim;
	private Rigidbody2D rb;
	[SerializeField] private int LifeLevel = 50;
	[SerializeField] private Text LifeText;
	SpriteRenderer PlayerSprite;
	public bool startFading = false;
	private Color baseColor;
	[SerializeField] private Color blinkColor1;
	[SerializeField] private Color blinkColor2;
	[SerializeField] private float blinkTime=0.1f;
	private float blinkTimer=0.0f;
	// Start is called before the first frame update
	void Start()
	{
		anim = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();
		PlayerSprite = GetComponent<SpriteRenderer>();
		baseColor = PlayerSprite.color;
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Trap") && LifeLevel <= 5)
		{
			Die();
		}
		else if (collision.gameObject.CompareTag("Trap"))
		{
			LifeLevel = LifeLevel - 5;
			LifeText.text = "Life: " + LifeLevel;
			startFading = true;
			PlayerSprite.color=blinkColor1;
		}
	}
	
	private void Update()
	{
		
		if (startFading && blinkTimer<=blinkTime )
		{
			blinkTimer=blinkTimer+Time.deltaTime;
			PlayerSprite.color=blinkColor1;
		}
		else{
			blinkTimer=0.0f;
			PlayerSprite.color=baseColor;
			startFading=false;
		}
	}

	private void Die()
	{
		rb.bodyType = RigidbodyType2D.Static;
		anim.SetTrigger("death");
		if (SceneManager.GetActiveScene().name == "Corrupted"){
			SceneManager.LoadScene("End");
		}
		else{
		SceneManager.LoadScene("Corrupted");
		}
	}

	private void RestartLevel()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

}