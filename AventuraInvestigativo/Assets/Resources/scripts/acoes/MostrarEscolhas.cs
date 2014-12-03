using UnityEngine;
using System.Collections;

public class MostrarEscolhas : Acao {

	DialogLine dialogLine;
	ArrayList escolhas;
	bool mostrouNaTela = false;
	//bool down_button_pressed;
	//bool up_button_pressed;
	//bool dialog_button_pressed;
	int choiceindex;
	int prox_action;
	ArrayList ListaAcoes;
	int[] repeat_on;

	public MostrarEscolhas(GameController gm, DialogLine dialogLine, ArrayList escolhas){
		this.dialogLine = dialogLine;
		this.escolhas = escolhas;
		this.gm = gm;
		this.choiceindex = -1;
		this.prox_action = 0;
		this.ListaAcoes = new ArrayList();
		this.repeat_on = null;
	}

	public MostrarEscolhas(GameController gm, DialogLine dialogLine, ArrayList escolhas, int RepitaSe){
		this.dialogLine = dialogLine;
		this.escolhas = escolhas;
		this.gm = gm;
		this.choiceindex = -1;
		this.prox_action = 0;
		this.ListaAcoes = new ArrayList();
		this.repeat_on = new int[1] {RepitaSe};
	}

	public MostrarEscolhas(GameController gm, DialogLine dialogLine, ArrayList escolhas, int[] RepitaSe){
		this.dialogLine = dialogLine;
		this.escolhas = escolhas;
		this.gm = gm;
		this.choiceindex = -1;
		this.prox_action = 0;
		this.ListaAcoes = new ArrayList();
		this.repeat_on = RepitaSe;
	}

	public override bool Update(){
		/*if (Input.GetKeyDown(Teclas.Confirma)) {
			dialog_button_pressed = true;
		}
		if (Input.GetKeyUp(Teclas.Confirma)) {
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
		}*/
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
			/*if (up_button_pressed) {
				if ( choiceindex > 0) {
					choiceindex = choiceindex - 1;
					//gm.highlightchoice(choiceindex);
					up_button_pressed = false;
				}
			}
			if (down_button_pressed) {
				if (choiceindex < escolhas.Count-1) {
					choiceindex = choiceindex + 1;
					//gm.highlightchoice(choiceindex);
					down_button_pressed = false;
				}
			}*/
			//if (dialog_button_pressed) {

			if (choiceindex == -1) {
				if (gm.selected_choice != -1) {
					choiceindex = gm.selected_choice;
					gm.hidechoicebox();
					gm.hidedialogbox();
					gm.unlockplayer();

					this.ListaAcoes =((Escolha)escolhas[choiceindex]).getListaAcoes();

					//gm.changeState(dialogLine.getPersonagem(), novoEstado);
					//choiceindex = 0;
					//dialog_button_pressed = false;
					//mostrouNaTela = false;
					//return true;
				}
			}
			else {
				if (prox_action < ListaAcoes.Count) {
					Acao a = (Acao)ListaAcoes[prox_action];
					if (a.Update()) {
						prox_action++;
					}
				}
				else {
					bool repeat = false;
					if (repeat_on != null) {
						int i = 0;
						while (!repeat && i < repeat_on.Length) {
							repeat = (repeat_on[i] == choiceindex);
							i++;
						}
					}
					//bool exit = ((exit_on == choiceindex)||(exit_on == -1));
					mostrouNaTela = false;
					choiceindex = -1;
					prox_action = 0;
					ListaAcoes = new ArrayList();
					if (!repeat) {
						return true;
					}
				}
			}
		}
		return false;

	}
}