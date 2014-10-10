using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public GameObject player;
	PlayerController persona;
	bool[]  eventlist;

	private Item selectedItem;
	private Inventorio inventorio;

	private GerenciadorEstados gerEstados;
        
        //testes do victor
	public Camera cam;

	bool cam_move;
	bool on_mainmenu; // variavel que controla se o jogador esta no menu principal
	bool menu_button_press;// variavel que controla se o botao de menu foi apertado
	bool show_menu_GUI;// variavel que controla se a gui do menu deve ser exibida
	bool show_dialogbox_GUI;// variavel que controla se a gui da caixa de dialogo deve ser exibida
	bool show_intbutton_GUI;// variavel que controla se a gui do botao de interacao deve ser exibida
	bool show_choicebox_GUI;// variavel que controla se a gui da caixa de escolha deve ser exibida
	bool show_face_GUI;// variavel que controla se a gui de exibicao da face deve ser exibida

	Item[,,] item_grid;//Matriz da representacao dos itens
	int page;//qual indice da 3a dimensao da matriz
	public Sprite[] face_sets;//Array com faces de cada personagem
	public string[] char_names;//Nomes de cada personagem
	public int[] face_divider;//indices do inicio do faceset de cada personagem

	string dialog_text;//variavel que guarda o texto a ser exibido no dialogo
	string[] choices_text;//variavel que guarda os textos das escolhas
	Sprite[] face_images;//variavel que guarda as imagens sendo exibidas (0 = face esquerda, 1 = face direita, 2 = imagem de item ao centro)

	public GUISkin game_skin;//GUISkin com todos os estilos de gui

	//variaveis que guardam tamanhos dos componentes dos menus *Mudar o static*
		//variaveis gerais (tamanho da janela de menu e da area dos botoes dos outros menus)
		// - A janela de menu cobre 1/3 da tela alinhado a direita
		// - A area dos botoes cobre apenas 10% da area do menu
	static float menu_width = Screen.width / 3;
	static float menu_height = Screen.height;
	static float btnarea_width = menu_width;
	static float btnarea_height = menu_height / 10;
	static float lbutton_width = btnarea_width / 2;
	static float lbutton_height = btnarea_height /2;
	static float lbutton_fontsize = lbutton_height / 2f;
		//variaveis do menu de itens (interface do inventorio)
		// - Area superior onde fica a imagem e nome do item cobre 40% da area do menu
		// 	-> Area da imagem fica em 80% da area superior, area do nome nos 20% restantes
		// - Area do meio onde fica o texto da descricao do item cobre 20% da area do menu
		// - Area inferior onde fica a lista de itens cobre 30% da area do menu
		//  -> O grid da area inferior exibe em formato de matriz 4x4, total de 16 itens
		//  -> As areas laterais do grid comportam as setas de mudanca de pagina
	static float uparea_width = menu_width;
	static float uparea_height = 4*menu_height/10;
	static float upimg_height = 8 * uparea_height / 10;
	static float upimg_width = upimg_height;
	static float midarea_width = menu_width;
	static float midarea_height = 2 * menu_height / 10;
	static float lowarea_width = menu_width;
	static float lowarea_height = 3 * menu_height / 10;
	static float grid_height = 9 * lowarea_height / 10;
	static float grid_width = grid_height;
	static float slot_width = grid_width / 4;
	static float slot_height = grid_height / 4;
		//variaveis da caixa de dialogo
		// - Area da caixa de dialogo cobre 1/5 da tela, alinhado para baixo
		// - Area da caixa de texto cobre 80% da altura e 85% da largura da caixa de dialogo, centralizada
	static float dialogbox_width = Screen.width;
	static float dialogbox_height = Screen.height / 5;
	static float textarea_width = 8.5f * dialogbox_width / 10;
	static float textarea_height = 7f * dialogbox_height / 10;
	static float dialog_fontsize = textarea_height/2.5f;
		//variaveis do botao de interacao
	static float intbutton_width = Screen.width / 4;
	static float intbutton_height = intbutton_width / 3;
		//variaveis da caixa de escolhas
	static float choicebox_width = 3*Screen.width / 5;
	static float choicebox_height = choicebox_width / 5;
	static float choicetext_width = 9 * choicebox_width / 10;
	static float choicetext_height = 9 * choicebox_height/10;
		//variaveis da caixa da face dos personagens
	static float facearea_width = dialogbox_width / 5;
	static float facearea_height = facearea_width;

	static float startbtn_width = Screen.width/3;
	static float startbtn_height = startbtn_width / 6;

	// Use this for initialization
	void Start () {
		selectedItem = null;
		inventorio = new Inventorio(5);
		player = null;
		persona = null;
		eventlist = new bool[2];
		for (int i=0; i < eventlist.Length; i++) 
		{
			eventlist[i] = false;
		}
		gerEstados = GerenciadorEstados.getInstance();
                
        //testes do victor
		on_mainmenu = true;
		menu_button_press = false;
		show_menu_GUI = false;
		item_grid = new Item[4,4,3];
		page = 0;
		face_images = new Sprite[3];
		cam_move = false;
	}

	// Update is called once per frame
	void Update () {
      	//testes do victor
			//Camera
		if (cam_move == true) 
		{
			cam.transform.position = new Vector3(player.transform.position.x,player.transform.position.y,cam.transform.position.z);
		}
			//Inputs
        if (Input.GetKeyDown (KeyCode.C)) 
		{
			menu_button_press = true;
		}
		if (Input.GetKeyUp (KeyCode.C)) 
		{
			menu_button_press = false;
		}
			//Variaveis de controle
		if (menu_button_press == true) 
		{
			if (on_mainmenu == false)
			{
				if (show_menu_GUI == false)
				{
					show_menu_GUI = true;
					persona.lockplayer();
				}else
				{
					show_menu_GUI = false;
					persona.unlockplayer();
				}
				menu_button_press = false;
			}
		} 
	}

	public void TransiteScene(string NextScene, string SpawnPoint) {

		if (player != null) {
			//persona = (PlayerController) player.GetComponent(typeof(PlayerController));
			persona.set_spot(SpawnPoint);
			DontDestroyOnLoad(player);
		}
        on_mainmenu = false;
		DontDestroyOnLoad(this.gameObject);
		DontDestroyOnLoad (this.cam);
		Application.LoadLevel(NextScene);
	}

	void OnGUI(){      
                
        //testes do victor
        GUI.skin = game_skin;
		if (on_mainmenu == false) 
		{//Mostrando os componentes de GUI
			
			//Botao de inicio de jogo
			if (show_intbutton_GUI == true) 
			{
				//Definir area do botao de interacao
				GUI.BeginGroup(new Rect(Screen.width-intbutton_width,Screen.height-intbutton_height,intbutton_width,intbutton_height));
				
				//Desenhar botao de interacao
				GUIStyle intbtnstyle = GUI.skin.GetStyle("ButtonBackground");
				intbtnstyle.fontSize = Mathf.RoundToInt(dialog_fontsize);
				bool intbtn = GUI.Button(new Rect(0,0,intbutton_width,intbutton_height),"Examine",intbtnstyle);
				if (intbtn)
				{
					//colocar acao do botao - iniciar dialogo
				}
				
				GUI.EndGroup();
			}

			//Botao de acesso ao menu (inventario)
			if (show_menu_GUI == false)
			{
				//Definir area do botao de acesso
				GUI.BeginGroup(new Rect(0,0,intbutton_width,intbutton_height));
				
				//Desenhar botao de acesso
				GUIStyle intbtnstyle = GUI.skin.GetStyle("ButtonBackground");
				intbtnstyle.fontSize = Mathf.RoundToInt(dialog_fontsize);
				bool intbtn = GUI.Button(new Rect(0,0,intbutton_width,intbutton_height),"Inventory",intbtnstyle);
				if (intbtn)
				{
					show_menu_GUI = true;
					persona.lockplayer();
				}
				
				GUI.EndGroup();
			}
			
			//Faces dos personagens e mostrar itens
			if (show_face_GUI == true) 
			{
				//Definir a area das faces
				GUI.BeginGroup(new Rect(Screen.width-dialogbox_width,Screen.height-dialogbox_height-facearea_height,dialogbox_width,facearea_height));
				
				//Desenhar cada imagem de face
				if (face_images[0] != null)//esquerda
				{
					GUI.Box(new Rect(0,0,facearea_width,facearea_height),face_images[0].texture,"FaceimgBackground");
				}
				if (face_images[1] != null)//direita
				{
					GUI.Box(new Rect(dialogbox_width-facearea_width,0,facearea_width,facearea_height),face_images[1].texture,"FaceimgBackground");
				}
				if (face_images[2] != null)//centro
				{
					GUI.Box(new Rect((dialogbox_width/2)-(upimg_width/2),0,upimg_width,upimg_height),face_images[2].texture,"MenuBackground");
				}
				
				GUI.EndGroup();
			}
			
			//Caixa de dialogo
			if (show_dialogbox_GUI == true) 
			{
				//Fazer a area delimitante da caixa de dialogo
				GUI.BeginGroup(new Rect(Screen.width-dialogbox_width,Screen.height-dialogbox_height,dialogbox_width,dialogbox_height));
				
				//Desenhar a caixa de dialogo
				bool diaboxclick = GUI.Button(new Rect(0,0,dialogbox_width,dialogbox_height),"","DialogboxBackground");
				if (diaboxclick)
				{
					//Ao clicar na caixa de texto com mouse - passar texto
				}
				
				//Fazer a area delimitante da caixa de texto
				GUI.BeginGroup(new Rect((dialogbox_width - textarea_width)/2,(dialogbox_height-textarea_height)/2,textarea_width,textarea_height));
				
				//Desenhar o texto da caixa de texto
				GUIStyle text_gui = GUI.skin.GetStyle("DialogtextBackground");
				text_gui.fontSize = Mathf.RoundToInt(dialog_fontsize);
				GUI.Box(new Rect(0,0,textarea_width,textarea_height),dialog_text,text_gui);
				
				GUI.EndGroup();
				
				GUI.EndGroup();
			}
			
			//Caixa de escolha
			if (show_choicebox_GUI == true) 
			{
				//Definir area da caixa de escolha
				int nchoices = choices_text.Length;
				GUI.BeginGroup(new Rect((Screen.width-choicebox_width)/2,(Screen.height-(nchoices*choicebox_height))/2,choicebox_width,nchoices*choicebox_height));
				
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
			
			//Menu inventorio
			if (show_menu_GUI == true) 
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
				
				//Fazer a area delimitante do menu
				GUI.BeginGroup(new Rect(Screen.width-menu_width,Screen.height-menu_height,menu_width,menu_height));
				
				//Desenhar o background do menu
				GUI.Box(new Rect(0,0,menu_width,menu_height),"","MenuBackground");
				
				//Definir area superior
				GUI.BeginGroup(new Rect(0,0,uparea_width,uparea_height));
				
				//Desenhar area superior (imagem do item e titulo do mesmo)
				if (selectedItem != null)
				{
					GUI.Box(new Rect(0,0,uparea_width,uparea_height-upimg_height),selectedItem.getNome(),"TextBackground");
					GUIStyle bigimg = new GUIStyle();
					bigimg.normal.background = selectedItem.getSprite().texture;
					GUI.Box(new Rect((uparea_width-upimg_width)/2,uparea_height-upimg_height,upimg_width,upimg_height),"",bigimg);
				} else
				{
					GUI.Box(new Rect(0,0,uparea_width,uparea_height-upimg_height),"","TextBackground");
					GUI.Box(new Rect((uparea_width-upimg_width)/2,uparea_height-upimg_height,upimg_width,upimg_height),"","Menubackground");
				}
				GUI.EndGroup();
				
				//Definir area central
				GUI.BeginGroup(new Rect(0,menu_height-lowarea_height-btnarea_height-midarea_height,midarea_width,midarea_height));
				
				//Desenhar a area central (Descricao de item)
				if (selectedItem != null)
				{
					GUI.Box(new Rect(0,0,midarea_width,midarea_height),selectedItem.getDescricao(),"TextBackground");
				} else
				{
					GUI.Box(new Rect(0,0,midarea_width,midarea_height),"","TextBackground");
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
				GUI.Button(new Rect(0,0,lbutton_width,lbutton_height),"Profiles",lbutton);
				GUI.Button(new Rect(lbutton_width,0,lbutton_width,lbutton_height),"Backlog",lbutton);
				GUI.Button(new Rect(0,btnarea_height-lbutton_height,lbutton_width,lbutton_height),"Annotations",lbutton);

				//Botao de fechar menu
				bool closebutton = GUI.Button(new Rect(lbutton_width,btnarea_height-lbutton_height,lbutton_width,lbutton_height),"Close",lbutton);
				if (closebutton)
				{
					show_menu_GUI = false;
					persona.unlockplayer();
				}

				GUI.EndGroup();
				
				
				GUI.EndGroup();
			}
		}else
		{
			//Menu principal
			//Definir area dos botoes
			GUI.BeginGroup(new Rect((Screen.width-startbtn_width)/2,3*Screen.height/5,startbtn_width,startbtn_height));
			
			//Desenhar botao de iniciar jogo
			bool intbtn = GUI.Button(new Rect(0,0,startbtn_width,startbtn_height),"","StartBtnBackground");
			if (intbtn)
			{
				on_mainmenu = false;
				TransiteScene("Cena1", "initial_spot");
			}
			
			GUI.EndGroup();

		}
		
	}


	public int getState(string personagem) {
		return gerEstados.getEstado(personagem);
	}

	public void changeState(string personagem, int state) {
		gerEstados.alterarEstado(personagem, state);
	}

	public bool TemItem(string item){
		return inventorio.TemItem (item);
		
		/*Debug.Log ("Pegou " + item);
		itemsPegos [itemIndex] = (Item)items [item];
		itemIndex++;*/
	}	

	public void PegarItem(string item, Sprite sprite){
		inventorio.addItem (item, sprite);
	}	

	public void InstancePlayer() {
		player = Instantiate(Resources.Load("prefab/Jane", typeof(GameObject))) as GameObject;
		cam.orthographicSize = 4;
		cam_move = true;
	}


	void OnLevelWasLoaded(int thisLevel) {
		if (player == null) {
			InstancePlayer();
			persona = (PlayerController) player.GetComponent(typeof(PlayerController));
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

	public void hideitem()
	{
		face_images [2] = null;
	}

	public void showface(int pos, int personagem, int faceindex)
	{
		Sprite face_sprite = face_sets [face_divider [personagem]+faceindex];
		face_images [pos] = face_sprite;
		show_face_GUI = true;
	}

	public void hideface(int pos)
	{
		face_images [pos] = null;
		show_face_GUI = false;
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
		dialog_text = s;
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
