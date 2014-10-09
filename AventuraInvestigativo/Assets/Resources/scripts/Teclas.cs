using UnityEngine;
using System.Collections;

public class Teclas : MonoBehaviour {

	public static string Confirma = "z";
	public static string Menu = "x";
	GameObject g;
	GameController gm;

	int largura = 100, altura = 20, posx = 425, yinicial = 139, yinc = 30;
	// Use this for initialization
	void Start () {
		//g = GameObject.FindGameObjectWithTag("GameManager");
		//gm = (GameController) g.GetComponent(typeof(GameController));
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Escape))
		{
			Application.LoadLevel ("Intro");
		}
	}

	public void OnGUI(){

		Confirma = GUI.TextField(new Rect(posx,yinicial,largura,altura), Confirma);
		if (Confirma.Length > 1) {
			Confirma = Confirma[1].ToString().ToLower();
		}

		Menu = GUI.TextField(new Rect(posx,yinicial+yinc,largura,altura), Menu);
		if (Menu.Length > 1) {
			Menu = Menu[1].ToString().ToLower();
		}
	}


}
