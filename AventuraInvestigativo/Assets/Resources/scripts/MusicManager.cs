using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {

	AudioSource[] asources;
	public AudioClip[] musics;
	public AudioClip[] sounds;


	// Use this for initialization
	void Start () {
		asources = GetComponents<AudioSource>();
		//asources[0].clip = musics [0];
		//asources[0].Play ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void playnew(int n)
	{
		asources[0].Stop();
		asources[0].clip = musics [n];
		asources[0].Play();
	}

	public void loadsound(int n)
	{
		asources [1].Stop ();
		asources [1].clip = sounds [n];
	}
	public void playsound()
	{
		asources [1].Stop ();
		asources [1].Play ();
	}
}
