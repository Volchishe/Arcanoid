using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickScript : MonoBehaviour
{
  public int HP;
  public int points;
  private int numberOfHits;
	
	// Start is called before the first frame update
  void Start()
  {
    numberOfHits = 0;
  }
  
	// Update is called once per frame
  void Update()
  {
  
	}
		
	void OnCollisionEnter2D(Collision2D collision)
	{
    if (collision.gameObject.tag == "Ball")
		{
			numberOfHits++;
      if (numberOfHits == HP)
			{
        // получим ссылку на платформу
        GameObject player = GameObject.FindGameObjectsWithTag("Player")[0];
        // выполняем метод из PlayerScript
        player.SendMessage("addPoints", points);
				// уничтожаем объект
        Destroy(this.gameObject);
      }
    }
  }
}
