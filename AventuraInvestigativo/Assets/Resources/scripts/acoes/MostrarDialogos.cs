using UnityEngine;
using System.Collections;
public class MostrarDialogos : Acao{
	ArrayList dialogos;
	DialogLine dialogo;
	int falaAtual;
	public MostrarDialogos(ArrayList dialogLines){
		this.dialogos = dialogLines;
		falaAtual = 0;
		g = GameObject.FindGameObjectWithTag("GameManager");
		gm = (GameController) g.GetComponent(typeof(GameController));
	}

	public MostrarDialogos(DialogLine dialogo){
		this.dialogo = dialogo;
		g = GameObject.FindGameObjectWithTag("GameManager");
		gm = (GameController) g.GetComponent(typeof(GameController));
	}

	public override bool Update(){
		gm.lockplayer();
		if (falaAtual == 0) {
			string texto = ((DialogLine)dialogos[falaAtual]).getTexto();
			gm.showdialogbox();
			gm.LoadShowTxt(texto);
			falaAtual++;
		}
		else if (Input.GetKeyDown (KeyCode.Z)) {
			//gm.lockplayer();
			if(falaAtual == dialogos.Count){
				//Debug.Log("Terminou");
				falaAtual = 0;
				gm.hidedialogbox();
				gm.unlockplayer();
				return true;
			}
			string texto = ((DialogLine)dialogos[falaAtual]).getTexto();
			gm.showdialogbox();
			gm.LoadShowTxt(texto);
			//Debug.Log (texto);

			falaAtual++;
		}
		return false;
	}


}