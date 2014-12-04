using UnityEngine;
using System.Collections;

public class DoorScript : MonoBehaviour {

	public string goto_cene = "next";
	public string spawn_point = "spawn";
	public bool left = false;
	public bool right = false;
	public bool up = false;
	public bool down = false;
	public bool FadeEffect = false;

	private bool isfadingout;
	private bool isfadingin;

	private GameController gm;
	// Use this for initialization
	void Start () {
		GameObject g = GameObject.FindGameObjectWithTag("GameManager");
		gm = (GameController) g.GetComponent(typeof(GameController));
		isfadingout = false;
		isfadingin = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (isfadingout) {
			if (gm.FadeToBlack()) {
				this.gameObject.GetComponent<PolygonCollider2D>().enabled = false;
				if (left||right||up||down) {
					int dirX = 0;
					int dirY = 0;
					if (left) {
						dirX = -1;
					}
					else if (right) {
						dirX = 1;
					}
					if (down) {
						dirY = -1;
					}
					else if (up) {
						dirY = 1;
					}
					gm.TransiteScene(goto_cene, spawn_point, dirX, dirY, this.gameObject);
				}
				else {
					gm.TransiteScene(goto_cene, spawn_point, this.gameObject);
				}
				isfadingout = false;
				isfadingin = true;
			}
		}
		if (isfadingin) {
			if (gm.FadeToClear()) {
				isfadingin = false;
				gm.unlockplayer();
				DestroyObject(this.gameObject);
			}
		}
	}

	void OnTriggerEnter2D (Collider2D c) {
		if (c.gameObject.CompareTag("Player")) {
			transite();
		}
	}

	void transite() {
		if (FadeEffect) {
			gm.lockplayer();
			isfadingout = true;
		}
		else {
			if (left||right||up||down) {
				int dirX = 0;
				int dirY = 0;
				if (left) {
					dirX = -1;
				}
				else if (right) {
					dirX = 1;
				}
				if (down) {
					dirY = -1;
				}
				else if (up) {
					dirY = 1;
				}
				gm.TransiteScene(goto_cene, spawn_point, dirX, dirY);
			}
			else {
				gm.TransiteScene(goto_cene, spawn_point);
			}
		}
	}


}
