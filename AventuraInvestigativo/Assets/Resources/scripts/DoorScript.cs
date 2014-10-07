using UnityEngine;
using System.Collections;

public class DoorScript : MonoBehaviour {

	public string goto_cene = "next";
	public string spawn_point = "spawn";

	GameController gm;
	// Use this for initialization
	void Start () {
		GameObject g = GameObject.FindGameObjectWithTag("GameManager");
		gm = (GameController) g.GetComponent(typeof(GameController));
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D c) {
		if (c.gameObject.CompareTag("Player")) {
			transite();
		}
	}

	void transite() {
		gm.TransiteScene(goto_cene, spawn_point);
	}


}
