using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    private bool ballIsActive;
    private Vector3 ballPosition;
    private Vector2 ballInitialForce;
	
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
      if (Input.GetButtonDown ("Jump") == true) {
        if (!ballIsActive){
		  // применим силу 
		  //AddForce(ballInitialForce);
		  // зададим активное состояние
		  ballIsActive = !ballIsActive;
		}
         
      }  
    }
}
