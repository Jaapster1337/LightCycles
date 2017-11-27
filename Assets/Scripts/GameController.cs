using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public KeyCode upKey;
	public KeyCode downKey;
	public KeyCode leftKey;
	public KeyCode rightKey;
	public Rigidbody2D rb2d;
	public float mSpeed = 12;
	//public float spawnTime = 100f;

	public GameObject wallPrefab;
	public GameObject otherPlayer;
	public GameObject powerUp;
	public GameObject[] powerUps;
	public Text gameOverText;
	public Text restartText;
	public Text quitText;
	public bool gameOver = false;
	public bool restart = false;
	public bool pause=false;

	//public Transform[] spawnPoints;



	// Use this for initialization
	void Start () {
		
		rb2d = GetComponent<Rigidbody2D>();
		rb2d.velocity = Vector2.up * mSpeed;
		gameOver = false;
		restart = false;
		gameOverText.text = "";
		restartText.text = "";
		quitText.text = "";
		InvokeRepeating("SpawnPowerUp", 10f, 10f);
		
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKey(KeyCode.Escape))
		{
			Application.Quit();
		}

		if(gameOver)
		{
			restartText.text = "Press any key for Restart";

			if(Input.anyKeyDown)
			{
				SceneManager.LoadScene("lightcycles");
				SceneManager.SetActiveScene(SceneManager.GetSceneByName("lightcycles"));
			}
		}
		else if(!pause)
		{

			SpawnWall();
			if(Input.GetKeyDown(upKey))
			{
				rb2d.velocity = Vector2.up * mSpeed;
				rb2d.MoveRotation(0);
			} 
			else if(Input.GetKeyDown(downKey))
			{
				rb2d.velocity = Vector2.down * mSpeed;
				rb2d.MoveRotation(180);
			} 
			else if(Input.GetKeyDown(rightKey))
			{
				rb2d.velocity = Vector2.right * mSpeed;
				rb2d.MoveRotation(270);

			} 
			else if(Input.GetKeyDown(leftKey))
			{
				rb2d.velocity = Vector2.left * mSpeed;
				rb2d.MoveRotation(90);
			}
		}
	}

	public void SpawnWall()
	{	
		GameObject g = GameObject.Instantiate(wallPrefab, transform.position, Quaternion.identity);
		Collider2D wall = g.GetComponent<Collider2D>();
	}

	public void GameOver()
	{
		gameOverText.text = "Game Over";
		restartText.text = "Press any key to restart!";
		quitText.text = "Esc to quit";
		rb2d.velocity = Vector2.zero;
		otherPlayer.GetComponent<GameController>().Pause();
		gameOver = true;
	}

	public void Pause()
	{
		pause = true;
		rb2d.velocity = Vector2.zero;
	}

	public void PowerUp()
	{
		mSpeed = mSpeed * 2;
	}

	public void SpawnPowerUp()
	{
		powerUps = GameObject.FindGameObjectsWithTag("Powerup"); 
		if(powerUps.Length < 1)
		{

			Vector2 position = new Vector2(Random.Range(-35.0f, 35.0f), Random.Range(-35.0f, 35.0f));
			Collider2D hit = Physics2D.OverlapPoint(position);
			if(hit == null)
				Instantiate(powerUp, position, transform.rotation);
			

		}

	}
}
