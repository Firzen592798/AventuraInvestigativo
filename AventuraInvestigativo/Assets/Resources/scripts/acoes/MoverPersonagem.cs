using UnityEngine;
using System.Collections;
public class MoverPersonagem : Acao{
	private ObjectController NPC_Controller;
	private string npcNome;
	private Vector3 destiny_position;
	private string spawn;
	private bool wait;
	private bool inPlace;
	private bool isWalking;

	public MoverPersonagem(string personagem, Vector3 point, bool waitToArrive){
		g = GameObject.FindGameObjectWithTag("GameManager");
		gm = (GameController) g.GetComponent(typeof(GameController));
		npcNome = personagem;
		spawn = "";
		point = destiny_position;
		wait = waitToArrive;
		isWalking = false;
	}

	public MoverPersonagem(string personagem, string spawn_point, bool waitToArrive) {
		g = GameObject.FindGameObjectWithTag("GameManager");
		gm = (GameController) g.GetComponent(typeof(GameController));
		npcNome = personagem;
		spawn = spawn_point;
		wait = waitToArrive;
		isWalking = false;
	}

	public override bool Update() {
		if (!isWalking) {
			//npc = gm.getNPC(npcNome);
			//NPC_Controller = (ObjectController) npc.GetComponent(typeof(ObjectController));
			NPC_Controller = gm.getNPC(npcNome);

			if (spawn != "") {
				destiny_position = gm.getSpawnPoint(spawn).transform.position;
			}
			destiny_position.z = destiny_position.y;
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