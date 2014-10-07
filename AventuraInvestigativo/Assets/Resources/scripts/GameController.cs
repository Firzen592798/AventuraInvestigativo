using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public GameObject player;
	GameObject popupbutton;
	GameObject dialogbox;
	GameObject dialogtext;
	GameObject choicebox;
	GameObject[] choicetext;
	GameObject faceL;
	GameObject faceR;
	PlayerController persona;
	bool[]  eventlist;

	//teste
	public Sprite[] faces0;
	public Sprite[] faces1;

	float posL = -4f;
	float posR = 4f;

	public GUIStyle ItemStyle;
	public GUIStyle TextStyle;
	public GUIStyle SetaRight;
	public GUIStyle SetaLeft;
	private bool showItems;
	private bool showMenu;
	private Item selectedItem;
	private Inventorio inventorio;

	// Use this for initialization
	void Start () {
		showMenu = false;
		showItems = false;
		selectedItem = null;
		inventorio = new Inventorio(5);
		player = null;
		persona = null;
		eventlist = new bool[2];
		for (int i=0; i < eventlist.Length; i++) 
		{
			eventlist[i] = false;
		}
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("x")) {
			Debug.Log ("Apertou");
			Time.timeScale = 0.0f;
			if(showItems == false)
				showMenu = true;
		}
	}

	public void TransiteScene(string NextScene, string SpawnPoint) {

		if (player != null) {
			//persona = (PlayerController) player.GetComponent(typeof(PlayerController));
			persona.set_spot(SpawnPoint);
			DontDestroyOnLoad(player);
		}
		DontDestroyOnLoad(this.gameObject);
		Application.LoadLevel(NextScene);
	}

	void OnGUI(){
		if (showMenu == true) {
			GUI.BeginGroup (new Rect(Screen.width/2 - 50, Screen.height/2 - 50, 100, 90), "", ItemStyle);
			GUI.Box(new Rect(0, 0, 100, 90), "Menu");            
			if(GUI.Button (new Rect(10, 30, 80, 20), "Items")){
				ShowItems();
			}
			if(GUI.Button(new Rect(10, 60, 80, 20), "Resume")){
				Debug.Log ("Apertou resume");
				ResumeGame();
			}
			
			GUI.EndGroup();
		}
		
		if (showItems == true) {
			Item[] itemsPegos = inventorio.getItems(); 
			int itemCount = inventorio.count ();
			int dimensionHeight = Screen.height / 20;
			int dimensionWidth = Screen.width / 20;
			GUI.BeginGroup (new Rect(3*Screen.width/5, 0, 2 * Screen.width/5, Screen.height), "", ItemStyle);
			if(selectedItem != null){
				GUI.Box(new Rect(5, dimensionHeight, 8 * dimensionWidth, dimensionWidth), selectedItem.getNome(), TextStyle);      
				GUI.Box(new Rect(3 * dimensionWidth, 2 * dimensionHeight + 10, 3 * dimensionHeight, 3 * dimensionHeight), selectedItem.getSprite().texture, ItemStyle);
				GUI.TextArea(new Rect(5, 4 * dimensionHeight + 10, 4 * dimensionWidth, 3 * Screen.height / 20), selectedItem.getDescricao(), TextStyle);
			}
			GUI.Box(new Rect(5, 3 * Screen.height/7 + 10, 2 * Screen.width/5 - 5, Screen.width / 20), "Items");      
			int i;
			int tamButtom = 2 * dimensionHeight;
			for(i = 0; i < itemCount; i++){
				Item item = itemsPegos[i];
				int x = i % 3;
				int y = i / 3;
				
				//GUI.DrawTexture(new Rect(60, 30 * (i + 1), 20, 20), item.getSprite().texture);
				if(GUI.Button(new Rect(30 + ((tamButtom + 5) * x), 11 * dimensionHeight + 5 + ((tamButtom + 5) * y), tamButtom, tamButtom), item.getSprite().texture, ItemStyle)){
					selectedItem = item;
					ShowItemDescription();
					//item.usar();
				}
			}
			
			if(GUI.Button (new Rect(0,  13 * dimensionHeight, dimensionHeight, dimensionHeight), "", SetaLeft)){
				
			}
			if(GUI.Button (new Rect(6 * dimensionWidth + 5, 13 * dimensionHeight,  dimensionHeight, dimensionHeight), "", SetaRight)){
				
			}
			
			if(GUI.Button (new Rect(10, 18 * dimensionHeight, 100, 20), "Sair")){
				selectedItem = null;
				CloseItems();
			}
			GUI.EndGroup();
		}
		
	}

	void ShowItemDescription(){
		
	}
	
	void ShowItems(){
		showItems = true;
		showMenu = false;
	}
	
	void CloseItems(){
		showItems = false;
		showMenu = true;
	}
	
	void ResumeGame(){
		showMenu = false;
		Time.timeScale = 1.0f;
	}

	public void PegarItem(string item, Sprite sprite){
		inventorio.addItem (item, sprite);
		
		/*Debug.Log ("Pegou " + item);
		itemsPegos [itemIndex] = (Item)items [item];
		itemIndex++;*/
	}	

	public void InstancePlayer() {
		player = Instantiate(Resources.Load("prefab/player", typeof(GameObject))) as GameObject;
	}

	public void InstanceDialogBox()
	{
		dialogbox = Instantiate (Resources.Load ("prefab/DialogBox", typeof(GameObject))) as GameObject;
		dialogbox.SetActive (false);
		dialogtext = Instantiate (Resources.Load ("prefab/DialogText", typeof(GameObject))) as GameObject;
		dialogtext.SetActive (false);
		popupbutton = Instantiate (Resources.Load ("prefab/popupbutton", typeof(GameObject))) as GameObject;
		popupbutton.SetActive (false);
		choicebox = Instantiate (Resources.Load ("prefab/choicebox", typeof(GameObject))) as GameObject;
		choicebox.SetActive (false);
		//assumir que tera no maximo 5 escolhas
		choicetext = new GameObject[5];
		for (int i = 0; i<choicetext.Length; i++) 
		{
			choicetext[i] = Instantiate(Resources.Load ("prefab/ChoiceText", typeof(GameObject))) as GameObject;
			choicetext[i].SetActive(false);
		}
		faceL = Instantiate (Resources.Load ("prefab/Faceplacer", typeof(GameObject))) as GameObject;
		faceL.transform.position = new Vector3 (posL,faceL.transform.position.y, faceL.transform.position.z);
		faceL.SetActive (false);
		faceR = Instantiate (Resources.Load ("prefab/Faceplacer", typeof(GameObject))) as GameObject;
		faceR.transform.position = new Vector3 (posR,faceR.transform.position.y, faceR.transform.position.z);
		faceR.SetActive (false);
	}

	void OnLevelWasLoaded(int thisLevel) {
		if (player == null) {
			InstancePlayer();
			persona = (PlayerController) player.GetComponent(typeof(PlayerController));
		}
		InstanceDialogBox ();
	}

	public void showppbutton()
	{
		popupbutton.SetActive (true);
	}

	public void showdialogbox()
	{
		dialogbox.SetActive (true);
		dialogtext.SetActive (true);
	}

	public void showface(int pos, int personagem, int faceindex)
	{
		if (pos == 0) 
		{
			faceL.SetActive (true);
			if (personagem == 0)
			{
				faceL.GetComponent<SpriteRenderer> ().sprite = faces0 [faceindex];
			}
			else
			{
				faceL.GetComponent<SpriteRenderer> ().sprite = faces1 [faceindex];
			}
		} else 
		{
			faceR.SetActive (true);
			if (personagem == 0)
			{
				faceR.GetComponent<SpriteRenderer> ().sprite = faces0 [faceindex];
			}
			else
			{
				faceR.GetComponent<SpriteRenderer> ().sprite = faces1 [faceindex];
			}
		}
	}

	public void hideface(int pos)
	{
		if (pos == 0) 
		{
			faceL.SetActive (false);
		} else 
		{
			faceR.SetActive (false);
		}
	}

	public void showchoicebox(string[] choices)
	{
		choicebox.SetActive (true);
		float nchoices = choices.Length;
		choicebox.transform.localScale = new Vector3 (transform.localScale.x, 1+(nchoices*0.5f), transform.localScale.z);
		float boxsizeY = choicebox.renderer.bounds.max.y;

		for (int i = 0; i<nchoices; i++) 
		{
			choicetext[i].SetActive(true);
			TextMesh txt = choicetext[i].GetComponent<TextMesh>();
			txt.text = choices[i];
			float pos = boxsizeY;
			if (i == 0)
			{
				pos = pos - 0.4f;
				highlightchoice(i);
			}
			else
			{
				pos = choicetext[i-1].renderer.bounds.min.y;
				pos = pos - 0.2f;
			}
			choicetext[i].transform.position = new Vector3(choicebox.transform.position.x,pos,choicebox.transform.position.z);
		}
	}

	public void highlightchoice(int choice)
	{
		for (int i = 0; i<choicetext.Length; i++) 
		{
			if (i != choice)
			{
				choicetext [i].GetComponent<TextMesh> ().color = Color.white;
			}else
			{
				choicetext [i].GetComponent<TextMesh> ().color = Color.red;
			}
		}
	}

	public void hidechoicebox()
	{
		choicebox.SetActive (false);
		for (int i = 0; i<choicetext.Length; i++) 
		{
			choicetext[i].SetActive(false);
		}
	}

	public void hideppbutton()
	{
		popupbutton.SetActive (false);
	}

	public void hidedialogbox()
	{
		dialogbox.SetActive (false);
		dialogtext.SetActive (false);
	}

	public void LoadShowTxt(string s)
	{
		TextMesh txt = dialogtext.GetComponent<TextMesh> ();
		txt.text = s;
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
