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
			DialogLine dl = ((DialogLine)dialogos[falaAtual]);
			string texto = dl.getTexto();
			gm.showdialogbox();
			gm.LoadShowTxt(texto);
			if(dl.getSprite() != -1)
				gm.showface(dl.getPos(), dl.getSprite(), 0);
			falaAtual++;
		}
		else if ((Input.GetMouseButtonDown(0))||(Input.GetKeyDown (Teclas.Confirma))) {
			//gm.lockplayer();
			if(falaAtual == dialogos.Count){
				//Debug.Log("Terminou");
				falaAtual = 0;
				gm.hideface(0);
				gm.hidedialogbox();
				gm.unlockplayer();
				return true;
			}
			DialogLine dl = ((DialogLine)dialogos[falaAtual]);
			string texto = dl.getTexto();

			if(dl.getSprite() != -1)
			{	gm.hideface(1 - dl.getSprite ());
				gm.showface(dl.getPos(), dl.getSprite(), 0);
			}
			gm.showdialogbox();
			gm.LoadShowTxt(texto);
			//Debug.Log (texto);

			falaAtual++;
		}
		return false;
	}


}