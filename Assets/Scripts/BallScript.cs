using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
  private bool ballIsActive;
  private Vector3 ballPosition;
  private Vector2 ballInitialForce;
	public GameObject playerObject;
	public AudioClip hitSound;
	
	// Start is called before the first frame update
  void Start()
  {
    // создаем силу, которая будет действовать на шарик
	  ballInitialForce = new Vector2 (100.0f,300.0f);
    // переводим шарик в неактивное состояние
    ballIsActive = false;
    // запоминаем положение
    ballPosition = transform.position;  
  }
  // Update is called once per frame
  void Update()
  {
    if (ballIsActive && transform.position.y < -6) 
  	{
      // вернем шарик на место и в неактивное состояние
			ballIsActive = !ballIsActive;
      ballPosition.x = playerObject.transform.position.x;
      ballPosition.y = -3.9f;
      transform.position = ballPosition;
	    GetComponent<Rigidbody2D>().isKinematic = true;
  		//Уменьшаем количество жизней
			playerObject.SendMessage("TakeLife");
    }
    if (!ballIsActive && playerObject != null)
		{
      // зададим новую позицию шарика
      ballPosition.x = playerObject.transform.position.x; 
      // устанавливим позицию шарика, соответствующую позиции платформы
      transform.position = ballPosition;
    } 
    if (Input.GetButtonDown ("Jump") == true) 
		{
      if (!ballIsActive)
			{
	      // применим силу к шарику
	      GetComponent<Rigidbody2D>().AddForce(ballInitialForce);
	      // зададим активное состояние шарика
	      ballIsActive = !ballIsActive;
	      // сброс всех сил
	      GetComponent<Rigidbody2D>().isKinematic = false;
    	}
    }  
  }
	void OnCollisionEnter2D(Collision2D collision)
	{
    if (ballIsActive)
	  { 
      GetComponent<AudioSource>().PlayOneShot(hitSound);
    }
  }
}
