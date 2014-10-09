using UnityEngine;
using System.Collections;

public class NPCController2 : MonoBehaviour {
	GameObject g;
	GameController gm;
	public Transform[] waypoints;
	public Animator ani;
	public int indexnum;
	public string nome;
	private Transform currentWaypoint;
	private int currentIndex;
	private float minDistance = 0.1f;
	private float moveSpeed = 3f;
	private float moveSpeed2 = 3f;
	
	private float velx = 0f;
	private float vely = 0f;
	
	private float dirX;
	private float dirY;
	
	bool onregion;
	int proximaAcaoInit = 0;
	int proximaAcaoExam = 0;
	bool dialog_button_pressed;
	bool up_button_pressed;
	bool down_button_pressed;
	bool showingtext;

	private GerenciadorEstados gerEstados;
	private DicionarioAcoes dicionario;
	private ArrayList OnInitActions;
	private ArrayList OnExamineActions;
	//private Acao acaoAtual;

	//Estado[] statemachine;
	int actualstate;
	bool proximaAcaoReady = false;

	// Use this for initialization
	void Start () { 
		g = GameObject.FindGameObjectWithTag("GameManager");
		gm = (GameController) g.GetComponent(typeof(GameController));
		//actualstate = gerEstados.getEstado (nome);
		actualstate = gm.getState(this.nome);
		dicionario = new DicionarioAcoes ();
		LoadState(actualstate);
		//sequenciaAcoes = dicionario.getAcoesPersonagem (this.nome, actualstate);
		//acaoAtual = (Acao)sequenciaAcoes [proximaAcao];
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
		pos.z = pos.y;
		transform.position = pos;
	}

	void LoadState(int numState) {
		state ActionsOfState = dicionario.getStatePersonagem(this.nome, numState);
		OnInitActions = ActionsOfState.OnInitActions;
		OnExamineActions = ActionsOfState.OnExamineAction;
		proximaAcaoExam = 0;
		proximaAcaoInit = 0;
		actualstate = numState;
	}

	void OnCollisionEnter2D(Collision2D c) {
		moveSpeed = 0f;
		gm.showppbutton ();
		onregion = true;
	}
	
	void OnCollisionExit2D (Collision2D c) {
		moveSpeed = moveSpeed2;
		gm.hideppbutton ();
		onregion = false;
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
		//executarAcao ();

		int test_state = gm.getState(this.nome);
		if (actualstate != test_state) {
			Debug.Log("mudou para o estado: "+test_state);
			LoadState(test_state);
		}
		else {
			if (proximaAcaoInit < OnInitActions.Count) {
				if (ExecuteAction(OnInitActions, proximaAcaoInit)) {
					proximaAcaoInit++;
				}
			}
			else {
				dialog_button_pressed = false;
				up_button_pressed = false;
				down_button_pressed = false;
				if (Input.GetKeyDown (KeyCode.Z)) {
					dialog_button_pressed = true;
				}
				if (Input.GetKeyUp (KeyCode.Z)) {
					dialog_button_pressed = false;
				}
				if (Input.GetKeyDown (KeyCode.DownArrow)) {
					down_button_pressed = true;
				}
				if (Input.GetKeyDown (KeyCode.UpArrow)) {
					up_button_pressed = true;
				}
				if (Input.GetKeyUp (KeyCode.DownArrow)) {
					down_button_pressed = false;
				}
				if (Input.GetKeyUp (KeyCode.UpArrow)) {
					up_button_pressed = false;
				}
				if (!showingtext) {
					if (onregion && dialog_button_pressed) {
						showingtext = true;
					}
				}
				else {
					if (ExecuteAction(OnExamineActions, proximaAcaoExam)) {
						proximaAcaoExam++;
					}
					if (proximaAcaoExam >= OnExamineActions.Count) {
						showingtext = false;
						proximaAcaoExam = 0;
					}
				}
			}
		}
	}
	
	void FixedUpdate() {
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
		pos.z = pos.y;
		transform.position = pos;

		if (Input.GetKeyDown (KeyCode.Z)) 
		{
			dialog_button_pressed = true;
		}
		if (Input.GetKeyUp (KeyCode.Z)) 
		{
			dialog_button_pressed = false;
		}
		if (Input.GetKeyDown (KeyCode.DownArrow)) 
		{
			down_button_pressed = true;
		}
		if (Input.GetKeyDown (KeyCode.UpArrow)) 
		{
			up_button_pressed = true;
		}
		if (Input.GetKeyUp (KeyCode.DownArrow)) 
		{
			down_button_pressed = false;
		}
		if (Input.GetKeyUp (KeyCode.UpArrow)) 
		{
			up_button_pressed = false;
		}
		if (showingtext == true) {
				//gm.LoadShowTxt ("");
		}
	}

	bool ExecuteAction(ArrayList actionList, int indexAction) {
		if (indexAction >= actionList.Count) {
			return false;
		}
		Acao acaoAtual = (Acao) actionList[indexAction];
		return acaoAtual.Update();
	}
			
	void OnLevelWasLoaded(int thisLevel) {
		Vector3 pos = transform.position;
		pos.z = pos.y;
		transform.position = pos;
	}
	
	public int getState() {
		return actualstate;
	}
}
