using UnityEngine;
using System.Collections;
public class MostrarEscolhas : Acao{
	DialogLine dialogLine;
	ArrayList escolhas;
	bool mostrouNaTela = false;
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
		//if (Input.GetKeyDown (KeyCode.Z)) {
		if(mostrouNaTela == false){
			mostrouNaTela = true;
			gm.showdialogbox();
			gm.lockplayer();

			gm.showchoicebox((string[])escolhas.ToArray(typeof(string)));
			gm.LoadShowTxt(dialogLine.getTexto());
			Debug.Log (escolhas[0]);
		}
		return false;

	}
	
	public override void executar(){
		//Debug.Log(dialogos.Count);
	}
	
	/*
	public override void executar(){
		Debug.Log(dialogos.Count);
		for (int i = 0; i < dialogos.Count; i++) {
			Debug.Log(((DialogLine)dialogos[i]).getTexto());
			gm.LoadShowTxt(((DialogLine)dialogos[i]).getTexto());
			while (!Input.GetKeyDown (KeyCode.X)) {
				System.Threading.Thread.Sleep(50);
			}
		
		}
	}*/
	
}