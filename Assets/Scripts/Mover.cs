using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

	public KeyCode upKey;
	public KeyCode downKey;
	public KeyCode leftKey;
	public KeyCode rightKey;
	public Rigidbody2D rb2d;
	public float mSpeed = 32;
	PlayerController pc;

	// Use this for initialization
	void Start () {
		pc = gameObject.GetComponent<PlayerController>();
		rb2d = GetComponent<Rigidbody2D>();
		rb2d.velocity = Vector2.down * mSpeed;
	}
	
	// Update is called once per frame
	public void Move() {
		pc.SpawnWall();
		if(Input.GetKeyDown(upKey))
		{
			rb2d.velocity = Vector2.up * mSpeed;
			rb2d.MoveRotation(0);
		} 
		else if(Input.GetKeyDown(leftKey))
		{
			rb2d.velocity = Vector2.left * mSpeed;
			rb2d.MoveRotation(90);
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

	}

	public void SetAtOppositeBoundary(float rotation)  //x y z /y = vertical /x = horizontal
	{
		if(transform.localEulerAngles.z == 0)//if direction up
		{
			transform.position = new Vector3(transform.position.x,-80.0f,0.0f);//keep x set y
			transform.Translate(Vector2.up * mSpeed);//give speed with direction
		} 
		if(transform.localEulerAngles.z == 90)//if direction left
		{
			transform.position = new Vector3(64.0f,transform.position.y + 16.0f,0.0f);//set x keep y
			transform.Translate(Vector2.left * mSpeed);//give speed with direction
		}
		if(transform.localEulerAngles.z == 180)//direction down
		{
			transform.position = new Vector3(transform.position.x,48.0f,0.0f);//keep x set y
			transform.Translate(Vector2.down * mSpeed);//give speed with direction);
		}
		if(transform.localEulerAngles.z == 270)//direction right
		{
			transform.position = new Vector3(-64.0f,transform.position.y + 16.0f,0.0f);//set x keep y
			transform.Translate(Vector2.right * mSpeed);//give speed with direction
		}
}
}
