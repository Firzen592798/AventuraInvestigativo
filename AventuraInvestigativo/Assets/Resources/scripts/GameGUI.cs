using UnityEngine;
using System.Collections;

public class GameGUI {

	private GameController gm;
	
	private Item selectedItem;
	private int selectedProfile;

	ArrayList backlogList;
	Vector2 scrollPosition;
	Vector2 scrollPosition2;
	//float backlog_width;
	//float backlog_height;
	int selectedConversaIndex; //Indice da conversa selecionada no backlog. Se for -1 e pq nao ta selecionado nada
	
	string[] playernotes;
	int noteindex;

	int choice_number;
	
	//testes do victor

	public bool leftmouse_pressed;
	public bool rightmouse_pressed;
	
	//bool menu_button_press;// variavel que controla se o botao de menu foi apertado
	bool show_quickmenu_GUI;// variavel que controla se a gui do menu deve ser exibida
	bool show_inventory_GUI;
	bool show_profiles_GUI;
	bool show_backlog_GUI;// variavel que controla se a gui da caixa de backlog deve ser exibida
	bool show_notes_GUI;
	bool show_dialogbox_GUI;// variavel que controla se a gui da caixa de dialogo deve ser exibida
	bool show_intbutton_GUI;// variavel que controla se a gui do botao de interacao deve ser exibida
	bool show_choicebox_GUI;// variavel que controla se a gui da caixa de escolha deve ser exibida
	bool show_face_GUI;// variavel que controla se a gui de exibicao da face deve ser exibida
	bool show_bigimage_GUI;

	int page;//qual indice da 3a dimensao da matriz

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
	
	//GUISkin game_skin;//GUISkin com todos os estilos de gui
	
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
	//variaveis do menu de perfis
	float charslot_width;
	float charslot_height;
	float slotarea_width;
	float slotarea_height;
	float imagearea_width;
	float imagearea_height;
	float descarea_width;
	float descarea_height;
	//variaveis do menu de backlog
	float logselect_width;
	float logselect_height;
	float logcontent_width;
	float logcontent_height;
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
	//float menugrid_width;
	//float menugrid_height;
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
	TextAnchor galin;
	
	float player_height;
	
	//GUI movement
	int QM_movecounter;
	//bool QM_Appear;
	bool IM_Appear;

	bool[] hoverqmsoundplayed;
	bool[] hoverchoicesoundplayed;
	bool[] hoverlbsoundplayed;
	bool[] hoverarsoundplayed;
	bool[,] hoverinvsoundplayed;
	
	private GUITexture guiTexture;

	public GameGUI(GameController gm) {

		this.gm = gm;
		//this.game_skin = game_skin;

		selectedItem = null;
		selectedProfile = 0;

		//testes do victor

		//menu_button_press = false;
		show_quickmenu_GUI = false;
		show_inventory_GUI = false;
		show_profiles_GUI = false;
		show_bigimage_GUI = false;

		page = 0;
		face_images = new Sprite[3];
		face_names = new string[2];
		updates_per_word = 1;
		dialog_word_count = 0;
		actual_dw_count = 0;
		words_per_sound = 4;
		update_count = 0;
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
		grid_height = 9f * lowarea_height / 10;
		grid_width = grid_height;
		slot_width = grid_width / 4;
		slot_height = grid_height / 4;
		//variaveis do menu de perfis
		slotarea_width = menu_width;
		slotarea_height = 1.5f * menu_height / 10;
		charslot_height = 0.9f * menu_width / 4;
		charslot_width = charslot_height;
		imagearea_width = menu_width;
		imagearea_height = 3 * menu_height / 10;
		descarea_width = menu_width;
		descarea_height = 4.5f * menu_height / 10;
		//variaveis do menu de backlog
		logselect_width = menu_width;
		logselect_height = 3.5f * menu_height / 10;
		logcontent_width = menu_width;
		logcontent_height = 4 * menu_height /10;
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
		//menugrid_width = intbutton_width * 3;
		//menugrid_height = menugrid_width;
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
		startbtn_width = Wdef/8.5f;
		startbtn_height = startbtn_width / 3.5f;
		//
		bigimage_height = Hdef - dialogbox_height;
		bigimage_width = bigimage_height;
		//variaveis do backlog
		//backlog_width = 4* Wdef / 5;
		//backlog_height =  4*Hdef / 5;
		selectedConversaIndex = -1;
		
		QM_movecounter = 0;
		//QM_Appear = false;
		IM_Appear = false;

		this.guiTexture = gm.gameObject.GetComponent<GUITexture>();
		guiTexture.pixelInset = new Rect(0f, 0f, Wdef*2, Hdef*2);
		guiTexture.color = Color.clear;
		
		hoverqmsoundplayed = new bool[4] {false,false,false,false};
		hoverchoicesoundplayed = new bool[4] {false,false,false,false};
		hoverlbsoundplayed = new bool[4] {false,false,false,false};
		hoverarsoundplayed = new bool[2] {false,false};
		hoverinvsoundplayed = new bool[4, 4] {
			{false,false,false,false},
			{false,false,false,false},
			{false,false,false,false},
			{false,false,false,false}};
		
		playernotes = new string[50];
		for (int note = 0;note<50;note++)
		{
			playernotes[note] = "";
		}
		noteindex = 0;

	}

	//private string getChars(string text, int num) {
	//	return text.Substring (0, num);
	//}

	private void DrawOutline(Rect pos, string text, GUIStyle styl, Color colOut, Color colIn){
		GUIStyle backupStyle = styl;
		styl.normal.textColor = colOut;
		//styl.fontSize++;
		
		pos.x = pos.x - 2;
		GUI.Label(pos, text, styl);
		pos.x = pos.x + 4;
		GUI.Label(pos, text, styl);
		pos.x = pos.x - 2;
		pos.y = pos.y - 2;
		GUI.Label(pos, text, styl);
		pos.y = pos.y + 4;
		GUI.Label(pos, text, styl);
		pos.y = pos.y - 2;
		
		styl.normal.textColor = colIn;
		//styl.fontSize--;
		GUI.Label(pos, text, styl);
		styl = backupStyle;
	}
	
	private bool HoverCheck(Rect button)
	{
		return button.Contains(Event.current.mousePosition);
	}

	public bool FadeToClear ()
	{
		// Lerp the colour of the texture between itself and transparent.
		guiTexture.color = Color.Lerp(guiTexture.color, Color.clear, 3f * Time.deltaTime);
		if (guiTexture.color.a <= 0.05f)
		{
			Debug.Log("acabou fadetoclear");
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
			Debug.Log("acabou fadetoblack");
			guiTexture.color = Color.black;
			return true;
		}else
		{
			return false;
		}
	}

	public void LoadShowTxt(string s)
	{
		dialog_text = "";
		realtext = s;
		showing_dialog = true;
	}

	public void quickPassTxt()
	{
		showing_dialog = false;
	}

	public void displayDialogText() {
		if (showing_dialog) {
			string newshowtext = "";
			if (update_count < updates_per_word) {
				update_count++;
			}
			else {
				if (dialog_word_count == 0) {
					dialog_word_count = realtext.Length;
					actual_dw_count = 0;
				}
				if (actual_dw_count < dialog_word_count) {
					if ((actual_dw_count%words_per_sound)==0) {
						gm.LoadAudio(0);
						gm.PlayAudio();
					}
					actual_dw_count++;
					newshowtext = realtext.Substring(0,actual_dw_count);//getChars(realtext,actual_dw_count);
					dialog_text = newshowtext;
				}
				else {
					showing_dialog = false;
				}
				update_count=0;
			}
		}
		else {
			dialog_word_count=0;
			actual_dw_count=0;
			dialog_text = realtext;
		}
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

	public void showchoicebox(string[] choices)
	{
		choices_text = choices;
		choice_number = -1;
		show_choicebox_GUI = true;
	}

	public void showface(int pos, int personagem, int faceindex)
	{
		Sprite face_sprite = gm.face_sets [gm.face_divider [personagem]+faceindex];//corrigir
		face_images [pos] = face_sprite;
		face_names [pos] = gm.char_names [personagem];
		active_talk = pos;
		show_face_GUI = true;
	}
	
	public void showbigimage(int n, float px, float py, float xdev, float ydev, float fsize,string texto, Color tc, TextAnchor talin)
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
		galin = talin;
		show_bigimage_GUI = true;
	}

	public void hideppbutton()
	{
		show_intbutton_GUI = false;
	}

	public void hidedialogbox()
	{
		show_dialogbox_GUI = false;
	}

	public void hideitem()
	{
		face_images [2] = null;
	}

	public void hidebigimage()
	{
		show_bigimage_GUI = false;
	}
	
	public void hidechoicebox()
	{
		show_choicebox_GUI = false;
	}

	public void hideface(int pos)
	{
		face_images [pos] = null;
		face_names [pos] = "";
		show_face_GUI = false;
	}

	public int selected_choice {
		get {return choice_number;}
	}

	public float PlayerHeight {
		get {return player_height;}
		set {player_height = value;}
	}

	public string[] PlayerNotes {
		get {return playernotes;}
		set {playernotes = value;}
	}

	public bool ShowingDialog {
		get {return showing_dialog;}
	}

	public bool ShowingIntButton {
		get {return show_intbutton_GUI;}
	}

	public bool ShowingBigImage {
		get {return show_bigimage_GUI;}
	}

	public bool ShowingFace {
		get {return show_face_GUI;}
	}

	public bool ShowingDialogBoxGUI {
		get {return show_dialogbox_GUI;}
	}

	public bool ShowingChoiceBoxGUI {
		get {return show_choicebox_GUI;}
	}

	public bool ShowingInventoryGUI{
		get {return show_inventory_GUI;}
	}

	public bool ShowingProfilesGUI {
		get {return show_profiles_GUI;}
	}

	public bool ShowingBacklogGUI {
		get {return show_backlog_GUI;}
	}

	public bool ShowingNotesGUI {
		get {return show_notes_GUI;}
	}

	public bool ShowingQuickMenuGUI {
		get {return show_quickmenu_GUI;}
		set {show_quickmenu_GUI = value;}
	}

	public void showExamineGUI()
	{
		//Definir area do botao de interacao
		Vector3 p1 = gm.cam.WorldToScreenPoint (new Vector3 (0, player_height, 0));
		Vector3 p2 = gm.cam.WorldToScreenPoint (new Vector3 (0, 0, 0));
		float char_height = (p1 - p2).y;
		GUI.BeginGroup(new Rect((Wdef-intbutton_width*3)/2,Hdef/2-intbutton_height-char_height,intbutton_width*3,3*intbutton_height+char_height));
		//Desenhar botao de interacao
		GUIStyle intbtnstyle = new GUIStyle ();
		intbtnstyle.normal.background = gm.menu_icons [0].texture;
		bool intbtn = GUI.Button(new Rect(intbutton_width,0,intbutton_width,intbutton_height),"",intbtnstyle);
		if (intbtn)
		{
			//colocar acao do botao - iniciar dialogo
			leftmouse_pressed = true;
		}
		GUIStyle tooltipstyle = GUI.skin.GetStyle ("Tooltip");
		tooltipstyle.fontSize = Mathf.RoundToInt(intbutton_height / 3);
		string tooltiptext = (Teclas.Confirma+" - Examinar");
		Rect tooltiparea = new Rect (0, 2 * intbutton_height + char_height, 3 * intbutton_width, intbutton_height);
		DrawOutline (tooltiparea, tooltiptext, tooltipstyle, Color.black, Color.white);
		
		GUI.EndGroup();
	}
	
	public void showQuickmenuGUI()
	{
		//Definir area dos botoes de acesso
		float mgwidth = intbutton_width;
		float mgheight = intbutton_height*4;
		
		float dpos = Wdef - QM_movecounter*(menu_width/10) - mgwidth;
		
		GUI.BeginGroup(new Rect(dpos-lbutton_width,(Hdef-mgheight)/3,mgwidth+lbutton_width,mgheight));
		GUIStyle tooltipstyle = GUI.skin.GetStyle ("Tooltip");
		tooltipstyle.fontSize = Mathf.RoundToInt(intbutton_height / 3);
		//Desenhar botoes de acesso
		//Botao 1 - Inventorio
		GUIStyle inventory_style = new GUIStyle();
		inventory_style.normal.background = gm.menu_icons[1].texture;
		
		Rect invrect = new Rect (lbutton_width, 0, intbutton_width, intbutton_height);
		bool invbtn = GUI.Button(invrect,"","SlotBackground");
		GUI.Box(invrect,"",inventory_style);
		bool hoverinv = HoverCheck (invrect);
		if (hoverinv)
		{
			if (!hoverqmsoundplayed[0])
			{
				gm.LoadAudio(5);//soundplayer.loadsound(5);
				gm.PlayAudio();//soundplayer.playsound();
				hoverqmsoundplayed[0] = true;
			}
			string tooltiptext = ("Inventório");
			Rect tooltiparea = new Rect (0,0, lbutton_width, intbutton_height);
			DrawOutline (tooltiparea, tooltiptext, tooltipstyle, Color.black, Color.white);
		}else
		{
			hoverqmsoundplayed[0] = false;
		}
		if (invbtn)
		{
			gm.LoadAudio(4);//soundplayer.loadsound(4);
			gm.PlayAudio();//soundplayer.playsound();
			if (show_inventory_GUI)
			{
				IM_Appear = false;
				gm.unlockplayer();//persona.unlockplayer();
			}else
			{
				show_inventory_GUI = true;
				show_profiles_GUI = false;
				show_backlog_GUI = false;
				show_notes_GUI = false;
				IM_Appear = true;
				gm.lockplayer();//persona.lockplayer();
			}
		}
		//Botao 2 - Profiles
		GUIStyle profiles_style = new GUIStyle();
		profiles_style.normal.background = gm.menu_icons[2].texture;
		
		Rect prfrect = new Rect(lbutton_width,intbutton_height,intbutton_width,intbutton_height);
		bool prbtn = GUI.Button(prfrect,"","SlotBackground");
		GUI.Box(prfrect,"",profiles_style);
		bool hoverprf = HoverCheck (prfrect);
		if (hoverprf)
		{
			if (!hoverqmsoundplayed[1])
			{
				gm.LoadAudio(5);//soundplayer.loadsound(5);
				gm.PlayAudio();//soundplayer.playsound();
				hoverqmsoundplayed[1] = true;
			}
			string tooltiptext = ("Perfis");
			Rect tooltiparea = new Rect (0,intbutton_height, lbutton_width, intbutton_height);
			DrawOutline (tooltiparea, tooltiptext, tooltipstyle, Color.black, Color.white);
		}else
		{
			hoverqmsoundplayed[1] = false;
		}
		if (prbtn)
		{
			gm.LoadAudio(4);//soundplayer.loadsound(4);
			gm.PlayAudio();//soundplayer.playsound();;
			if (show_profiles_GUI)
			{
				IM_Appear = false;
				gm.unlockplayer();//persona.unlockplayer();
			}else
			{
				show_inventory_GUI = false;
				show_profiles_GUI = true;
				show_backlog_GUI = false;
				show_notes_GUI = false;
				IM_Appear = true;
				gm.lockplayer();//persona.lockplayer();
			}
		}
		//Botao 3 - Backlog
		GUIStyle backlog_style = new GUIStyle();
		backlog_style.normal.background = gm.menu_icons[3].texture;
		
		Rect blrect = new Rect(lbutton_width,intbutton_height*2,intbutton_width,intbutton_height);
		bool blbtn = GUI.Button(blrect,"","SlotBackground");
		GUI.Box(blrect,"",backlog_style);
		bool hoverbl = HoverCheck (blrect);
		if (hoverbl)
		{
			if (!hoverqmsoundplayed[2])
			{
				gm.LoadAudio(5);//soundplayer.loadsound(5);
				gm.PlayAudio();//soundplayer.playsound();
				hoverqmsoundplayed[2] = true;
			}
			string tooltiptext = ("Arquivo");
			Rect tooltiparea = new Rect (0,intbutton_height*2, lbutton_width, intbutton_height);
			DrawOutline (tooltiparea, tooltiptext, tooltipstyle, Color.black, Color.white);
		}
		else
		{
			hoverqmsoundplayed[2] = false;
		}
		if (blbtn)
		{
			gm.LoadAudio(4);//soundplayer.loadsound(4);
			gm.PlayAudio();//soundplayer.playsound();
			if (show_backlog_GUI)
			{
				IM_Appear = false;
				gm.unlockplayer();//persona.unlockplayer();
			}else
			{
				show_backlog_GUI = true;
				show_inventory_GUI = false;
				show_profiles_GUI = false;
				show_notes_GUI = false;
				IM_Appear = true;
				gm.lockplayer();//persona.lockplayer();
			}
		}
		//Botao 4 - Anotacoes
		GUIStyle anot_style = new GUIStyle();
		anot_style.normal.background = gm.menu_icons[4].texture;
		
		Rect arect = new Rect(lbutton_width,intbutton_height*3,intbutton_width,intbutton_height);
		bool abtn = GUI.Button(arect,"","SlotBackground");
		GUI.Box(arect,"",anot_style);
		bool hovera = HoverCheck (arect);
		if (hovera)
		{
			if (!hoverqmsoundplayed[3])
			{
				gm.LoadAudio(5);//soundplayer.loadsound(5);
				gm.PlayAudio();//soundplayer.playsound();
				hoverqmsoundplayed[3] = true;
			}
			string tooltiptext = ("Anotações");
			Rect tooltiparea = new Rect (0,intbutton_height*3, lbutton_width, intbutton_height);
			DrawOutline (tooltiparea, tooltiptext, tooltipstyle, Color.black, Color.white);
		}else
		{
			hoverqmsoundplayed[3] = false;
		}
		if (abtn)
		{
			gm.LoadAudio(4);//soundplayer.loadsound(4);
			gm.PlayAudio();//soundplayer.playsound();
			if (show_notes_GUI)
			{
				IM_Appear = false;
				gm.unlockplayer();//persona.unlockplayer();
			}else
			{
				show_notes_GUI = true;
				show_backlog_GUI = false;
				show_inventory_GUI = false;
				show_profiles_GUI = false;
				IM_Appear = true;
				gm.lockplayer();//persona.lockplayer();
			}
		}
		
		GUI.EndGroup();
		
	}
	

	public void showInventoryGUI()
	{
		float lpos = Wdef - menu_width;
		
		if (IM_Appear == true)
		{
			if (QM_movecounter < 10)
			{
				lpos = Wdef - QM_movecounter*(menu_width/10);
				QM_movecounter++;
			}
		}else
		{
			if (QM_movecounter > 0)
			{
				lpos = Wdef - QM_movecounter*(menu_width/10); 
				QM_movecounter--;
			}else
			{
				QM_movecounter = 0;
				show_inventory_GUI = false;
			}
		}
		
		if (!show_inventory_GUI) {return;}
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
		Rect laarea = new Rect(0.02f*lowarea_width,2*lowarea_height/5,slot_width,slot_height);
		bool leftarrow = GUI.Button(laarea,"","ArrowLBackground");
		bool lahover = HoverCheck (laarea);
		if (lahover)
		{
			if (!hoverarsoundplayed[0])
			{
				gm.LoadAudio(5);//soundplayer.loadsound(5);
				gm.PlayAudio();//soundplayer.playsound();
				hoverarsoundplayed[0] = true;
			}
		}else
		{
			hoverarsoundplayed[0] = false;
		}
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
		Rect raarea = new Rect(0.98f*lowarea_width-slot_width,2*lowarea_height/5,slot_width,slot_height);
		bool rightarrow = GUI.Button(raarea,"","ArrowRBackground");
		bool rahover = HoverCheck (raarea);
		if (rahover)
		{
			if (!hoverarsoundplayed[1])
			{
				gm.LoadAudio(5);//soundplayer.loadsound(5);
				gm.PlayAudio();//soundplayer.playsound();
				hoverarsoundplayed[1] = true;
			}
		}else
		{
			hoverarsoundplayed[1] = false;
		}
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
		GUI.BeginGroup(new Rect((lowarea_width-grid_width)/2,0,grid_width,grid_height));
		
		//Desenhar area central inferior(item slots)
		bool[,] itemshow= new bool[4,4];
		bool[,] itemhover = new bool[4,4];
		Rect[,] itemarea = new Rect[4,4];
		for (int i = 0;i< 4;i++)
		{
			float posX = i*slot_width;
			for (int j=0; j<4; j++)
			{
				float posY = j*slot_height;
				itemarea[j,i] = new Rect(posX,posY,slot_width,slot_height);
				itemhover[j,i] = HoverCheck(itemarea[j,i]);
				if (itemhover[j,i])
				{
					if (!hoverinvsoundplayed[j,i])
					{
						gm.LoadAudio(5);//soundplayer.loadsound(5);
						gm.PlayAudio();//soundplayer.playsound();
						hoverinvsoundplayed[j,i] = true;
					}
				}else
				{
					hoverinvsoundplayed[j,i] = false;
				}

				itemshow[j,i] = GUI.Button (itemarea[j,i],"","SlotBackground");
				if (gm.ItemGrid[j,i,page] != null)
				{
					GUIStyle litimg = new GUIStyle();
					litimg.normal.background = gm.ItemGrid[j,i,page].getSprite().texture;
					//itemshow[j,i] = GUI.Button (itemarea[j,i],"","SlotBackground");
					GUI.Box (itemarea[j,i],"",litimg);
					//if (itemshow[j,i]) {...}
				}else
				{
					GUI.Box (itemarea[j,i],"","SlotBackground");
				}
				if (itemshow[j,i])
				{
					gm.LoadAudio(5);//soundplayer.loadsound(5);
					gm.PlayAudio();//soundplayer.playsound();;
					selectedItem = gm.ItemGrid[j,i,page];
				}
			}
		}
		GUI.EndGroup();
		
		GUIStyle numlabel = GUI.skin.GetStyle("Tooltip");
		numlabel.normal.textColor = Color.black;
		numlabel.fontSize = Mathf.RoundToInt(lbutton_fontsize);
		GUI.Box (new Rect (0, lowarea_height-(lbutton_height/2), lowarea_width, lbutton_height / 2), ((page+1) + "/3"), numlabel);
		
		GUI.EndGroup();
		
		//Definir area dos botoes dos menus
		GUI.BeginGroup(new Rect(0,menu_height-btnarea_height,btnarea_width,btnarea_height));
		
		//Desenhar area dos botoes dos menus(botoes)
		GUIStyle lbutton = GUI.skin.GetStyle("ButtonBackground");
		lbutton.fontSize = Mathf.RoundToInt(lbutton_fontsize);
		
		Rect savebuttonarea = new Rect(0,0,lbutton_width,lbutton_height);
		bool savebutton = GUI.Button(savebuttonarea,"Salvar",lbutton);
		bool savehover = HoverCheck (savebuttonarea);
		if (savehover)
		{
			if (!hoverlbsoundplayed[0])
			{
				gm.LoadAudio(5);//soundplayer.loadsound(5);
				gm.PlayAudio();//soundplayer.playsound();
				hoverlbsoundplayed[0] = true;
			}
		}else
		{
			hoverlbsoundplayed[0] = false;
		}
		if (savebutton) {
			gm.SaveGame("save00");
			Debug.Log("JOGO SALVO!");
		}
		
		Rect loadbuttonarea = new Rect(lbutton_width,0,lbutton_width,lbutton_height);
		bool loadbutton = GUI.Button(loadbuttonarea,"Carregar",lbutton);
		bool loadhover = HoverCheck (loadbuttonarea);
		if (loadhover)
		{
			if (!hoverlbsoundplayed[1])
			{
				gm.LoadAudio(5);//soundplayer.loadsound(5);
				gm.PlayAudio();//soundplayer.playsound();
				hoverlbsoundplayed[1] = true;
			}
		}else
		{
			hoverlbsoundplayed[1] = false;
		}
		
		Rect confbuttonarea = new Rect(0,btnarea_height-lbutton_height,lbutton_width,lbutton_height);
		bool confbutton = GUI.Button(confbuttonarea,"Configurações",lbutton);
		bool confcheck = HoverCheck (confbuttonarea);
		if (confcheck)
		{
			if (!hoverlbsoundplayed[2])
			{
				gm.LoadAudio(5);//soundplayer.loadsound(5);
				gm.PlayAudio();//soundplayer.playsound();
				hoverlbsoundplayed[2] = true;
			}
		}else
		{
			hoverlbsoundplayed[2] = false;
		}
		
		//Botao de fechar menu
		Rect closebuttonarea = new Rect(lbutton_width,btnarea_height-lbutton_height,lbutton_width,lbutton_height);
		bool closebutton = GUI.Button(closebuttonarea,"Sair do jogo",lbutton);
		bool closecheck = HoverCheck (closebuttonarea);
		if (closecheck)
		{
			if (!hoverlbsoundplayed[3])
			{
				gm.LoadAudio(5);//soundplayer.loadsound(5);
				gm.PlayAudio();//soundplayer.playsound();
				hoverlbsoundplayed[3] = true;
			}
		}else
		{
			hoverlbsoundplayed[3] = false;
		}
		if (closebutton)
		{
			gm.LoadAudio(4);//soundplayer.loadsound(4);
			gm.PlayAudio();//soundplayer.playsound();
			gm.TransiteScene("Intro", "init_spot");
			//Application.Quit();
		}
		
		GUI.EndGroup();		
		
		GUI.EndGroup();
	}
	
	public void showProfilesGUI()
	{

	//float charslot_width;
	//float charslot_height;
	//float slotarea_width;
	//float slotarea_height;
	//float imagearea_width;
	//float imagearea_height;
	//float descarea_width;
	//float descarea_height;
	
		float lpos = Wdef - menu_width;
		
		if (IM_Appear == true)
		{
			if (QM_movecounter < 10)
			{
				lpos = Wdef - QM_movecounter*(menu_width/10);
				QM_movecounter++;
			}
		}else
		{
			if (QM_movecounter > 0)
			{
				lpos = Wdef - QM_movecounter*(menu_width/10); 
				QM_movecounter--;
			}else
			{
				QM_movecounter = 0;
				show_profiles_GUI = false;
			}
		}
		
		if (!show_profiles_GUI) {return;}
		
		//Fazer a area delimitante do menu
		GUI.BeginGroup(new Rect(lpos,Hdef-menu_height,menu_width,menu_height));
		
		//Desenhar o background do menu
		GUI.Box(new Rect(0,0,menu_width,menu_height),"","MenuBackground");
		
		//area superior
		GUI.BeginGroup(new Rect(0,0,slotarea_width,slotarea_height));
		
		GUI.Box(new Rect(0,0,slotarea_width,slotarea_height),"","TextBackground");
		//slot
		GUI.Box(new Rect((slotarea_width-charslot_width)/2,(slotarea_height-charslot_height)/2,charslot_width,charslot_height),"","TextBackground");
		GUIStyle facestyl = new GUIStyle ();
		facestyl.normal.background = gm.face_sets[selectedProfile].texture;
		GUI.Box(new Rect((slotarea_width-charslot_width)/2,(slotarea_height-charslot_height)/2,charslot_width,charslot_height),"",facestyl);
		//setas
		Rect raarea = new Rect (0.9f * slotarea_width - charslot_width, 0.125f * slotarea_height, charslot_width, charslot_height);
		bool rightarrow = GUI.Button(raarea,"","ArrowRBackground");
		bool rahover = HoverCheck (raarea);
		if (rahover)
		{
			if (!hoverarsoundplayed[1])
			{
				gm.LoadAudio(5);//soundplayer.loadsound(5);
				gm.PlayAudio();//soundplayer.playsound();
				hoverarsoundplayed[1] = true;
			}
		}else
		{
			hoverarsoundplayed[1] = false;
		}
		if (rightarrow)
		{
			if (selectedProfile < gm.Profiles.Length-1)
			{
				selectedProfile = selectedProfile + 1;
			}else
			{
				selectedProfile = 0;
			}
		}
		Rect laarea = new Rect(0.1f*slotarea_width,0.125f*slotarea_height,charslot_width,charslot_height);
		bool leftarrow = GUI.Button(laarea,"","ArrowLBackground");
		bool lahover = HoverCheck (laarea);
		if (lahover)
		{
			if (!hoverarsoundplayed[0])
			{
				gm.LoadAudio(5);//soundplayer.loadsound(5);
				gm.PlayAudio();//soundplayer.playsound();
				hoverarsoundplayed[0] = true;
			}
		}else
		{
			hoverarsoundplayed[0] = false;
		}
		if (leftarrow)
		{
			if (selectedProfile > 0)
			{
				selectedProfile = selectedProfile -1;
			}else
			{
				selectedProfile = gm.Profiles.Length-1;
			}			
		}
		GUI.EndGroup();
		
		//area central
		GUI.BeginGroup (new Rect (0, slotarea_height, imagearea_width, imagearea_height));
		
		GUIStyle bfacestyl = new GUIStyle ();
		bfacestyl.normal.background = gm.face_sets[selectedProfile].texture;
		GUI.Box(new Rect((imagearea_width-imagearea_height)/2,0,imagearea_height,imagearea_height),"",bfacestyl);
		GUIStyle ftxtstyl = GUI.skin.FindStyle("Tooltip");
		ftxtstyl.fontSize = Mathf.RoundToInt(intbutton_height / 3);
		DrawOutline (new Rect (0, imagearea_height / 2, imagearea_width, imagearea_height / 2), gm.Profiles[selectedProfile].getInfo(), ftxtstyl, Color.black, Color.white);
		GUI.EndGroup ();
		
		//area inferior
		GUI.BeginGroup (new Rect (0, slotarea_height + imagearea_height, descarea_width, descarea_height));
		
		GUIStyle descstyl = GUI.skin.FindStyle ("TextBackground");
		descstyl.fontSize = Mathf.RoundToInt(desc_fontsize);
		GUI.Box (new Rect (0, 0, descarea_width, descarea_height), gm.Profiles[selectedProfile].Descricao, descstyl);
		
		GUI.EndGroup ();
		
		GUI.BeginGroup(new Rect(0,menu_height-btnarea_height,btnarea_width,btnarea_height));
		
		//Desenhar area dos botoes dos menus(botoes)
		GUIStyle lbutton = GUI.skin.GetStyle("ButtonBackground");
		lbutton.fontSize = Mathf.RoundToInt(lbutton_fontsize);
		
		Rect savebuttonarea = new Rect(0,0,lbutton_width,lbutton_height);
		bool savebutton = GUI.Button(savebuttonarea,"Salvar",lbutton);
		bool savehover = HoverCheck (savebuttonarea);
		if (savehover)
		{
			if (!hoverlbsoundplayed[0])
			{
				gm.LoadAudio(5);//soundplayer.loadsound(5);
				gm.PlayAudio();//soundplayer.playsound();
				hoverlbsoundplayed[0] = true;
			}
		}else
		{
			hoverlbsoundplayed[0] = false;
		}
		if (savebutton) {
			gm.SaveGame("save00");
			Debug.Log("JOGO SALVO!");
		}
		
		Rect loadbuttonarea = new Rect(lbutton_width,0,lbutton_width,lbutton_height);
		bool loadbutton = GUI.Button(loadbuttonarea,"Carregar",lbutton);
		bool loadhover = HoverCheck (loadbuttonarea);
		if (loadhover)
		{
			if (!hoverlbsoundplayed[1])
			{
				gm.LoadAudio(5);//soundplayer.loadsound(5);
				gm.PlayAudio();//soundplayer.playsound();
				hoverlbsoundplayed[1] = true;
			}
		}else
		{
			hoverlbsoundplayed[1] = false;
		}
		
		Rect confbuttonarea = new Rect(0,btnarea_height-lbutton_height,lbutton_width,lbutton_height);
		bool confbutton = GUI.Button(confbuttonarea,"Configurações",lbutton);
		bool confcheck = HoverCheck (confbuttonarea);
		if (confcheck)
		{
			if (!hoverlbsoundplayed[2])
			{
				gm.LoadAudio(5);//soundplayer.loadsound(5);
				gm.PlayAudio();//soundplayer.playsound();
				hoverlbsoundplayed[2] = true;
			}
		}else
		{
			hoverlbsoundplayed[2] = false;
		}
		
		//Botao de fechar menu
		Rect closebuttonarea = new Rect(lbutton_width,btnarea_height-lbutton_height,lbutton_width,lbutton_height);
		bool closebutton = GUI.Button(closebuttonarea,"Sair do jogo",lbutton);
		bool closecheck = HoverCheck (closebuttonarea);
		if (closecheck)
		{
			if (!hoverlbsoundplayed[3])
			{
				gm.LoadAudio(5);//soundplayer.loadsound(5);
				gm.PlayAudio();//soundplayer.playsound();
				hoverlbsoundplayed[3] = true;
			}
		}else
		{
			hoverlbsoundplayed[3] = false;
		}
		if (closebutton)
		{
			gm.LoadAudio(5);//soundplayer.loadsound(5);
			gm.PlayAudio();//soundplayer.playsound();
			gm.TransiteScene("Intro", "init_spot");
			//Application.Quit();
		}
		
		GUI.EndGroup();
		
		GUI.EndGroup ();
	}
	
	public void showBacklogGUI(){
		//float charslot_width;
		//float charslot_height;
		//float slotarea_width;
		//float slotarea_height;
		//float logselect_width;
		//float logselect_height;
		//float logcontent_width;
		//float logcontent_height;
		
		float lpos = Wdef - menu_width;
		
		if (IM_Appear == true)
		{
			if (QM_movecounter < 10)
			{
				lpos = Wdef - QM_movecounter*(menu_width/10);
				QM_movecounter++;
			}
		}else
		{
			if (QM_movecounter > 0)
			{
				lpos = Wdef - QM_movecounter*(menu_width/10); 
				QM_movecounter--;
			}else
			{
				QM_movecounter = 0;
				backlogList = null;
				selectedConversaIndex = -1;
				show_backlog_GUI = false;
			}
		}
		
		if (!show_backlog_GUI) {return;}
		
		//Fazer a area delimitante do menu
		GUI.BeginGroup(new Rect(lpos,Hdef-menu_height,menu_width,menu_height));
		
		//Desenhar o background do menu
		GUI.Box(new Rect(0,0,menu_width,menu_height),"","MenuBackground");
		
		//area superior
		GUI.BeginGroup(new Rect(0,0,slotarea_width,slotarea_height));
		
		GUI.Box(new Rect(0,0,slotarea_width,slotarea_height),"","TextBackground");
		//slot
		GUI.Box(new Rect((slotarea_width-charslot_width)/2,(slotarea_height-charslot_height)/2,charslot_width,charslot_height),"","TextBackground");
		GUIStyle facestyl = new GUIStyle ();
		facestyl.normal.background = gm.face_sets[selectedProfile].texture;
		GUI.Box(new Rect((slotarea_width-charslot_width)/2,(slotarea_height-charslot_height)/2,charslot_width,charslot_height),"",facestyl);
		//setas
		Rect raarea = new Rect (0.9f * slotarea_width - charslot_width, 0.125f * slotarea_height, charslot_width, charslot_height);
		bool rightarrow = GUI.Button(raarea,"","ArrowRBackground");
		bool rahover = HoverCheck (raarea);
		if (rahover)
		{
			if (!hoverarsoundplayed[1])
			{
				gm.LoadAudio(5);//soundplayer.loadsound(5);
				gm.PlayAudio();//soundplayer.playsound();
				hoverarsoundplayed[1] = true;
			}
		}else
		{
			hoverarsoundplayed[1] = false;
		}
		if (rightarrow)
		{
			selectedConversaIndex = -1;
			backlogList = null;
			if (selectedProfile < gm.Profiles.Length-1)
			{
				selectedProfile = selectedProfile + 1;
			}else
			{
				selectedProfile = 0;
			}
		}
		Rect laarea = new Rect(0.1f*slotarea_width,0.125f*slotarea_height,charslot_width,charslot_height);
		bool leftarrow = GUI.Button(laarea,"","ArrowLBackground");
		bool lahover = HoverCheck (laarea);
		if (lahover)
		{
			if (!hoverarsoundplayed[0])
			{
				gm.LoadAudio(5);//soundplayer.loadsound(5);
				gm.PlayAudio();//soundplayer.playsound();
				hoverarsoundplayed[0] = true;
			}
		}else
		{
			hoverarsoundplayed[0] = false;
		}
		if (leftarrow)
		{
			selectedConversaIndex = -1;
			backlogList = null;
			if (selectedProfile > 0)
			{
				selectedProfile = selectedProfile -1;
			}else
			{
				selectedProfile = gm.Profiles.Length-1;
			}			
		}
		GUI.EndGroup();
		
		if (backlogList == null && show_backlog_GUI) {
			if(selectedProfile == 0){
				//backlogList = backlog.getPersonagemBacklog ("");
				backlogList = gm.getBacklogFrom("Player");//backlog.getPersonagemBacklog ("");
			}else if(selectedProfile == 1){
				backlogList = gm.getBacklogFrom("Eduardo Hastings");//backlog.getPersonagemBacklog ("Eduardo Hastings");
			}
		}
		
		//Definir area superior backlog
		GUI.BeginGroup (new Rect (0, slotarea_height, logselect_width, logselect_height));
		
		GUIStyle text_gui = GUI.skin.GetStyle("ButtonBackground");
		text_gui.fontSize = Mathf.RoundToInt(dialog_fontsize/2);
		
		scrollPosition = GUI.BeginScrollView (new Rect(0, 0, logselect_width, logselect_height),scrollPosition, new Rect(0, 0, 0.94f*logselect_width, (logselect_height/4)*backlogList.Count));
		for(int i = 0; i < backlogList.Count; i++){
			
			//Desenhar o texto da caixa de texto
			Conversa conversa = (Conversa)backlogList[i];
			bool backlogItemClick =GUI.Button(new Rect(0, i*(logselect_height/4), 0.94f*logselect_width, logselect_height /4),conversa.getRotulo(),text_gui);
			
			if(backlogItemClick){
				selectedConversaIndex = i;
			}
		}
		GUI.EndScrollView ();
		GUI.EndGroup ();	
		
		//Grupo dos dialogos de cada conversa
		GUI.BeginGroup (new Rect (0, slotarea_height + logselect_height, logcontent_width, logcontent_height));
		
		GUIStyle text_gui2 = GUI.skin.GetStyle ("TextBackground");
		text_gui2.fontSize = Mathf.RoundToInt(dialog_fontsize/2.3f);
		text_gui2.alignment = TextAnchor.UpperLeft;
		text_gui2.padding.left = Mathf.RoundToInt(0.02f*logcontent_width);
		
		if(selectedConversaIndex > -1){
			scrollPosition2 = GUI.BeginScrollView (new Rect(0, 0, logcontent_width, logcontent_height),scrollPosition2, new Rect(0, 0, 0.94f*logcontent_width, (logcontent_height/4)*((Conversa)backlogList[selectedConversaIndex]).getDialogos().Count));
			
			for(int i = 0; i < ((Conversa)backlogList[selectedConversaIndex]).getDialogos().Count; i++){
				
				DialogLine dl =((DialogLine)((Conversa)backlogList[selectedConversaIndex]).getDialogos()[i]);
				
				GUI.Box(new Rect(0, i*(logcontent_height/4), 0.94f*logcontent_width, logcontent_height /4), dl.getPersonagem() +" - "+dl.getTexto(),text_gui2);
				
			}
			GUI.EndScrollView ();
			
		}
		
		text_gui2.alignment = TextAnchor.MiddleCenter;
		GUI.EndGroup ();
		
		GUI.BeginGroup(new Rect(0,menu_height-btnarea_height,btnarea_width,btnarea_height));
		
		//Desenhar area dos botoes dos menus(botoes)
		GUIStyle lbutton = GUI.skin.GetStyle("ButtonBackground");
		lbutton.fontSize = Mathf.RoundToInt(lbutton_fontsize);
		
		Rect savebuttonarea = new Rect(0,0,lbutton_width,lbutton_height);
		bool savebutton = GUI.Button(savebuttonarea,"Salvar",lbutton);
		bool savehover = HoverCheck (savebuttonarea);
		if (savehover)
		{
			if (!hoverlbsoundplayed[0])
			{
				gm.LoadAudio(5);//soundplayer.loadsound(5);
				gm.PlayAudio();//soundplayer.playsound();
				hoverlbsoundplayed[0] = true;
			}
		}else
		{
			hoverlbsoundplayed[0] = false;
		}
		if (savebutton) {
			gm.SaveGame("save00");
			Debug.Log("JOGO SALVO!");
		}
		
		Rect loadbuttonarea = new Rect(lbutton_width,0,lbutton_width,lbutton_height);
		bool loadbutton = GUI.Button(loadbuttonarea,"Carregar",lbutton);
		bool loadhover = HoverCheck (loadbuttonarea);
		if (loadhover)
		{
			if (!hoverlbsoundplayed[1])
			{
				gm.LoadAudio(5);//soundplayer.loadsound(5);
				gm.PlayAudio();//soundplayer.playsound();
				hoverlbsoundplayed[1] = true;
			}
		}else
		{
			hoverlbsoundplayed[1] = false;
		}
		
		Rect confbuttonarea = new Rect(0,btnarea_height-lbutton_height,lbutton_width,lbutton_height);
		bool confbutton = GUI.Button(confbuttonarea,"Configurações",lbutton);
		bool confcheck = HoverCheck (confbuttonarea);
		if (confcheck)
		{
			if (!hoverlbsoundplayed[2])
			{
				gm.LoadAudio(5);//soundplayer.loadsound(5);
				gm.PlayAudio();//soundplayer.playsound();
				hoverlbsoundplayed[2] = true;
			}
		}else
		{
			hoverlbsoundplayed[2] = false;
		}
		
		//Botao de fechar menu
		Rect closebuttonarea = new Rect(lbutton_width,btnarea_height-lbutton_height,lbutton_width,lbutton_height);
		bool closebutton = GUI.Button(closebuttonarea,"Sair do jogo",lbutton);
		bool closecheck = HoverCheck (closebuttonarea);
		if (closecheck)
		{
			if (!hoverlbsoundplayed[3])
			{
				gm.LoadAudio(5);//soundplayer.loadsound(5);
				gm.PlayAudio();//soundplayer.playsound();
				hoverlbsoundplayed[3] = true;
			}
		}else
		{
			hoverlbsoundplayed[3] = false;
		}
		if (closebutton)
		{
			gm.LoadAudio(5);//soundplayer.loadsound(5);
			gm.PlayAudio();//soundplayer.playsound();
			gm.TransiteScene("Intro", "init_spot");
			//Application.Quit();
		}
		
		GUI.EndGroup();
		
		GUI.EndGroup();
		
		
	}
	
	public void showNotesGUI()
	{
		float lpos = Wdef - menu_width;
		
		if (IM_Appear == true)
		{
			if (QM_movecounter < 10)
			{
				lpos = Wdef - QM_movecounter*(menu_width/10);
				QM_movecounter++;
			}
		}else
		{
			if (QM_movecounter > 0)
			{
				lpos = Wdef - QM_movecounter*(menu_width/10); 
				QM_movecounter--;
			}else
			{
				QM_movecounter = 0;
				show_notes_GUI = false;
			}
		}
		
		if (!show_notes_GUI) {return;}
		
		//Fazer a area delimitante do menu
		GUI.BeginGroup(new Rect(lpos,Hdef-menu_height,menu_width,menu_height));
		
		//Desenhar o background do menu
		GUI.Box(new Rect(0,0,menu_width,menu_height),"","MenuBackground");
		
		Rect raarea = new Rect (0.95f * slotarea_width - charslot_width/2, slotarea_height-lbutton_height, charslot_width/2, charslot_height/2);
		bool rightarrow = GUI.Button(raarea,"","ArrowRBackground");
		bool rahover = HoverCheck (raarea);
		if (rahover)
		{
			if (!hoverarsoundplayed[1])
			{
				gm.LoadAudio(5);//soundplayer.loadsound(5);
				gm.PlayAudio();//soundplayer.playsound();
				hoverarsoundplayed[1] = true;
			}
		}else
		{
			hoverarsoundplayed[1] = false;
		}
		if (rightarrow)
		{
			if (noteindex < playernotes.Length-1)
			{
				noteindex++;
			}else
			{
				noteindex = 0;
			}
		}
		Rect laarea = new Rect(0.05f*slotarea_width,slotarea_height-lbutton_height,charslot_width/2,charslot_height/2);
		bool leftarrow = GUI.Button(laarea,"","ArrowLBackground");
		bool lahover = HoverCheck (laarea);
		if (lahover)
		{
			if (!hoverarsoundplayed[0])
			{
				gm.LoadAudio(5);//soundplayer.loadsound(5);
				gm.PlayAudio();//soundplayer.playsound();
				hoverarsoundplayed[0] = true;
			}
		}else
		{
			hoverarsoundplayed[0] = false;
		}
		if (leftarrow)
		{
			if (noteindex > 0)
			{
				noteindex--;
			}else
			{
				noteindex = playernotes.Length-1;
			}			
		}
		
		GUIStyle numlabel = GUI.skin.GetStyle("Tooltip");
		numlabel.normal.textColor = Color.black;
		numlabel.fontSize = Mathf.RoundToInt(lbutton_fontsize);
		GUI.Box (new Rect (0, slotarea_height-lbutton_height, lowarea_width, lbutton_height), ("Página "+(noteindex+1)+" de "+playernotes.Length), numlabel);
		
		Rect txtarea = new Rect (0.05f * menu_width, slotarea_height+ menu_height*0.05f, menu_width* 0.9f, menu_height - btnarea_height - 0.05f * menu_height - slotarea_height);
		GUI.Box(new Rect(0,slotarea_height,menu_width,menu_height - slotarea_height -btnarea_height),"","DialogboxBackground");
		GUIStyle txtstyl = GUI.skin.FindStyle ("DialogtextBackground");
		txtstyl.fontSize = Mathf.RoundToInt(desc_fontsize);
		playernotes [noteindex] = GUI.TextArea (txtarea, playernotes [noteindex], 475,txtstyl);
		
		GUI.BeginGroup(new Rect(0,menu_height-btnarea_height,btnarea_width,btnarea_height));
		
		//Desenhar area dos botoes dos menus(botoes)
		GUIStyle lbutton = GUI.skin.GetStyle("ButtonBackground");
		lbutton.fontSize = Mathf.RoundToInt(lbutton_fontsize);
		
		Rect savebuttonarea = new Rect(0,0,lbutton_width,lbutton_height);
		bool savebutton = GUI.Button(savebuttonarea,"Salvar",lbutton);
		bool savehover = HoverCheck (savebuttonarea);
		if (savehover)
		{
			if (!hoverlbsoundplayed[0])
			{
				gm.LoadAudio(5);//soundplayer.loadsound(5);
				gm.PlayAudio();//soundplayer.playsound();
				hoverlbsoundplayed[0] = true;
			}
		}else
		{
			hoverlbsoundplayed[0] = false;
		}
		if (savebutton) {
			gm.SaveGame("save00");
			Debug.Log("JOGO SALVO!");
		}
		
		Rect loadbuttonarea = new Rect(lbutton_width,0,lbutton_width,lbutton_height);
		bool loadbutton = GUI.Button(loadbuttonarea,"Carregar",lbutton);
		bool loadhover = HoverCheck (loadbuttonarea);
		if (loadhover)
		{
			if (!hoverlbsoundplayed[1])
			{
				gm.LoadAudio(5);//soundplayer.loadsound(5);
				gm.PlayAudio();//soundplayer.playsound();
				hoverlbsoundplayed[1] = true;
			}
		}else
		{
			hoverlbsoundplayed[1] = false;
		}
		
		Rect confbuttonarea = new Rect(0,btnarea_height-lbutton_height,lbutton_width,lbutton_height);
		bool confbutton = GUI.Button(confbuttonarea,"Configurações",lbutton);
		bool confcheck = HoverCheck (confbuttonarea);
		if (confcheck)
		{
			if (!hoverlbsoundplayed[2])
			{
				gm.LoadAudio(5);//soundplayer.loadsound(5);
				gm.PlayAudio();//soundplayer.playsound();
				hoverlbsoundplayed[2] = true;
			}
		}else
		{
			hoverlbsoundplayed[2] = false;
		}
		
		//Botao de fechar menu
		Rect closebuttonarea = new Rect(lbutton_width,btnarea_height-lbutton_height,lbutton_width,lbutton_height);
		bool closebutton = GUI.Button(closebuttonarea,"Sair do jogo",lbutton);
		bool closecheck = HoverCheck (closebuttonarea);
		if (closecheck)
		{
			if (!hoverlbsoundplayed[3])
			{
				gm.LoadAudio(5);//soundplayer.loadsound(5);
				gm.PlayAudio();//soundplayer.playsound();
				hoverlbsoundplayed[3] = true;
			}
		}else
		{
			hoverlbsoundplayed[3] = false;
		}
		if (closebutton)
		{
			gm.LoadAudio(5);//soundplayer.loadsound(5);
			gm.PlayAudio();//soundplayer.playsound();
			gm.TransiteScene("Intro", "init_spot");
			//Application.Quit();
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
			b0styl.normal.background = gm.objectimgs[gn].texture;
		}else
		{
			b0styl.normal.background = null;
		}
		GUI.Box (new Rect (0, 0, bigimage_width, bigimage_height), "", b0styl);
		
		GUIStyle bstyl = GUI.skin.GetStyle("CentralTextBackground");
		bstyl.fontSize = gfsize;
		bstyl.alignment = galin;
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
		
		Rect passbuttonarea = new Rect ((dialogbox_width - dialogbox_width / 4) / 2, textarea_height+ ((dialogbox_height - textarea_height)/2), dialogbox_width / 4, (dialogbox_height - textarea_height)/2);
		GUIStyle passbuttonstyle = GUI.skin.FindStyle ("Tooltip");
		passbuttonstyle.fontSize = Mathf.RoundToInt(lbutton_fontsize);
		string passtext;
		if (showing_dialog)
		{
			passtext = Teclas.Confirma+" - Mostrar tudo";
		}else
		{
			passtext = Teclas.Confirma+" - Continuar";
		}
		DrawOutline (passbuttonarea, passtext, passbuttonstyle, Color.black, Color.white);


		//bool passbutton = GUI.Button (passbuttonarea,passtext,passbuttonstyle);
		//if (passbutton)
		//{
		//	passar o texto com botao
		//}
		
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
		Rect[] choiceboxes = new Rect[nchoices];
		bool[] hoverbox = new bool[nchoices];
		for (int i = 0;i<nchoices;i++)
		{
			choiceboxes[i] = new Rect((choicebox_width-choicetext_width)/2,((choicebox_height-choicetext_height)/2)+(i*choicetext_height),choicetext_width,choicetext_height);
			choicebuttons[i] = GUI.Button(choiceboxes[i],choices_text[i],text_gui);
			hoverbox[i] = HoverCheck(choiceboxes[i]);
			if (hoverbox[i])
			{
				if (!hoverchoicesoundplayed[i])
				{
					gm.LoadAudio(5);//soundplayer.loadsound(5);
					gm.PlayAudio();//soundplayer.playsound();
					hoverchoicesoundplayed[i] = true;
				}
			}else
			{
				hoverchoicesoundplayed[i] = false;
			}
			if (choicebuttons[i])
			{
				if (Time.timeScale != 0.0f) {
					gm.LoadAudio(4);//soundplayer.loadsound(4);
					gm.PlayAudio();//soundplayer.playsound();
					choice_number = i;
				}
				//colocar acao da escolha
			}
		}
		
		GUI.EndGroup();
	}
	
	public void showMainMenuGUI()
	{
		//Definir area dos botoes
		GUI.BeginGroup(new Rect((0.47f*Wdef-startbtn_width)/2,Hdef/2+startbtn_height*3.3f,2*startbtn_width,8*startbtn_height));
		
		//Desenhar botao de iniciar jogo
		bool intbtn = GUI.Button(new Rect(0.2f*startbtn_width,0,startbtn_width,0.8f*startbtn_height),"","NovoJogo");
		if (intbtn)
		{
			gm.InitializeGame();
			//TransiteScene("Cena1", "initial_spot");
		}
		bool loadbtn = GUI.Button(new Rect(0.5f*startbtn_width,0.8f*startbtn_height,startbtn_width,0.8f*startbtn_height),"","Carregar");
		if (loadbtn)
		{
			if (gm.LoadGame("save00")) {;
				gm.InitializeGame();
			}
		}
		
		bool optbtn = GUI.Button(new Rect(0.2f*startbtn_width,1.6f*startbtn_height,startbtn_width*0.8f,startbtn_height*0.8f),"","Opcoes");
		if (optbtn)
		{
			//Application.LoadLevel("InputManager");
		}
		
		bool extbtn = GUI.Button(new Rect(0.4f*startbtn_width,2.4f*startbtn_height,startbtn_width*0.7f,startbtn_height*0.8f),"","Sair");
		if (extbtn)
		{
			Application.Quit();
		}
		
		GUI.EndGroup();
		
	}
	
}

