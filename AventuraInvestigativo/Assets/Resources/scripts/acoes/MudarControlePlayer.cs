using UnityEngine;
using System.Collections;

public class MudarControlePlayer : Acao{

	PlayerController p;
	bool behaviour;
	public MudarControlePlayer(GameController gm, bool npc_behaviour) {
		this.gm = gm;

		behaviour = npc_behaviour;
		//p = gm.getPlayer();
	}

	public override bool Update() {
		p = gm.getPlayer();
		if (behaviour) {
			p.NPC_Behaviour();
		}
		else {
			p.Player_Behaviour();
		}
		return true;
	}
}