using UnityEngine;
using System.Collections;
public class MoverPersonagem : Acao{
	private NPCController2 npcController;
	private GameObject go;
	public MoverPersonagem(){
		g = GameObject.FindGameObjectWithTag("GameManager");
		gm = (GameController) g.GetComponent(typeof(GameController));
	}

	public override bool Update(){
		go = GameObject.FindGameObjectWithTag("DarkMegaman");
		Debug.Log ("Gameobject " + go);
		npcController = (NPCController2) go.GetComponent(typeof(NPCController2));
		Debug.Log ("NPCController: " + npcController);
		Vector3 pos = npcController.transform.position;
		pos.x = pos.x + 1;
		npcController.transform.position = pos;
		GerenciadorEstados.getInstance ().alterarEstado ("Dark Megaman", 0);
		return true;
	}
	
	
}