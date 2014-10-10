using UnityEngine;
using System.Collections;
public class MostrarEscolhas : Acao{
	DialogLine dialogLine;
	ArrayList escolhas;
	bool mostrouNaTela = false;
	bool down_button_pressed;
	bool up_button_pressed;
	bool dialog_button_pressed;
	int choiceindex;

	public MostrarEscolhas(DialogLine dialogLine, ArrayList escolhas){
		this.dialogLine = dialogLine;
		this.escolhas = escolhas;
		g = GameObject.FindGameObjectWithTag("GameManager");
		gm = (GameController) g.GetComponent(typeof(GameController));
	}
	
	public MostrarEscolhas(DialogLine dialogLine){
		this.dialogLine = dialogLine;
		g = GameObject.FindGameObjectWithTag("GameManager");
		gm = (GameController) g.GetComponent(typeof(GameController));
	}
	
	public override bool Update(){
		if (Input.GetKeyDown (Teclas.Confirma)) {
			dialog_button_pressed = true;
		}
		if (Input.GetKeyUp (Teclas.Confirma)) {
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
		if(!mostrouNaTela) {
			mostrouNaTela = true;
			gm.showdialogbox();
			gm.lockplayer();
			string[] escolhasArray = new string[escolhas.Count];
			for(int i = 0; i < escolhasArray.Length; i++) {
				escolhasArray[i] = ((Escolha)escolhas[i]).getEscolha();
			}
			gm.showchoicebox(escolhasArray);
			gm.LoadShowTxt(dialogLine.getTexto());
		}
		if (mostrouNaTela) {
			if (up_button_pressed) {
				if ( choiceindex > 0) {
					choiceindex = choiceindex - 1;
//					gm.highlightchoice(choiceindex);
					up_button_pressed = false;
				}
			}
			if (down_button_pressed) {
				if (choiceindex < escolhas.Count-1) {
					choiceindex = choiceindex + 1;
//					gm.highlightchoice(choiceindex);
					down_button_pressed = false;
				}
			}
			if (dialog_button_pressed) {
				gm.hidechoicebox();
				gm.hidedialogbox();
				gm.unlockplayer();

				int novoEstado =((Escolha)escolhas[choiceindex]).getNovoEstado();

				gm.changeState(dialogLine.getPersonagem(), novoEstado);
				choiceindex = 0;
				dialog_button_pressed = false;
				mostrouNaTela = false;
				return true;
			}
		}
		return false;

	}
}