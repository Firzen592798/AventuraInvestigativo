using UnityEngine;
using System.Collections;
public class MostrarDialogos : Acao{
	ArrayList dialogos;
	DialogLine dialogo;
	public MostrarDialogos(ArrayList dialogLines){
		this.dialogos = dialogLines;
		g = GameObject.FindGameObjectWithTag("GameManager");
		gm = (GameController) g.GetComponent(typeof(GameController));
	}

	public MostrarDialogos(DialogLine dialogo){
		this.dialogo = dialogo;
		g = GameObject.FindGameObjectWithTag("GameManager");
		gm = (GameController) g.GetComponent(typeof(GameController));
	}
	
	public override void executar(){
		gm.LoadShowTxt((dialogo).getTexto());
		Debug.Log (dialogo.getTexto());
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