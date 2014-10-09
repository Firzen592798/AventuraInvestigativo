using UnityEngine;
using System.Collections;
public class MoverPersonagem : Acao{
	private NPCController2 npcController;
	private GameObject go;
	private string npc;
	private Vector3 position;
	private bool wait;
	
	public MoverPersonagem(string personagem, Vector3 point, bool waitToGoPlace){
		g = GameObject.FindGameObjectWithTag("GameManager");
		gm = (GameController) g.GetComponent(typeof(GameController));
		npc = personagem;
		point = position;
		wait = waitToGoPlace;
	}

	public override bool Update(){
		go = GameObject.FindGameObjectWithTag("DarkMegaman");
		Debug.Log ("Gameobject " + go);
		npcController = (NPCController2) go.GetComponent(typeof(NPCController2));
		Debug.Log ("NPCController: " + npcController);
		Vector3 pos = npcController.transform.position;
		pos.x = pos.x + 1;
		npcController.transform.position = pos;
		GerenciadorEstados.getInstance ().alterarEstado ("Dark Megaman", 1);
		return true;
	}
	
	
}