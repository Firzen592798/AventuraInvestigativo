using UnityEngine;
using System.Collections;
public class MoverPersonagem : Acao{
	ArrayList dialogos;
	DialogLine dialogo;
	int falaAtual;
	public MoverPersonagem(){
		g = GameObject.FindGameObjectWithTag("GameManager");
		gm = (GameController) g.GetComponent(typeof(GameController));
	}

	public override bool Update(){
		/*
		if (Input.GetKeyDown (KeyCode.Z)) {
			gm.lockplayer();
			if(falaAtual == dialogos.Count){
				Debug.Log("Terminou");
				falaAtual = 0;
				gm.hidedialogbox();
				gm.unlockplayer();
				return true;
			}
			string texto = ((DialogLine)dialogos[falaAtual]).getTexto();
			gm.showdialogbox();
			gm.LoadShowTxt(texto);
			Debug.Log (texto);
			
			falaAtual++;
		}
		return false;
		*/
		return false;
	}
	
	
}