using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {

	AudioSource[] asources;
	public AudioClip[] musics;
	public AudioClip[] sounds;
	public AudioClip[] ambient;
	private int current_music;
	private int current_anbient;

	// Use this for initialization
	void Start () {
		asources = GetComponents<AudioSource>();
		//asources[0].clip = musics [0];
		//asources[0].Play ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public int Music {
		get {
			return current_music;
		}
	}

	public int Anbient {
		get {
			return current_anbient;
		}
	}

	public void playnew(int n)
	{
		asources[0].Stop();
		asources[0].clip = musics [n];
		asources[0].Play();
		current_music = n;
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

	public void playambient(int n)
	{
		asources[2].Stop();
		asources[2].clip = ambient [n];
		asources[2].Play();
		current_anbient = n;
	}
}
