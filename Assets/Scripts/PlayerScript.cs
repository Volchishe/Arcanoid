using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float playerVelocity;
	public float boundary;
    private Vector3 playerPosition;
	
	// Start is called before the first frame update
    void Start()
    {
      // получаем начальную позицию платформы
	  playerPosition = gameObject.transform.position;
	  
    }

    // Update is called once per frame
    void Update()
    {
      // делаем горизонтальное движение
      playerPosition.x += Input.GetAxis ("Horizontal") * playerVelocity;
 
      // отрабатываем выход из игры
      if (Input.GetKeyDown(KeyCode.Escape)){
        Application.Quit();
      }
 
      // обновим позицию платформы
      transform.position = playerPosition;  
	  
	  // проверяем на выход за границы
      if (playerPosition.x < -boundary) {
        transform.position = new Vector3 (-boundary, playerPosition.y, playerPosition.z);
      } 
      if (playerPosition.x > boundary) {
        transform.position = new Vector3(boundary, playerPosition.y, playerPosition.z);     
      }

    }
}
