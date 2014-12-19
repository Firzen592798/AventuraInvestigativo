using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public GameObject player;
	private GameObject init_spot;
	private int init_scene;
	private int init_music;
	private int init_anbient;
	private PlayerController persona;

	private Inventorio inventorio;

	private int current_scene_index;
	private Hashtable NPC_dict;
	private Hashtable Spawn_dict;

	private GerenciadorEstados gerEstados;
	private MusicManager soundplayer;
	private FileManager fm;
	private BacklogManager backlog;

	private Profile[] perfis;
	private Item[,,] item_grid;//Matriz da representacao dos itens

	private bool can_showppbutton;

	private bool paused = false;

    //testes do victor
	public Camera cam;

	private bool cam_move;
	private bool on_mainmenu; // variavel que controla se o jogador esta no menu principal

	private bool fadingtoblack;
	private bool fadingtoclear;
	private bool pendingstart;
	private bool pendingshowmenuGUI;

	public Sprite[] face_sets;//Array com faces de cada personagem
	public string[] char_names;//Nomes de cada personagem
	public int[] face_divider;//indices do inicio do faceset de cada personagem
	public Sprite[] menu_icons;//balao de fala,inventorio,perfis,backlog,anotacoes
	public Sprite[] objectimgs;

	private float _Hdef; //variavel que guarda a altura padrao da tela
	private float _Wdef; //variavel que guarda a largura padrao da tela

	public GUISkin game_skin;//GUISkin com todos os estilos de gui

	//private GUITexture guiTexture;

	private GameGUI _GI;
	// Use this for initialization
	void Start () {
		init_spot = Instantiate(Resources.Load("prefab/initial_spot", typeof(GameObject))) as GameObject;
		init_spot.name = "initial_spot";
		init_spot.transform.position = new Vector3(2.55f, 0.023f);
		init_scene = -1;
		init_music = -1;
		init_anbient = -1;

		player = null;
		persona = null;
		current_scene_index = Application.loadedLevel;
		NPC_dict = new Hashtable();
		Spawn_dict = new Hashtable();

		inventorio = new Inventorio();
		soundplayer = GetComponent<MusicManager> ();
		gerEstados = GerenciadorEstados.getInstance();
		fm = FileManager.getInstance();
		backlog = BacklogManager.getInstance ();
		initializeGameDataDirectory();

		enableppbutton();
		perfis = new Profile[2];
		item_grid = inventorio.getItemGrid();//new Item[4,4,3];
		
		on_mainmenu = true;
		cam_move = false;

		_Hdef = Screen.height;
		_Wdef = Screen.width;

		fadingtoblack = false;
		fadingtoclear = false;
		pendingstart = false;
		pendingshowmenuGUI = false;

		_GI = new GameGUI(this);
	}

	public void initializeGameDataDirectory() {
		if (!fm.checkDirectory("GameData")) {
			fm.createDirectory("GameData");
			fm.createDirectory("GameData/saves");
			fm.createFile("GameData", "README", "txt");
		}
		else { 
			if (!fm.checkDirectory("GameData/saves")) {
				fm.createDirectory("GameData/saves");
			}
			if (!fm.checkFile("GameData", "README", "txt")) {
				fm.createFile("GameData", "README", "txt");
			}
		}
	}

	public void SaveGame(string savefile) {
		SaveGameStructure save = new SaveGameStructure();
		initializeGameDataDirectory();
		if (!fm.checkFile("GameData/saves", savefile, "sav")) {
			fm.createFile("GameData/saves", savefile, "sav");
		}
		fm.WriteBinaryFile("GameData/saves", savefile, "sav", save);
	}

	public bool LoadGame(string savefile) {
		if (fm.checkFile("GameData/saves", savefile, "sav")) {
			SaveGameStructure save = (SaveGameStructure)fm.ReadBinaryFile("GameData/saves", savefile, "sav");
			inventorio = new Inventorio();
			gerEstados.reset();
			backlog.reset();

			//Debug.Log("itempegos: "+save.itempegos.GetLength(0));
			for(int i = 0; i < save.itempegos.GetLength(0); i++) {
				Debug.Log("item: "+save.itempegos[i,0]+", sprite: "+save.itempegos[i,1]);
				inventorio.addItem(save.itempegos[i,0], save.itempegos[i,1]);
			}
			item_grid = inventorio.getItemGrid();

			for (int i = 0; i < save.events.Length; i++) {
				if (save.events[i]) {
					gerEstados.setEventActive(i);
				}
				else {
					gerEstados.setEventDeactive(i);
				}
			}

			string[] nomes = save.nomes;
			for(int i = 0; i < nomes.Length; i++) {
				gerEstados.alterarEstado(nomes[i], save.states[i], null);
				PositionGlobal p = save.getPositionGlobal(i);
				if (nomes[i] != "Player") {
					if (p.initialized) {
						gerEstados.setGlobalPosition(nomes[i], p.position, p.scene_index);
					}
				}
				else {
					init_spot.transform.position = p.position;
					init_scene = p.scene_index;
				}
			}

			int n = save.profiles.GetLength(0);
			perfis = new Profile[n];
			for(int i = 0; i < n; i++) {
				perfis[i] = new Profile(save.profiles[i,0], save.profiles[i,1], save.profiles[i,2], save.profiles[i,3]);
			}

			string[] rotulos = save.getRotulosBacklog();
			for(int i = 0; i < rotulos.Length; i++) {
				backlog.addToBacklog(rotulos[i]);
			}

			_GI.PlayerNotes = save.getPlayerNotes();

			init_music = save.music;
			init_anbient = save.anbient;

			pendingshowmenuGUI = save.show_menu;

			return true;
		}
		return false;
	}

	public void enableppbutton() {
		this.can_showppbutton = true;
	}

	public void disableppbutton() {
		this.can_showppbutton = false;
	}

	// Update is called once per frame
	void Update () {
      	//testes do victor
		if (!on_mainmenu) {
			if (_GI.ShowingInventoryGUI||_GI.ShowingProfilesGUI||_GI.ShowingBacklogGUI||_GI.ShowingNotesGUI) {
				Time.timeScale = 0.0f;
			}
			/*
			else if (Input.GetKeyUp(KeyCode.Escape)) {
				Debug.Log("PAUSE BUTTON PRESSED");
				Time.timeScale = 1.0f - Time.timeScale;
				paused = !paused;
			}*/
			else if (paused) {
				Time.timeScale = 0.0f;
			}
			else {
				Time.timeScale = 1.0f;
			}

		}
		else {
			Time.timeScale = 1.0f;
		}

		if (fadingtoblack)
		{
			bool faded = _GI.FadeToBlack();
			if (faded)
			{
				fadingtoblack = false;
				if (pendingstart)
				{
					if (init_scene == -1) {
						TransiteScene("CenaQuarto1", "initial_spot", init_spot);
					}
					else {
						TransiteScene(init_scene, "initial_spot", init_spot);
						fadingtoclear = true;
					}

					if (init_music != -1) {
						playSound(init_music, 0);
					}
					if (init_anbient != -1) {
						playSound(init_anbient, 1);
					}
					pendingstart = false;
					//fadingtoclear = true;
				}
			}
		}
		if (fadingtoclear) 
		{
			bool faded = _GI.FadeToClear();
			if (faded)
			{
				fadingtoclear = false;
				if (pendingshowmenuGUI) {
					_GI.ShowingQuickMenuGUI = true;
				}
			}
		}


			//Camera
		if (cam_move) 
		{
			cam.transform.position = new Vector3(player.transform.position.x,player.transform.position.y+_GI.PlayerHeight,cam.transform.position.z);
		}
			//Inputs
        //if (Input.GetKeyDown (KeyCode.C)) 
		//{
		//	menu_button_press = true;
		//}
		//if (Input.GetKeyUp (KeyCode.C)) 
		//{
		//	menu_button_press = false;
		//}
			//Variaveis de controle
		//if (menu_button_press) 
		//{
		//	if (!on_mainmenu)
		//	{
		//		if ((!show_menu_GUI)&&(!show_inventory_GUI))
		//		{
		//			show_menu_GUI = true;
		//			persona.lockplayer();
		//		}else
		//		{	
		//			show_menu_GUI = false;
		//			show_inventory_GUI = false;
		//			persona.unlockplayer();
		//		}
		//		menu_button_press = false;
		//	}
		//}

		//if (Input.GetMouseButtonDown (1)) 
		//{
		//	rightmouse_pressed = true;
		//}
		//if (Input.GetMouseButtonUp (1)) 
		//{
		//	rightmouse_pressed = false;
		//}

		/*
		if (rightmouse_pressed) 
		{
			if (!show_menu_GUI)
			{
				if (!show_inventory_GUI)
				{
					QM_Appear = true;
					show_menu_GUI = true;
				}
			}else
			{
				//show_menu_GUI = false;
				QM_Appear = false;
			}
			rightmouse_pressed = false;
		}
		*/
			//Dialogo
		_GI.displayDialogText();
	}

	public void TransiteScene(string NextScene, string SpawnPoint) {
		if (player != null) {
			//persona = (PlayerController) player.GetComponent(typeof(PlayerController));
			persona.set_spot(SpawnPoint);
			DontDestroyOnLoad(player);
		}
		DontDestroyOnLoad(this.gameObject);
		DontDestroyOnLoad(this.cam);
		Application.LoadLevel(NextScene);
	}

	public void TransiteScene(int NextScene, string SpawnPoint) {
		if (player != null) {
			//persona = (PlayerController) player.GetComponent(typeof(PlayerController));
			persona.set_spot(SpawnPoint);
			DontDestroyOnLoad(player);
		}
		DontDestroyOnLoad(this.gameObject);
		DontDestroyOnLoad(this.cam);
		Application.LoadLevel(NextScene);
	}

	public void TransiteScene(string NextScene, string SpawnPoint, GameObject door) {
		if (player != null) {
			//persona = (PlayerController) player.GetComponent(typeof(PlayerController));
			persona.set_spot(SpawnPoint);
			DontDestroyOnLoad(player);
		}
		DontDestroyOnLoad(this.gameObject);
		DontDestroyOnLoad(this.cam);
		DontDestroyOnLoad(door);
		Application.LoadLevel(NextScene);
	}

	public void TransiteScene(int NextScene, string SpawnPoint, GameObject door) {
		if (player != null) {
			//persona = (PlayerController) player.GetComponent(typeof(PlayerController));
			persona.set_spot(SpawnPoint);
			DontDestroyOnLoad(player);
		}
		DontDestroyOnLoad(this.gameObject);
		DontDestroyOnLoad(this.cam);
		DontDestroyOnLoad(door);
		Application.LoadLevel(NextScene);
	}

	public void TransiteScene(string NextScene, string SpawnPoint, int dirX, int dirY) {
		if (player != null) {
			//persona = (PlayerController) player.GetComponent(typeof(PlayerController));
			persona.changeDirection(dirX, dirY);
			persona.set_spot(SpawnPoint);
			DontDestroyOnLoad(player);
		}
		DontDestroyOnLoad(this.gameObject);
		DontDestroyOnLoad(this.cam);
		Application.LoadLevel(NextScene);
	}

	public void TransiteScene(int NextScene, string SpawnPoint, int dirX, int dirY) {
		if (player != null) {
			//persona = (PlayerController) player.GetComponent(typeof(PlayerController));
			persona.changeDirection(dirX, dirY);
			persona.set_spot(SpawnPoint);
			DontDestroyOnLoad(player);
		}
		DontDestroyOnLoad(this.gameObject);
		DontDestroyOnLoad(this.cam);
		Application.LoadLevel(NextScene);
	}

	public void TransiteScene(string NextScene, string SpawnPoint, int dirX, int dirY, GameObject door) {
		if (player != null) {
			//persona = (PlayerController) player.GetComponent(typeof(PlayerController));
			persona.changeDirection(dirX, dirY);
			persona.set_spot(SpawnPoint);
			DontDestroyOnLoad(player);
		}
		DontDestroyOnLoad(this.gameObject);
		DontDestroyOnLoad(this.cam);
		DontDestroyOnLoad(door);
		Application.LoadLevel(NextScene);
	}

	public void TransiteScene(int NextScene, string SpawnPoint, int dirX, int dirY, GameObject door) {
		if (player != null) {
			//persona = (PlayerController) player.GetComponent(typeof(PlayerController));
			persona.changeDirection(dirX, dirY);
			persona.set_spot(SpawnPoint);
			DontDestroyOnLoad(player);
		}
		DontDestroyOnLoad(this.gameObject);
		DontDestroyOnLoad(this.cam);
		DontDestroyOnLoad(door);
		Application.LoadLevel(NextScene);
	}

	void OnGUI(){      
                
        //testes do victor
        GUI.skin = game_skin;

		Matrix4x4 oldMatrix = GUI.matrix;
		Vector3 scale = new Vector3(Screen.height/_Hdef, Screen.width/_Wdef, 1.0f);
		Matrix4x4 t = Matrix4x4.TRS(new Vector3(0,0,0), Quaternion.identity, scale);

		GUI.matrix = t;

		if (!on_mainmenu) 
		{//Mostrando os componentes de GUI
			
			//Botao de interacao
			if (_GI.ShowingIntButton && can_showppbutton) 
			{
				_GI.showExamineGUI();
			}
			//else if (show_intbutton_GUI) {
			//	hideppbutton();
			//}

			//Botao de acesso ao menu (inventario)

			if (_GI.ShowingBigImage)
			{
				_GI.showBigImageGUI();
			}

			//Faces dos personagens e mostrar itens
			if (_GI.ShowingFace) 
			{
				_GI.showFacesGUI();
			}
			
			//Caixa de dialogo
			if (_GI.ShowingDialogBoxGUI) 
			{
				_GI.showDialogGUI();
			}
			
			//Caixa de escolha
			if (_GI.ShowingChoiceBoxGUI) 
			{
				_GI.showChoiceGUI();
			}
			
			//Menu inventorio
			if (_GI.ShowingInventoryGUI)
			{
				_GI.showInventoryGUI();
			}

			//Menu perfis
			if (_GI.ShowingProfilesGUI)
			{
				_GI.showProfilesGUI();
			}

			//Caixa de backlog
			if (_GI.ShowingBacklogGUI) 
			{
				_GI.showBacklogGUI();
			}

			if (_GI.ShowingNotesGUI)
			{
				_GI.showNotesGUI();
			}

			if (_GI.ShowingQuickMenuGUI)
			{
				_GI.showQuickmenuGUI();
			}

		}else
		{
			//Menu principal
			_GI.showMainMenuGUI();
		}

		GUI.matrix = oldMatrix;

	}

	public void InitializeGame() {
		if (on_mainmenu) {
			on_mainmenu = false;
			fadingtoblack = true;	
			pendingstart = true;
			soundplayer.loadsound(1);
			soundplayer.playsound();
		}
		//TODO
	}

	public GameGUI GameInterface {
		get {return _GI;}
	}

	public Profile[] Profiles {
		get {return perfis;}
	}

	public int getMusic() {
		return soundplayer.Music;
	}

	public int getAnbient() {
		return soundplayer.Anbient;
	}

	public bool[] getEvents() {
		return gerEstados.Events;
	}

	public ArrayList getNomePersonagens() {
		return gerEstados.getNomePersonagens();
	}

	public Item[] getItems() {
		return inventorio.getItems();
	}

	public Item[,,] ItemGrid {
		get {return item_grid;}
	}

	public int countItems() {
		return inventorio.count();
	}

	public int getStateIndex(string personagem) {
		return gerEstados.getEstadoIndex(personagem);
	}

	public state getState(string personagem) {
		return gerEstados.getEstado(personagem);
	}

	public void changeState(string personagem, int state, string condit) {
		gerEstados.alterarEstado(personagem, state, condit);
	}

	public void activateEvent(int ev_num) {
		gerEstados.setEventActive(ev_num);
	}

	public void deactivateEvent(int ev_num) {
		gerEstados.setEventDeactive(ev_num);
	}

	public ArrayList getBacklogFrom(string personagem) {
		string _personagem = personagem;
		if (personagem == "Player") {_personagem = "";}
		return backlog.getPersonagemBacklog(_personagem);
	}

	public PositionGlobal getGlobalPosition(string personagem) {
		if (personagem == "Player") {
			PositionGlobal p;
			if (player != null) {
				p.initialized = true;
				p.position = player.transform.position;
			}
			else {
				p.initialized = false;
				p.position = new Vector3();
			}
			p.scene_index = Application.loadedLevel;
			return p;
		}
		return gerEstados.getGlobalPosition(personagem);
	}

	public void setGlobalPosition(string personagem) {
		ObjectController npc = getNPC(personagem);
		if (npc != null) {
			Vector3 pos = npc.gameObject.transform.position;
			int scene_index = Application.loadedLevel;

			gerEstados.setGlobalPosition(personagem, pos, scene_index);
		}
	}

	public void setGlobalPosition(string personagem, Vector3 pos, int scene_index) {
		gerEstados.setGlobalPosition(personagem, pos, scene_index);
	}

	public void setExaminable(string personagem,bool examinable) {
		ObjectController npc = getNPC(personagem);
		if (npc != null)
		{
			npc.setExaminable(examinable);
			Debug.Log(personagem+" examinavel = "+npc.examinable);
		}
	}

	public void SetProfile(int num, Profile prof) {
		perfis [num] = prof;
	}

	public void playSound(int n,int t)
	{
		if (t == 0)
		{
			soundplayer.playnew (n);
		}
		if (t == 1)
		{
			soundplayer.playambient(n);
		}
	}

	public void LoadAudio(int n)
	{
		soundplayer.loadsound (n);
	}

	public void PlayAudio()
	{
		soundplayer.playsound ();
	}

	public bool hasItem(string item){
		return inventorio.TemItem (item);
	}	

	public void AddItem(string item, string spritepath){
		inventorio.addItem (item, spritepath);
		item_grid = inventorio.getItemGrid();
	}

	public void InstancePlayer() {
		player = Instantiate(Resources.Load("prefab/characters/Jane", typeof(GameObject))) as GameObject;
		cam.orthographicSize = 4;
		_GI.PlayerHeight = player.GetComponent<SpriteRenderer> ().bounds.extents.y;
		cam_move = true;
	}

	void OnLevelWasLoaded(int thisLevel) {
		if (thisLevel != 0) {
			if (player == null) {
				InstancePlayer();
				persona = (PlayerController) player.GetComponent(typeof(PlayerController));
			}
			current_scene_index = thisLevel;
			NPC_dict.Clear();
			foreach(GameObject go in GameObject.FindGameObjectsWithTag("NPC")) {
				NPC_dict.Add( go.GetComponent<ObjectController>().nome, go );
			}
			Spawn_dict.Clear();
			foreach(GameObject go in GameObject.FindGameObjectsWithTag("Spawn")) {
				Spawn_dict.Add( go.name, go );
			}

			on_mainmenu = false;
			/*if (thisLevel == 0) {
				on_mainmenu = true;
			}
			else {
				on_mainmenu = false;
			}*/
		}
		else {
			on_mainmenu = true;
		}
	}

	public ObjectController getNPC(string personagem) {
		if (personagem == "Player") {
			return (ObjectController)persona;
		}
		if (Application.loadedLevel != current_scene_index) {
			NPC_dict.Clear();
			foreach(GameObject go in GameObject.FindGameObjectsWithTag("NPC")) {
				NPC_dict.Add( go.GetComponent<ObjectController>().nome, go );
			}
		}
		GameObject npco = (GameObject)NPC_dict[personagem];
		return (ObjectController)npco.GetComponent<ObjectController>();
		//return (GameObject)NPC_dict[personagem];
	}

	public GameObject getSpawnPoint(string spawn_name) {
		if (Application.loadedLevel != current_scene_index) {
			Spawn_dict.Clear();
			foreach(GameObject go in GameObject.FindGameObjectsWithTag("Spawn")) {
				Spawn_dict.Add( go.name, go );
			}
		}
		return (GameObject)Spawn_dict[spawn_name];
	}

	public PlayerController getPlayer() {
		return persona;
	}

	public void lockplayer()
	{
		persona.lockplayer ();
	}
	
	public void unlockplayer()
	{
		persona.unlockplayer ();
	}

}
