using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(AudioSource))]

public class SoundController : MonoBehaviour {

	private AudioClip deathSound;

	// Use this for initialization
	void Start () {
		deathSound = GetComponent<AudioClip>();

	}

	public void PlaySound(AudioClip clip, Transform position)
	{
		AudioSource.PlayClipAtPoint(deathSound,transform.position);
	}
}
