using UnityEngine;
using System.Collections;

public class NPCController : MonoBehaviour {
	public Transform[] waypoints;
	public Animator ani;
	public int indexnum;

	private Transform currentWaypoint;
	private int currentIndex;
	private float minDistance = 0.1f;
	private float moveSpeed = 3f;
	private float moveSpeed2 = 3f;

	private float velx = 0f;
	private float vely = 0f;

	private float dirX;
	private float dirY;

	Estado[] statemachine;
	int actualstate;

	// Use this for initialization
	void Start () {

		statemachine = new Estado[2];
		statemachine [0] = new Estado (0);
		statemachine [1] = new Estado (1);
		statemachine [0].AddConex (0);
		statemachine [0].AddConex (1);
		statemachine [1].AddConex (1);
		actualstate = 0;

		// Fim codigo dialogo teste
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
		if (waypoints.Length > 0) {
			currentWaypoint = waypoints[0];
		}
		else {
			currentWaypoint = null;
		}
		currentIndex = 0;

		Vector3 pos = transform.position;
		pos.z = pos.y + GetComponent<BoxCollider2D>().center.y;
		transform.position = pos;

	}

	void OnCollisionEnter2D(Collision2D c) {
		moveSpeed = 0f;
	}
	
	void OnCollisionExit2D (Collision2D c) {
		moveSpeed = moveSpeed2;
	}

	void move2Waypoint() {

		Vector3 direction = currentWaypoint.gameObject.transform.position - transform.position;
		Vector3 moveVector = direction.normalized * moveSpeed * Time.deltaTime;
		transform.position = transform.position + moveVector;

		if (ani != null) {
			if (moveVector.x != 0f || moveVector.y != 0f) {
				moveVector = moveVector/Mathf.Max(Mathf.Abs(moveVector.x), Mathf.Abs(moveVector.y));
			}
			float dx = moveVector.x;
			float dy = moveVector.y;
			velx = 0f;
			vely = 0f;
			bool hor = false;
			bool ver = false;
			if (dx < 0) {
				dirX = -1f;
				if (dx < -0.2f) {
					velx = -1f;
				}
				hor = true;
			}
			else if (dx > 0) {
				dirX = 1f;
				if (dx > 0.2f) {
					velx = 1f;
				}
				hor = true;
			}

			if (dy < 0) {
				dirY = -1f;
				if (dy < -0.2f) {
					vely = -1f;
				}
				ver = true;
			}
			else if (dy > 0) {
				dirY = 1f;
				if (dy > 0.2f) {
					vely = 1f;
				}
				ver = true;
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
		}
	}

	// Update is called once per frame
	void Update () {
		//transform.position = new Vector3(transform.position.x + velx*0.01f, transform.position.y);
		if (waypoints.Length > 0) {
			move2Waypoint ();
			if (Vector3.Distance (currentWaypoint.transform.position, transform.position) < minDistance) {
				currentIndex = currentIndex+1;
				if (currentIndex > waypoints.Length-1) {
					currentIndex = 0;
				}
				currentWaypoint = waypoints[currentIndex];
			}
		}
		Vector3 pos = transform.position;
		pos.z = pos.y + GetComponent<BoxCollider2D>().center.y;
		transform.position = pos;
	}

	void OnLevelWasLoaded(int thisLevel) {
		Vector3 pos = transform.position;
		pos.z = pos.y + GetComponent<BoxCollider2D>().center.y;
		transform.position = pos;
	}

	public int getState()
	{
		return actualstate;
	}

	public void setNext(int param)
	{
		Estado x = statemachine [actualstate];
		int y = x.nextState (param);
		actualstate = y;
	}
}

public class Estado
{
	int ID;
	ArrayList conex;

	public Estado(int id)
	{
		this.ID = id;
		conex = new ArrayList ();
	}

	public void AddConex(int id)
	{
		conex.Add (id);
	}

	public int nextState(int param)
	{
		return (int)conex.ToArray()[param];
	}
}
