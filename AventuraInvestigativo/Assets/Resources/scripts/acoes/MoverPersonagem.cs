using UnityEngine;
using System.Collections;
public class MoverPersonagem : Acao{
	private ObjectController NPC_Controller;
	private string npcNome;
	private GameObject npc;
	private Vector3 destiny_position;
	private bool wait;
	private bool inPlace;
	private bool isWalking;
	
	public MoverPersonagem(string personagem, Vector3 point, bool waitToArrive){
		g = GameObject.FindGameObjectWithTag("GameManager");
		gm = (GameController) g.GetComponent(typeof(GameController));
		npcNome = personagem;
		point = destiny_position;
		wait = waitToArrive;
		isWalking = false;
	}
	
	public override bool Update(){
		if (!isWalking) {
			npc = gm.getNPC(npcNome);
			NPC_Controller = (ObjectController) npc.GetComponent(typeof(ObjectController));
			NPC_Controller.addWayPoint(destiny_position);
		}
		if (wait) {
			isWalking = true;
			gm.lockplayer();
			if (NPC_Controller.hasStoredWayPoint(destiny_position)) {
				return false;
			}
			else {
				gm.unlockplayer();
				isWalking = false;
				return true;
			}
		}
		else {
			return true;
		}
	}
	
	
}