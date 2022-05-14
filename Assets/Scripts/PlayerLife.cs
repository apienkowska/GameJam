using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerLife : MonoBehaviour
{
	private Animator anim;
	private Rigidbody2D rb;
	[SerializeField] private int LifeLevel=100;
	[SerializeField] private Text LifeText;
	SpriteRenderer PlayerSprite;
 public float spriteBlinkingTimer = 0.0f;
 public float spriteBlinkingMiniDuration = 0.1f;
 public float spriteBlinkingTotalTimer = 0.0f;
 public float spriteBlinkingTotalDuration = 1.0f;
 public bool startBlinking = false;
 private Color baseColor;
    // Start is called before the first frame update
    void Start()
    {
        anim=GetComponent<Animator>();
		rb=GetComponent<Rigidbody2D>();
		PlayerSprite=GetComponent<SpriteRenderer>();
		baseColor=PlayerSprite.color;
    }
	
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Trap") && LifeLevel <=5 )
		{
			Die();
		}
		else if (collision.gameObject.CompareTag("Trap")){
			LifeLevel=LifeLevel-5;
			LifeText.text="Life: "+LifeLevel;
			SpriteBlinkingEffect();
		}
	}
	
	private void Die()
	{
		rb.bodyType=RigidbodyType2D.Static;
		anim.SetTrigger("death");
	}
	
	private void RestartLevel()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
	
	private void SpriteBlinkingEffect()
      {
        spriteBlinkingTotalTimer += Time.deltaTime;
        if(spriteBlinkingTotalTimer >= spriteBlinkingTotalDuration)
        {
              startBlinking = false;
             spriteBlinkingTotalTimer = 0.0f;
             PlayerSprite.enabled = true;   
			 
             return;
          }
     
     spriteBlinkingTimer += Time.deltaTime;
     if(spriteBlinkingTimer >= spriteBlinkingMiniDuration)
     {
         spriteBlinkingTimer = 0.0f;
         if (PlayerSprite.enabled == true) {
             PlayerSprite.enabled = false;  //make changes
			 PlayerSprite.color = new Color (1, 0, 0, 1);
         } else {
             PlayerSprite.enabled = true;   //make changes
			 PlayerSprite.color = new Color (1, 0, 0, 0);
			 
         }
     }
	  PlayerSprite.color = baseColor;
	}
}