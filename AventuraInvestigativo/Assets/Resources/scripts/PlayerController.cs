using UnityEngine;
using System.Collections;

public class PlayerController : ObjectController {

	public float maxspeedX = 8f;
	public float maxspeedY = 4f;
	//public Animator ani;
	
	//private float dirX;
	//private float dirY;
	private string actual_spawn = "initial_spot";

	bool playlock;
	bool npc_behaviour;

	bool waiting;

	float elapsed_time;
	// Use this for initialization

	void Start () {

		nome = "Player";
		playlock = false;
		waiting = false;
		elapsed_time = 0;
		Player_Behaviour();

		g = GameObject.FindGameObjectWithTag("GameManager");
		gm = (GameController) g.GetComponent(typeof(GameController));
		LoadState();
		
		ani = this.GetComponent<Animator> ();
		if (ani != null) {
			dirX = ani.GetFloat("dirX");
			dirY = ani.GetFloat("dirY");
			ani.SetBool("running", false);
		}
		
		for (int i = 0; i < waypoints.Length; i++) {
			Vector3 position = waypoints[i].gameObject.transform.position;
			position.z = position.y;
			waypoints[i].gameObject.transform.position = position;
		}
		
		storedWaypoints = new ArrayList();
		if (waypoints.Length > 0) {
			storedWaypoints.Add(waypoints[0].gameObject.transform.position);
		}
		currentIndex = 0;

		Vector3 pos = transform.position;
		pos = gm.getSpawnPoint(actual_spawn).transform.position;
		pos.z = pos.y;
		transform.position = pos;

	}
	
	// Update is called once per frame
	void Update () {

		if (Time.timeScale == 0.0f) {return;}

		int test_state = gm.getStateIndex("Player");
		if (actualstate != test_state) {
			Debug.Log("player mudou para o estado: "+test_state);
			LoadState();
		}

		ani.SetBool("waiting", waiting);

		//movimentacao nas oito direcoes
		if (!npc_behaviour) {//jogador tem o controle sobre player
			float velx = 0f;
			float vely = 0f;
			bool hor = false;
			bool ver = false;
			if (!playlock) {
				if (Input.GetKey(Teclas.getKeyDireita())) {
					velx = 1f;
					dirX = 1f;
					hor = true;
				}
				if (Input.GetKey(Teclas.getKeyEsquerda())) {
					velx = -1f;
					dirX = -1f;
					hor = true;
				}
				if (Input.GetKey(Teclas.getKeyCima())) {
					vely = 1f;
					dirY = 1f;
					ver = true;
				}
				if (Input.GetKey(Teclas.getKeyBaixo())) {
					vely = -1f;
					dirY = -1f;
					ver = true;
				}

				if (ver || hor) {
					waiting = false;
					elapsed_time = 0;
				}
				else if (elapsed_time < 12) {
					elapsed_time = elapsed_time + Time.deltaTime;
				}
				else {
					waiting = true;
				}

			}

			ani.SetBool("running", (hor || ver));
			ani.SetFloat("speedX", velx);
			ani.SetFloat("speedY", vely);

			if (hor && !ver) {
				ani.SetFloat("dirX", dirX);
				ani.SetFloat("dirY", 0f);
			}
			else if (!hor && ver) {
				ani.SetFloat("dirX", 0f);
				ani.SetFloat("dirY", dirY);
			}
			else if (hor && ver) {
				ani.SetFloat("dirX", dirX);
				ani.SetFloat("dirY", dirY);
			}
			rigidbody2D.velocity = new Vector2 ( velx*maxspeedX, vely*maxspeedY );
		}
		else { // jogador nao tem controle sobre player, e este se comporta como um NPC
			if (proximaAcaoInit < OnInitActions.Count) {
				if (ExecuteAction(OnInitActions, proximaAcaoInit)) {
					proximaAcaoInit++;
				}
			}
		}

		Vector3 pos = transform.position;
		pos.z = pos.y;
		transform.position = pos;
	}

	void FixedUpdate() {
		if (npc_behaviour) {
			if (storedWaypoints.Count > 0) {
				waiting = false;
				Vector3 currentWaypoint = (Vector3)storedWaypoints[0];
				move2Waypoint(currentWaypoint);
				if (Vector3.Distance (currentWaypoint, transform.position) < minDistance) {
					storedWaypoints.RemoveAt(0);
					if ((storedWaypoints.Count <= 0) && (waypoints.Length > 0)) {
						currentIndex = currentIndex+1;
						if (currentIndex > waypoints.Length-1) {
							currentIndex = 0;
						}
						storedWaypoints.Add(waypoints[currentIndex]);
					}
				}
			}
			else {
				if (ani != null) {
					ani.SetFloat("speedX", 0f);
					ani.SetFloat("speedY", 0f);
					ani.SetBool("running", false);
				}
			}
		}
	}

	void OnLevelWasLoaded(int thisLevel) {
		Vector3 pos = transform.position;
		pos = gm.getSpawnPoint(actual_spawn).transform.position;
		//pos = GameObject.Find(actual_spawn).transform.position;
		pos.z = pos.y;
		transform.position = pos;
	}

	void OnCollisionEnter2D(Collision2D c) {

	}
	
	void OnCollisionExit2D (Collision2D c) {

	}
	
	void OnTriggerEnter2D(Collider2D other) {

	}
	
	void OnTriggerExit2D(Collider2D other) {

	}

	public void set_spot(string spot) {
		actual_spawn = spot;
	}

	public void lockplayer() {
		playlock = true;
		elapsed_time = 0;
	}

	public void unlockplayer() {
		playlock = false;
	}

	public void NPC_Behaviour() {
		npc_behaviour = true;
		lockplayer();
	}

	public void Player_Behaviour() {
		npc_behaviour = false;
		unlockplayer();
	}

	public void make_wait(bool iswaiting) {
		waiting = iswaiting;
	}
}
