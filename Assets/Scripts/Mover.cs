//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//
//public class Mover : MonoBehaviour {
//
//	public KeyCode upKey;
//	public KeyCode downKey;
//	public KeyCode leftKey;
//	public KeyCode rightKey;
//	public Rigidbody2D rb2d;
//	public float mSpeed = 32;
//
//	// Use this for initialization
//	void Start () {
//		
//	}
//	
//	// Update is called once per frame
//	void Update () {
//		
//		if(Input.GetKeyDown(upKey))
//		{
//			rb2d.velocity = Vector2.up * mSpeed;
//			rb2d.MoveRotation(0);
//		} 
//		else if(Input.GetKeyDown(leftKey))
//		{
//			rb2d.velocity = Vector2.left * mSpeed;
//			rb2d.MoveRotation(90);
//		}
//		else if(Input.GetKeyDown(downKey))
//		{
//			rb2d.velocity = Vector2.down * mSpeed;
//			rb2d.MoveRotation(180);
//		} 
//		else if(Input.GetKeyDown(rightKey))
//		{
//			rb2d.velocity = Vector2.right * mSpeed;
//			rb2d.MoveRotation(270);
//		} 
//
//	}
//}
