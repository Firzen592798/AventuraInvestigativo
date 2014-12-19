using UnityEngine;
using System.Collections;
public class MostrarDialogos : Acao{
	ArrayList dialogos;
	Conversa conversa;
	int falaAtual;
	BacklogManager backlogManager;
	public MostrarDialogos(GameController gm, ArrayList dialogLines){
		this.dialogos = dialogLines;
		falaAtual = 0;
		backlogManager = BacklogManager.getInstance ();
		this.gm = gm;
	}

	public MostrarDialogos(GameController gm, Conversa conversa){
		this.dialogos = conversa.getDialogos();
		Debug.Log ("Conversa - "+  conversa.getRotulo ());
		this.conversa = conversa;
		falaAtual = 0;
		backlogManager = BacklogManager.getInstance ();
		this.gm = gm;
		backlogManager.addConversa(conversa);
	}

	public MostrarDialogos(GameController gm, DialogLine dialogo){
		this.dialogos = new ArrayList();
		this.dialogos.Add(dialogo);
		falaAtual = 0;
		backlogManager = BacklogManager.getInstance ();
		this.gm = gm;
	}

	public override bool Update(){
		gm.lockplayer();
		if (falaAtual == 0) {
			//backlogManager.addToBacklog (conversa);
			DialogLine dl = ((DialogLine)dialogos[falaAtual]);
			//backlogManager.addToBacklog(dl);
			string texto = dl.getTexto();
			gm.GameInterface.showdialogbox();
			gm.GameInterface.LoadShowTxt(texto);
			if(dl.getSprite() != -1)
			gm.GameInterface.showface(dl.getPos(), dl.getSprite(), 0);
			falaAtual++;
		}
		else if (Input.GetKeyDown (Teclas.Confirma)) {
			//gm.lockplayer();
			if (!gm.GameInterface.ShowingDialog)//.isShowingDialog())
			{
				if(falaAtual == dialogos.Count){
					//Debug.Log("Terminou");
					if (conversa != null) {
						backlogManager.addToBacklog (conversa.getRotulo());
					}
					falaAtual = 0;
					gm.GameInterface.hideface(0);
					gm.GameInterface.hideface(1);
					gm.GameInterface.hidedialogbox();
					gm.unlockplayer();

					return true;
				}
				DialogLine dl = ((DialogLine)dialogos[falaAtual]);
				//backlogManager.addToBacklog(dl);
				string texto = dl.getTexto();

				if(dl.getSprite() != -1)
				{	
					//gm.hideface(1 - dl.getSprite ());
					gm.GameInterface.showface(dl.getPos(), dl.getSprite(), 0);
				}
				gm.GameInterface.showdialogbox();
				gm.GameInterface.LoadShowTxt(texto);
				//Debug.Log (texto);

				falaAtual++;
			}else
			{
				gm.GameInterface.quickPassTxt();
			}
		}
		return false;
	}


}