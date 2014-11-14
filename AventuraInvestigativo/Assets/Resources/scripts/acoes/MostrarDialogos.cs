using UnityEngine;
using System.Collections;
public class MostrarDialogos : Acao{
	ArrayList dialogos;
	int falaAtual;
	public MostrarDialogos(GameController gm, ArrayList dialogLines){
		this.dialogos = dialogLines;
		falaAtual = 0;
		this.gm = gm;
	}

	public MostrarDialogos(GameController gm, DialogLine dialogo){
		this.dialogos = new ArrayList();
		this.dialogos.Add(dialogo);
		falaAtual = 0;
		this.gm = gm;
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
		else if (Input.GetKeyDown (Teclas.Confirma)&&(!gm.show_menu_GUI&&!gm.show_inventory_GUI)) {
			//gm.lockplayer();
			if (!gm.isShowingDialog())
			{
				if(falaAtual == dialogos.Count){
					//Debug.Log("Terminou");
					falaAtual = 0;
					gm.hideface(0);
					gm.hideface(1);
					gm.hidedialogbox();
					gm.unlockplayer();
					return true;
				}
				DialogLine dl = ((DialogLine)dialogos[falaAtual]);
				string texto = dl.getTexto();

				if(dl.getSprite() != -1)
				{	
					//gm.hideface(1 - dl.getSprite ());
					gm.showface(dl.getPos(), dl.getSprite(), 0);
				}
				gm.showdialogbox();
				gm.LoadShowTxt(texto);
				//Debug.Log (texto);

				falaAtual++;
			}else
			{
				gm.quickPassTxt();
			}
		}
		return false;
	}


}