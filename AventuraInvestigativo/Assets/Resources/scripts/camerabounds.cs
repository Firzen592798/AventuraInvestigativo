using UnityEngine;
using System.Collections;

public class camerabounds : MonoBehaviour {

	GameController gm;
	// Use this for initialization
	void Start () {
		GameObject g = GameObject.FindGameObjectWithTag("GameManager");
		gm = (GameController) g.GetComponent(typeof(GameController));
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			gm.camLock (true);
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			gm.camLock (false);
		}
	}
}
