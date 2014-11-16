using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public GameObject player;
	PlayerController persona;
	private Item selectedItem;
	private Inventorio inventorio;

	private int current_scene_index;
	private Hashtable NPC_dict;
	private Hashtable Spawn_dict;

	private GerenciadorEstados gerEstados;
	MusicManager soundplayer;
    
    //testes do victor
	public Camera cam;

	bool cam_move;
	public bool leftmouse_pressed;
	public bool rightmouse_pressed;
	bool on_mainmenu; // variavel que controla se o jogador esta no menu principal
	//bool menu_button_press;// variavel que controla se o botao de menu foi apertado
	public bool show_menu_GUI;// variavel que controla se a gui do menu deve ser exibida
	public bool show_inventory_GUI;
	bool show_profiles_GUI;
	bool show_backlog_GUI;
	bool show_notes_GUI;
	bool show_dialogbox_GUI;// variavel que controla se a gui da caixa de dialogo deve ser exibida
	bool show_intbutton_GUI;// variavel que controla se a gui do botao de interacao deve ser exibida
	bool show_choicebox_GUI;// variavel que controla se a gui da caixa de escolha deve ser exibida
	bool show_face_GUI;// variavel que controla se a gui de exibicao da face deve ser exibida
	bool show_bigimage_GUI;

	Item[,,] item_grid;//Matriz da representacao dos itens
	int page;//qual indice da 3a dimensao da matriz
	public Sprite[] face_sets;//Array com faces de cada personagem
	public string[] char_names;//Nomes de cada personagem
	public int[] face_divider;//indices do inicio do faceset de cada personagem
	public Sprite[] menu_icons;//balao de fala,inventorio,perfis,backlog,anotacoes
	public Sprite[] objectimgs;
	int active_talk;

	string dialog_text;//variavel que guarda o texto a ser exibido no dialogo
	string realtext;
	bool showing_dialog;
	int dialog_word_count;
	int actual_dw_count;
	int updates_per_word;
	int words_per_sound;
	int update_count;
	string[] choices_text;//variavel que guarda os textos das escolhas
	Sprite[] face_images;//variavel que guarda as imagens sendo exibidas (0 = face esquerda, 1 = face direita, 2 = imagem de item ao centro)
	string[] face_names;//variavel que guarda o nome das imagens sendo exibidas

	public GUISkin game_skin;//GUISkin com todos os estilos de gui

	float Hdef; //variavel que guarda a altura padrao da tela
	float Wdef; //variavel que guarda a largura padrao da tela

	//variaveis que guardam tamanhos dos componentes da GUI
		//variaveis gerais (tamanho da janela de menu e da area dos botoes dos outros menus)
		// - A janela de menu cobre 1/3 da tela alinhado a direita
		// - A area dos botoes cobre apenas 10% da area do menu
	float menu_width;
	float menu_height;
	float btnarea_width;
	float btnarea_height;
	float lbutton_width;
	float lbutton_height;
	float lbutton_fontsize;
		//variaveis do menu de itens (interface do inventorio)
		// - Area superior onde fica a imagem e nome do item cobre 40% da area do menu
		// 	-> Area da imagem fica em 80% da area superior, area do nome nos 20% restantes
		// - Area do meio onde fica o texto da descricao do item cobre 20% da area do menu
		// - Area inferior onde fica a lista de itens cobre 30% da area do menu
		//  -> O grid da area inferior exibe em formato de matriz 4x4, total de 16 itens
		//  -> As areas laterais do grid comportam as setas de mudanca de pagina
	float uparea_width;
	float uparea_height;
	float upimg_height;
	float upimg_width;
	float midarea_width;
	float midarea_height;
	float desc_fontsize;
	float lowarea_width;
	float lowarea_height;
	float grid_height;
	float grid_width;
	float slot_width;
	float slot_height;
		//variaveis da caixa de dialogo
		// - Area da caixa de dialogo cobre 1/5 da tela, alinhado para baixo
		// - Area da caixa de texto cobre 80% da altura e 85% da largura da caixa de dialogo, centralizada
	float dialogbox_width;
	float dialogbox_height;
	float textarea_width;
	float textarea_height;
	float dialog_fontsize;
		//variaveis do botao de interacao
	float intbutton_width;
	float intbutton_height;
		//variaveis do menu de acesso rapido
	float menugrid_width;
	float menugrid_height;
		//variaveis da caixa de escolhas
	float choicebox_width;
	float choicebox_height;
	float choicetext_width;
	float choicetext_height;
		//variaveis da caixa da face dos personagens
	float facearea_width;
	float facearea_height;
	float faceplate_width;
	float faceplate_height;
	float faceplate_fontsize;
		//variaveis dos botoes do menu principal
	float startbtn_width;
	float startbtn_height;
		//variaveis dos componentes de imagem fora de dialogo
	float bigimage_width;
	float bigimage_height;

	int gn; 
	Rect gtextarea;
	float gxdev;
	float gydev; 
	int gfsize;
	string gtext;
	Color gtextcol;

	float player_height;

	//GUI movement
	int QM_movecounter;
	bool QM_Appear;
	bool IM_Appear;

	bool fadingtoblack;
	bool fadingtoclear;
	bool pendingstart;

	GUITexture guiTexture;
	// Use this for initialization
	void Start () {
		selectedItem = null;
		inventorio = new Inventorio(5);
		player = null;
		persona = null;
		current_scene_index = Application.loadedLevel;
		NPC_dict = new Hashtable();
		Spawn_dict = new Hashtable();

		soundplayer = GetComponent<MusicManager> ();
		gerEstados = GerenciadorEstados.getInstance();
                
        //testes do victor
		on_mainmenu = true;
		//menu_button_press = false;
		show_menu_GUI = false;
		show_inventory_GUI = false;
		show_bigimage_GUI = false;
		item_grid = new Item[4,4,3];
		page = 0;
		face_images = new Sprite[3];
		face_names = new string[2];
		updates_per_word = 1;
		dialog_word_count = 0;
		actual_dw_count = 0;
		words_per_sound = 4;
		update_count = 0;
		cam_move = false;
		leftmouse_pressed = false;
		rightmouse_pressed = false;

		Hdef = Screen.height;
		Wdef = Screen.width;

		//Resize
		//variaveis gerais dos menus
		menu_width = Wdef / 3;
		menu_height = Hdef;
		btnarea_width = menu_width;
		btnarea_height = menu_height / 10;
		lbutton_width = btnarea_width / 2;
		lbutton_height = btnarea_height /2;
		lbutton_fontsize = lbutton_height / 2f;
		//variaveis do menu de itens (interface do inventorio)
		uparea_width = menu_width;
		uparea_height = 4*menu_height/10;
		upimg_height = 8 * uparea_height / 10;
		upimg_width = upimg_height;
		midarea_width = menu_width;
		midarea_height = 2 * menu_height / 10;
		desc_fontsize = midarea_height / 7.5f;
		lowarea_width = menu_width;
		lowarea_height = 3 * menu_height / 10;
		grid_height = 9 * lowarea_height / 10;
		grid_width = grid_height;
		slot_width = grid_width / 4;
		slot_height = grid_height / 4;
		//variaveis da caixa de dialogo
		dialogbox_width = Wdef;
		dialogbox_height = Hdef / 4;
		textarea_width = 9f * dialogbox_width / 10;
		textarea_height = 7f * dialogbox_height / 10;
		dialog_fontsize = textarea_height*0.25f;
		//variaveis do botao de interacao
		intbutton_width = Wdef / 12;
		intbutton_height = intbutton_width;
		//variaveis do menu de acesso rapido
		menugrid_width = intbutton_width * 3;
		menugrid_height = menugrid_width;
		//variaveis da caixa de escolhas
		choicebox_width = 3*Wdef / 5;
		choicebox_height = choicebox_width / 5;
		choicetext_width = 9 * choicebox_width / 10;
		choicetext_height = 9 * choicebox_height/10;
		//variaveis da caixa da face dos personagens
		facearea_width = 3*dialogbox_width / 7;
		facearea_height = facearea_width;
		faceplate_width = 3 * facearea_width / 4;
		faceplate_height = faceplate_width / 6;
		faceplate_fontsize = 7 * faceplate_height / 10;
		//variaveis dos botoes do menu principal
		startbtn_width = Wdef/3;
		startbtn_height = startbtn_width / 6;
		//
		bigimage_height = Hdef - dialogbox_height;
		bigimage_width = bigimage_height;

		QM_movecounter = 0;
		QM_Appear = false;
		IM_Appear = false;


		guiTexture = GetComponent<GUITexture> ();
		guiTexture.pixelInset = new Rect(0f, 0f, Wdef*2, Hdef*2);
		guiTexture.color = Color.clear;
		fadingtoblack = false;
		fadingtoclear = false;
		pendingstart = false;
	}

	public bool FadeToClear ()
	{
		// Lerp the colour of the texture between itself and transparent.
		guiTexture.color = Color.Lerp(guiTexture.color, Color.clear, 3f * Time.deltaTime);
		if (guiTexture.color.a <= 0.01f)
		{
			guiTexture.color = Color.clear;
			return true;
		}else
		{
			return false;
		}
	}
	public bool FadeToBlack ()
	{
		// Lerp the colour of the texture between itself and black.
		guiTexture.color = Color.Lerp(guiTexture.color, Color.black, 3f * Time.deltaTime);
		if (guiTexture.color.a >= 0.9f)
		{
			guiTexture.color = Color.black;
			return true;
		}else
		{
			return false;
		}
	}

	// Update is called once per frame
	void Update () {
      	//testes do victor

		if (fadingtoblack)
		{
			bool faded = FadeToBlack();
			if (faded)
			{
				fadingtoblack = false;
				if (pendingstart)
				{
					TransiteScene("CenaQuarto1", "initial_spot");
					pendingstart = false;
					fadingtoclear = true;
				}
			}
		}
		if (fadingtoclear) 
		{
			bool faded = FadeToClear();
			if (faded)
			{
				fadingtoclear = false;
			}
		}


			//Camera
		if (!on_mainmenu)
		{
			if (cam_move) 
			{
				cam.transform.position = new Vector3(player.transform.position.x,player.transform.position.y+player_height,cam.transform.position.z);
			}
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
		if (Input.GetMouseButtonDown (1)) 
		{
			rightmouse_pressed = true;
		}
		if (Input.GetMouseButtonUp (1)) 
		{
			rightmouse_pressed = false;
		}
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
			//Dialogo
		if (showing_dialog) 
		{
			string newshowtext = "";
			if (update_count < updates_per_word)
			{
				update_count++;
			}else
			{
				if (dialog_word_count == 0)
				{
					dialog_word_count = realtext.Length;
					actual_dw_count = 0;
				}
				if (actual_dw_count < dialog_word_count)
				{
					if ((actual_dw_count%words_per_sound)==0)
					{
						soundplayer.loadsound(0);
						soundplayer.playsound();
					}
					actual_dw_count++;
					newshowtext = getChars(realtext,actual_dw_count);
					dialog_text = newshowtext;
				}else
				{
					showing_dialog= false;
				}
				update_count=0;
			}
			 
		}else
		{
			dialog_word_count=0;
			actual_dw_count=0;
			dialog_text = realtext;
		}
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

	void OnGUI(){      
                
        //testes do victor
        GUI.skin = game_skin;

		Matrix4x4 oldMatrix = GUI.matrix;
		Vector3 scale = new Vector3(Screen.height/Hdef, Screen.width/Wdef, 1.0f);
		Matrix4x4 t = Matrix4x4.TRS(new Vector3(0,0,0), Quaternion.identity, scale);

		GUI.matrix = t;

		if (!on_mainmenu) 
		{//Mostrando os componentes de GUI
			
			//Botao de interacao
			if (show_intbutton_GUI) 
			{
				showExamineGUI();
			}

			//Botao de acesso ao menu (inventario)
			if ((show_menu_GUI)&&(!show_inventory_GUI))
			{
				showQuickmenuGUI();
			}

			if (show_bigimage_GUI)
			{
				showBigImageGUI();
			}

			//Faces dos personagens e mostrar itens
			if (show_face_GUI) 
			{
				showFacesGUI();
			}
			
			//Caixa de dialogo
			if (show_dialogbox_GUI) 
			{
				showDialogGUI();
			}
			
			//Caixa de escolha
			if (show_choicebox_GUI) 
			{
				showChoiceGUI();
			}
			
			//Menu inventorio
			if (show_inventory_GUI)
			{
				showInventoryGUI();
			}

		}else
		{
			//Menu principal
			showMainMenuGUI();
		}

		GUI.matrix = oldMatrix;

	}

	public void camLock (bool y)
	{
		cam_move = y;
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

	public void activateEvent(int ev_num)
	{
		gerEstados.setEventActive(ev_num);
	}

	public void deactivateEvent(int ev_num)
	{
		gerEstados.setEventDeactive(ev_num);
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
		//TODO
	}

	public PositionGlobal getGlobalPosition(string personagem) {
		return gerEstados.getGlobalPosition(personagem);
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

	public bool TemItem(string item){
		return inventorio.TemItem (item);
	}	

	public void PegarItem(string item, Sprite sprite){
		inventorio.addItem (item, sprite);
	}	

	public void InstancePlayer() {
		player = Instantiate(Resources.Load("prefab/characters/Jane", typeof(GameObject))) as GameObject;
		cam.orthographicSize = 4;
		player_height = player.GetComponent<SpriteRenderer> ().bounds.extents.y;
		//cam_move = true;
	}

	void OnLevelWasLoaded(int thisLevel) {
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

		if (thisLevel == 0) {
			on_mainmenu = true;
		}
		else {
			on_mainmenu = false;
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

	public void showppbutton()
	{
		show_intbutton_GUI = true;
	}

	public void showdialogbox()
	{
		show_dialogbox_GUI = true;
	}
        
    public void showitem(Item item)
	{
		face_images [2] = item.getSprite ();
	}

	public void hideitem()
	{
		face_images [2] = null;
	}

	public void showface(int pos, int personagem, int faceindex)
	{
		Sprite face_sprite = face_sets [face_divider [personagem]+faceindex];//corrigir
		face_images [pos] = face_sprite;
		face_names [pos] = char_names [personagem];
		active_talk = pos;
		show_face_GUI = true;
	}

	public void hideface(int pos)
	{
		face_images [pos] = null;
		face_names [pos] = "";
		show_face_GUI = false;
	}

	public void showbigimage(int n, float px, float py, float xdev, float ydev, float fsize,string texto, Color tc)
	{
		gn = n;
		float gpx = bigimage_width * px;
		float gpy = bigimage_height * py;
		gtextarea = new Rect(0,0,gpx,gpy);
		gxdev = bigimage_width*xdev;
		gydev = bigimage_height*ydev;
		gfsize = Mathf.RoundToInt(bigimage_height*fsize);
		gtext = texto;
		gtextcol = tc;
		show_bigimage_GUI = true;
	}

	public void hidebigimage()
	{
		show_bigimage_GUI = false;
	}

	public void showchoicebox(string[] choices)
	{
		choices_text = choices;
		show_choicebox_GUI = true;
	}

	public void hidechoicebox()
	{
		show_choicebox_GUI = false;
	}

	public void hideppbutton()
	{
		show_intbutton_GUI = false;
	}

	public void hidedialogbox()
	{
		show_dialogbox_GUI = false;
	}

	public void LoadShowTxt(string s)
	{
		dialog_text = "";
		realtext = s;
		showing_dialog = true;
	}

	public void lockplayer()
	{
		persona.lockplayer ();
	}
	
	public void unlockplayer()
	{
		persona.unlockplayer ();
	}

	public string getChars(string text, int num)
	{
		return text.Substring (0, num);
	}
	public void quickPassTxt()
	{
		showing_dialog = false;
	}
	public bool isShowingDialog()
	{
		return showing_dialog;
	}
	public void showExamineGUI()
	{
		//Definir area do botao de interacao
		Vector3 p1 = cam.WorldToScreenPoint (new Vector3 (0, player_height, 0));
		Vector3 p2 = cam.WorldToScreenPoint (new Vector3 (0, 0, 0));
		float char_height = (p1 - p2).y;
		GUI.BeginGroup(new Rect((Wdef-intbutton_width)/2,Hdef/2-intbutton_height-char_height,intbutton_width,intbutton_height));
		//Desenhar botao de interacao
		GUIStyle intbtnstyle = new GUIStyle ();
		intbtnstyle.normal.background = menu_icons [0].texture;
		bool intbtn = GUI.Button(new Rect(0,0,intbutton_width,intbutton_height),"",intbtnstyle);
		if (intbtn)
		{
			//colocar acao do botao - iniciar dialogo
			leftmouse_pressed = true;
		}
		
		GUI.EndGroup();
	}

	public void showQuickmenuGUI()
	{
		//Definir area dos botoes de acesso
		float mgwidth = menugrid_width;
		float mgheight = menugrid_height;

		if (QM_Appear)
		{
			if (QM_movecounter == 0)
			{
				QM_movecounter = 10;
			}
			if (QM_movecounter <= 10)
			{
				mgwidth = menugrid_width/Mathf.CeilToInt(QM_movecounter/2);
				mgheight = menugrid_height/Mathf.CeilToInt(QM_movecounter/2);
				if (QM_movecounter > 2)
				{
					QM_movecounter--;
				}
			}
		}else
		{
			if (QM_movecounter <= 10)
			{
				mgwidth = menugrid_width/Mathf.CeilToInt(QM_movecounter/2);
				mgheight = menugrid_height/Mathf.CeilToInt(QM_movecounter/2);
				QM_movecounter++;
				if (QM_movecounter == 10)
				{
					QM_movecounter = 0;
					show_menu_GUI = false;
				}
			}
		}

		GUI.BeginGroup(new Rect((Wdef-mgwidth)/2,(Hdef-mgheight)/2,mgwidth,mgheight));
		
		//Desenhar botoes de acesso
		//Esquerda - inventorio
		GUIStyle inventory_style = new GUIStyle();
		inventory_style.normal.background = menu_icons[1].texture;
		bool invbtn = GUI.Button(new Rect(0,(mgheight-intbutton_height)/2,intbutton_width,intbutton_height),"","SlotBackground");
		GUI.Box(new Rect(0,(mgheight-intbutton_height)/2,intbutton_width,intbutton_height),"",inventory_style);
		if (invbtn)
		{
			show_menu_GUI = false;
			show_inventory_GUI = true;
			IM_Appear = true;
			persona.lockplayer();
		}/*
		//Direita - Perfis
		//GUIStyle inventory_style = new GUIStyle();
		//inventory_style.normal.background = menu_icons[1].texture;
		bool perfbtn = GUI.Button(new Rect(menugrid_width-intbutton_width,(menugrid_height-intbutton_height)/2,intbutton_width,intbutton_height),"","SlotBackground");
		//GUI.Box(new Rect(0,(menugrid_height-intbutton_height)/2,intbutton_width,intbutton_height),"",inventory_style);
		if (perfbtn)
		{
			//show_menu_GUI = true;
			//persona.lockplayer();
		}
		//Baixo - backlog
		//GUIStyle inventory_style = new GUIStyle();
		//inventory_style.normal.background = menu_icons[1].texture;
		bool bklbtn = GUI.Button(new Rect((menugrid_width-intbutton_width)/2,menugrid_height-intbutton_height,intbutton_width,intbutton_height),"","SlotBackground");
		//GUI.Box(new Rect(0,(menugrid_height-intbutton_height)/2,intbutton_width,intbutton_height),"",inventory_style);
		if (bklbtn)
		{
			//show_menu_GUI = true;
			//persona.lockplayer();
		}
		//Cima - anotacoes
		//GUIStyle inventory_style = new GUIStyle();
		//inventory_style.normal.background = menu_icons[1].texture;
		bool anotbtn = GUI.Button(new Rect((menugrid_width-intbutton_width)/2,0,intbutton_width,intbutton_height),"","SlotBackground");
		//GUI.Box(new Rect(0,(menugrid_height-intbutton_height)/2,intbutton_width,intbutton_height),"",inventory_style);
		if (anotbtn)
		{
			//show_menu_GUI = true;
			//persona.lockplayer();
		}*/		
		GUI.EndGroup();
	}

	public void showInventoryGUI()
	{
		Item[] itemsPegos = inventorio.getItems();
		int itemCount = inventorio.count ();
		
		//organizar itens no grid do inventorio
		int H = 0;
		for (int k = 0;k<3;k++)
		{
			for (int i = 0; i<4;i++)
			{
				for (int j = 0; j<4;j++)
				{
					if (H<itemCount)
					{
						item_grid[i,j,k] = itemsPegos[H];
						H++;
					}						 
				}
			}
		}
		float lpos = Wdef - menu_width;

		if (IM_Appear == true)
		{
			if (QM_movecounter <= 10)
			{
				lpos = Wdef - QM_movecounter*(menu_width/10);
				QM_movecounter++;
			}
		}else
		{
			if (QM_movecounter >= 0)
			{
				lpos = Wdef - QM_movecounter*(menu_width/10); 
				QM_movecounter--;
			}else
			{
				QM_movecounter = 0;
				show_inventory_GUI = false;
			}
		}

		//Fazer a area delimitante do menu
		GUI.BeginGroup(new Rect(lpos,Hdef-menu_height,menu_width,menu_height));
		
		//Desenhar o background do menu
		GUI.Box(new Rect(0,0,menu_width,menu_height),"","MenuBackground");
		
		//Definir area superior
		GUI.BeginGroup(new Rect(0,0,uparea_width,uparea_height));
		
		//Desenhar area superior (imagem do item e titulo do mesmo)
		if (selectedItem != null)
		{
			GUIStyle itemtitle = GUI.skin.GetStyle("TextBackground");
			itemtitle.fontSize = Mathf.RoundToInt(dialog_fontsize);
			GUI.Box(new Rect(0,0,uparea_width,uparea_height-upimg_height),selectedItem.getNome(),itemtitle);
			GUIStyle bigimg = new GUIStyle();
			bigimg.normal.background = selectedItem.getSprite().texture;
			GUI.Box(new Rect((uparea_width-upimg_width)/2,uparea_height-upimg_height,upimg_width,upimg_height),"",bigimg);
		} else
		{
			GUI.Box(new Rect(0,0,uparea_width,uparea_height-upimg_height),"","TextBackground");
		}
		GUI.EndGroup();
		
		//Definir area central
		GUI.BeginGroup(new Rect(0,menu_height-lowarea_height-btnarea_height-midarea_height,midarea_width,midarea_height));
		
		//Desenhar a area central (Descricao de item)
		GUIStyle itemdesc = GUI.skin.GetStyle("TextBackground");
		itemdesc.fontSize = Mathf.RoundToInt(desc_fontsize);
		if (selectedItem != null)
		{
			GUI.Box(new Rect(0,0,midarea_width,midarea_height),selectedItem.getDescricao(),itemdesc);
		} else
		{
			GUI.Box(new Rect(0,0,midarea_width,midarea_height),"",itemdesc);
		}
		GUI.EndGroup();
		
		//Definir area inferior
		GUI.BeginGroup(new Rect(0,menu_height-lowarea_height-btnarea_height,lowarea_width,lowarea_height));
		
		//Desenhar areas laterais inferiores (setas de mudanca de pagina)
		bool leftarrow = GUI.Button(new Rect(0.02f*lowarea_width,2*lowarea_height/5,slot_width,slot_height),"","ArrowLBackground");
		if (leftarrow)
		{
			if (page > 0)
			{
				page = page - 1;
			}else
			{
				page = 2;
			}
			
		}
		bool rightarrow = GUI.Button(new Rect(0.98f*lowarea_width-slot_width,2*lowarea_height/5,slot_width,slot_height),"","ArrowRBackground");
		if (rightarrow)
		{
			if (page < 2)
			{
				page = page + 1;
			}else
			{
				page = 0;
			}
		}
		
		//Definir area central inferior(itens do inventario)
		GUI.BeginGroup(new Rect((lowarea_width-grid_width)/2,(lowarea_height-grid_height)/2,grid_width,grid_height));
		
		//Desenhar area central inferior(item slots)
		bool[,] itemshow= new bool[4,4];
		for (int i = 0;i< 4;i++)
		{
			float posX = i*slot_width;
			for (int j=0; j<4; j++)
			{
				float posY = j*slot_height;
				if (item_grid[j,i,page] != null)
				{
					GUIStyle litimg = new GUIStyle();
					litimg.normal.background = item_grid[j,i,page].getSprite().texture;
					itemshow[j,i] = GUI.Button (new Rect(posX,posY,slot_width,slot_height),"","SlotBackground");
					GUI.Box (new Rect(posX,posY,slot_width,slot_height),"",litimg);
					if (itemshow[j,i])
					{
						selectedItem = item_grid[j,i,page];
					}
				}else
				{
					GUI.Box (new Rect(posX,posY,slot_width,slot_height),"","SlotBackground");
				}
			}
		}
		GUI.EndGroup();
		
		GUI.EndGroup();
		
		//Definir area dos botoes dos menus
		GUI.BeginGroup(new Rect(0,menu_height-btnarea_height,btnarea_width,btnarea_height));
		
		//Desenhar area dos botoes dos menus(botoes)
		GUIStyle lbutton = GUI.skin.GetStyle("ButtonBackground");
		lbutton.fontSize = Mathf.RoundToInt(lbutton_fontsize);
		GUI.Button(new Rect(0,0,lbutton_width,lbutton_height),"Perfis",lbutton);
		GUI.Button(new Rect(lbutton_width,0,lbutton_width,lbutton_height),"Backlog",lbutton);
		GUI.Button(new Rect(0,btnarea_height-lbutton_height,lbutton_width,lbutton_height),"Anotações",lbutton);
		
		//Botao de fechar menu
		bool closebutton = GUI.Button(new Rect(lbutton_width,btnarea_height-lbutton_height,lbutton_width,lbutton_height),"Fechar",lbutton);
		if (closebutton)
		{
			show_menu_GUI = false;
			//show_inventory_GUI = false;
			IM_Appear = false;
			persona.unlockplayer();
		}
		
		GUI.EndGroup();		
		
		GUI.EndGroup();
	}

	public void showFacesGUI()
	{
		//Definir a area das faces
		GUI.BeginGroup(new Rect(Wdef-dialogbox_width,Hdef-dialogbox_height-facearea_height,dialogbox_width,facearea_height));
		Color guicol = GUI.color;
		//Desenhar cada imagem de face
		if (face_images[0] != null)//esquerda
		{
			GUIStyle styl0 = GUI.skin.GetStyle("FaceimgBackground");
			styl0.normal.background = face_images[0].texture;
			if (active_talk == 1)
			{
				GUI.color = new Color (0.5f,0.5f,0.5f,1.0f);
			}else
			{
				GUI.color = new Color (1f,1f,1f,1f);
			}
			GUIStyle plate0 = GUI.skin.GetStyle("NameplateBackground");
			plate0.fontSize = Mathf.RoundToInt(faceplate_fontsize);
			GUI.Box(new Rect(0,0,facearea_width,facearea_height),"",styl0);
			GUI.Box(new Rect((facearea_width-faceplate_width)/2,facearea_height-faceplate_height,faceplate_width,faceplate_height),face_names[0],plate0);
		}
		if (face_images[1] != null)//direita
		{
			GUIStyle styl1 = GUI.skin.GetStyle("FaceimgBackground");
			styl1.normal.background = face_images[1].texture;
			if (active_talk == 0)
			{
				GUI.color = new Color (0.5f,0.5f,0.5f,1.0f);
			}else
			{
				GUI.color = new Color (1f,1f,1f,1f);
			}
			GUIStyle plate1 = GUI.skin.GetStyle("NameplateBackground");
			plate1.fontSize = Mathf.RoundToInt(faceplate_fontsize);
			GUI.Box(new Rect(dialogbox_width-facearea_width,0,facearea_width,facearea_height),"",styl1);
			GUI.Box(new Rect(dialogbox_width-facearea_width+(facearea_width-faceplate_width)/2,facearea_height-faceplate_height,faceplate_width,faceplate_height),face_names[1],plate1);
		}
		if (face_images[2] != null)//centro
		{
			GUIStyle styl2 = GUI.skin.GetStyle("FaceimgBackground");
			styl2.normal.background = face_images[2].texture;
			GUI.Box(new Rect((dialogbox_width/2)-(upimg_width/2),0,upimg_width,upimg_height),"","MenuBackground");
			GUI.Box(new Rect((dialogbox_width/2)-(upimg_width/2),0,upimg_width,upimg_height),"",styl2);
		}
		GUI.color = guicol;
		GUI.EndGroup();
	}

	//Mostra uma imagem quadrada no centro da tela
	//textarea eh a area retangular onde ficara o texto, devx e devy os deslocamentos
	//da area de texto em x e y a partir do centro e fsize o tamanho da fonte
	public void showBigImageGUI()
	{
		GUI.BeginGroup (new Rect ((Wdef - bigimage_width) / 2, (Hdef - bigimage_height) / 2, bigimage_width, bigimage_height));

		GUIStyle b0styl = new GUIStyle();
		if (gn != -1)
		{
			b0styl.normal.background = objectimgs[gn].texture;
		}else
		{
			b0styl.normal.background = null;
		}
		GUI.Box (new Rect (0, 0, bigimage_width, bigimage_height), "", b0styl);

		GUIStyle bstyl = GUI.skin.GetStyle("CentralTextBackground");
		bstyl.fontSize = gfsize;
		bstyl.normal.textColor = gtextcol;
		bstyl.normal.background = null;
		float x0 = ((bigimage_width - gtextarea.width) / 2) + gxdev;
		float y0 = ((bigimage_height - gtextarea.height) / 2) + gydev;
		GUI.Box(new Rect(x0,y0,gtextarea.width,gtextarea.height),gtext,bstyl);

		GUI.EndGroup ();
	}

	public void showDialogGUI()
	{
		//Fazer a area delimitante da caixa de dialogo
		GUI.BeginGroup(new Rect(Wdef-dialogbox_width,Hdef-dialogbox_height,dialogbox_width,dialogbox_height));
		
		//Desenhar a caixa de dialogo
		GUI.Box(new Rect(0,0,dialogbox_width,dialogbox_height),"","DialogboxBackground");
		
		//Fazer a area delimitante da caixa de texto
		GUI.BeginGroup(new Rect((dialogbox_width - textarea_width)/2,(dialogbox_height-textarea_height)/2,textarea_width,textarea_height));
		
		//Desenhar o texto da caixa de texto
		GUIStyle text_gui = GUI.skin.GetStyle("DialogtextBackground");
		text_gui.fontSize = Mathf.RoundToInt(dialog_fontsize);
		GUI.Box(new Rect(0,0,textarea_width,textarea_height),dialog_text,text_gui);

		GUI.EndGroup ();
		
		GUI.EndGroup();
	}

	public void showChoiceGUI()
	{
		//Definir area da caixa de escolha
		int nchoices = choices_text.Length;
		GUI.BeginGroup(new Rect((Wdef-choicebox_width)/2,(Hdef-(nchoices*choicebox_height))/2,choicebox_width,nchoices*choicebox_height));
		
		//Desenhar caixa de escolha
		//GUI.Box(new Rect(0,0,choicebox_width,nchoices*choicebox_height),"","MenuBackground");
		
		//Desenhar botoes de escolha
		bool[] choicebuttons = new bool[nchoices];
		GUIStyle text_gui = GUI.skin.GetStyle("ButtonBackground");
		text_gui.fontSize = Mathf.RoundToInt(dialog_fontsize);
		for (int i = 0;i<nchoices;i++)
		{
			choicebuttons[i] = GUI.Button(new Rect((choicebox_width-choicetext_width)/2,((choicebox_height-choicetext_height)/2)+(i*choicetext_height),choicetext_width,choicetext_height),choices_text[i],text_gui);
			if (choicebuttons[i])
			{
				//colocar acao da escolha
			}
		}
		
		GUI.EndGroup();
	}

	public void showMainMenuGUI()
	{
		//Definir area dos botoes
		GUI.BeginGroup(new Rect((Wdef-startbtn_width)/2,3*Hdef/5,startbtn_width,startbtn_height));
		
		//Desenhar botao de iniciar jogo
		bool intbtn = GUI.Button(new Rect(0,0,startbtn_width,startbtn_height),"Iniciar Jogo","StartBtnBackground");
		if (intbtn)
		{
			on_mainmenu = false;
			fadingtoblack = true;	
			pendingstart = true;
			soundplayer.loadsound(1);
			soundplayer.playsound();
			//TransiteScene("Cena1", "initial_spot");
		}
		
		GUI.EndGroup();

	}




}
