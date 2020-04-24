using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
  public float playerVelocity;
	public float boundary;
  private Vector3 playerPosition;
	private int pLives;
  private int pPoints;
	public AudioClip pointSound;
  public AudioClip lifeSound;
	
	// Start is called before the first frame update
  void Start()
  {
	  pLives = 3;
	  pPoints = 0;
  }

  // Update is called once per frame
  void Update()
  {
	  // получаем начальную позицию платформы
	  playerPosition = gameObject.transform.position;
    // делаем горизонтальное движение
    playerPosition.x += Input.GetAxis ("Horizontal") * playerVelocity;
    // отрабатываем выход из игры
    if (Input.GetKeyDown(KeyCode.Escape))
		{
      Application.Quit();
    }
    // обновим позицию платформы
    transform.position = playerPosition;  
	  // проверяем на выход за границы
    if (playerPosition.x < -boundary) 
		{
      transform.position = new Vector3 (-boundary, playerPosition.y, playerPosition.z);
    } 
    if (playerPosition.x > boundary) 
		{
      transform.position = new Vector3(boundary, playerPosition.y, playerPosition.z);     
    }
		//проверка состояния игры
	  WinLose();
  }
	void addPoints(int points)
	{
    pPoints += points;
		GetComponent<AudioSource>().PlayOneShot(pointSound);
  }
	void OnGUI()
	{
    GUI.Label(new Rect(5.0f,3.0f,200.0f,200.0f),"Жизни: " + pLives + "  Счет: " + pPoints);
  }
	void TakeLife()
	{
    pLives--;
    GetComponent<AudioSource>().PlayOneShot(lifeSound);
  }
	void WinLose()
	{
    // перезапускаем уровень
    if (pLives == 0) 
		{
		  Application.LoadLevel("Level1");        
    }
		// все блоки уничтожены
    if ((GameObject.FindGameObjectsWithTag ("Brick")).Length == 0) 
		{
      // проверяем текущий уровень
      if (Application.loadedLevelName == "Level1") 
			{
            Application.LoadLevel("Level2");
      } 
			else 
			{
        Application.Quit();
      }
    }
  }
}
