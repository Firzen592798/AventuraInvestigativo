using UnityEngine;
using System.Collections;



public class Teclas : MonoBehaviour {
	enum Selec {
		Confirma, Menu, Esquerda, Direita, Cima, Baixo, Victor
	}

	public static KeyCode Confirma = KeyCode.Z;
	public static KeyCode Menu = KeyCode.X;
	public static KeyCode Direita = KeyCode.RightArrow;
	public static KeyCode Esquerda = KeyCode.LeftArrow;
	public static KeyCode Cima = KeyCode.UpArrow;
	public static KeyCode Baixo = KeyCode.DownArrow;
	private static Selec bot = Selec.Victor;
	GameObject g;
	GameController gm;

	int largura = 100, altura = 20, posx = 425, yinicial = 100, yinc = 30;
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
		Event e = Event.current;
		if (e.isKey) {
			switch(bot){
			case Selec.Confirma:
				Confirma = e.keyCode;
				bot = Selec.Victor;
				break;
			case Selec.Menu:
				Menu = e.keyCode;
				bot = Selec.Victor;
				break;
			case Selec.Esquerda:
				Esquerda = e.keyCode;
				bot = Selec.Victor;
				break;
			case Selec.Direita:
				Direita = e.keyCode;
				bot = Selec.Victor;
				break;
			case Selec.Cima:
				Cima = e.keyCode;
				bot = Selec.Victor;
				break;
			case Selec.Baixo:
				 Baixo = e.keyCode;
				bot = Selec.Victor;
				break;
			}
		}
		bool press;

		press = GUI.Toggle(new Rect(posx,yinicial,largura,altura), bot == Selec.Confirma, "" + (KeyCode) Confirma);
		if (press) {
			bot = Selec.Confirma;
		}

		press = GUI.Toggle(new Rect(posx,yinicial+yinc,largura,altura), bot == Selec.Menu, "" + (KeyCode) Menu);
		if (press) {
			bot = Selec.Menu;
		}

		press = GUI.Toggle(new Rect(posx,yinicial+2*yinc,largura,altura), bot == Selec.Esquerda, "" + (KeyCode) Esquerda);
		if (press) {
			bot = Selec.Esquerda;
		}

		press = GUI.Toggle(new Rect(posx,yinicial+3*yinc,largura,altura), bot == Selec.Direita, "" + (KeyCode) Direita);
		if (press) {
			bot = Selec.Direita;
		}

		press = GUI.Toggle(new Rect(posx,yinicial+4*yinc,largura,altura), bot == Selec.Cima, "" + (KeyCode) Cima);
		if (press) {
			bot = Selec.Cima;
		}

		press = GUI.Toggle(new Rect(posx,yinicial+5*yinc,largura,altura), bot == Selec.Baixo, "" + (KeyCode) Baixo);
		if (press) {
			bot = Selec.Baixo;
		}


	}
		
	public static KeyCode getKeyConfirma()
	{
		return Confirma;
	}

	public static KeyCode getKeyMenu()
	{
		return Menu;
	}

	public static KeyCode getKeyDireita()
	{
		return Direita;
	}

	public static KeyCode getKeyEsquerda()
	{
		return Esquerda;
	}

	public static KeyCode getKeyCima()
	{
		return Cima;
	}

	public static KeyCode getKeyBaixo()
	{
		return Baixo;
	}

}
