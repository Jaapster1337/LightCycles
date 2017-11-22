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
	public float mSpeed = 8;


	public GameObject wallPrefab;
	public Text gameOverText;
	public Text restartText;
	public bool gameOver = false;
	public bool restart = false;
	public bool pause=false;
	public GameObject otherPlayer;


	// Use this for initialization
	void Start () {
		
		rb2d = GetComponent<Rigidbody2D>();
		rb2d.velocity = Vector2.up * mSpeed;
		gameOver = false;
		restart = false;
		gameOverText.text = "";
		restartText.text = "";
		
	}
	
	// Update is called once per frame
	void Update () {

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

	void SpawnWall()
	{	
		GameObject g = GameObject.Instantiate(wallPrefab, transform.position, Quaternion.identity);
		Collider2D wall = g.GetComponent<Collider2D>();
	}

	public void GameOver()
	{
		gameOverText.text = "Game Over";
		restartText.text = "Press any key to restart!";
		rb2d.velocity = Vector2.zero;
		otherPlayer.GetComponent<GameController>().Pause();
		gameOver = true;
	}

	public void Pause()
	{
		pause = true;
		rb2d.velocity = Vector2.zero;
	}
}
