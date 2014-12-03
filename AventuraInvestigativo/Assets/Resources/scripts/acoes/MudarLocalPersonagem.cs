using UnityEngine;
using System.Collections;

public class MudarLocalPersonagem : Acao{

	string npc;
	int new_scene;
	Vector3 spawn;
	string spawn_point;

	public MudarLocalPersonagem(GameController gm, string personagem, Vector3 position){
		npc = personagem;
		this.gm = gm;
		new_scene = -1;
		spawn = position;
		spawn_point = "";
	}
	
	public MudarLocalPersonagem(GameController gm, string personagem, string spawn_point) {
		npc = personagem;
		this.gm = gm;
		new_scene = -1;
		this.spawn_point = spawn_point;
	}

	public MudarLocalPersonagem(GameController gm, string personagem, Vector3 position, int goto_scene){
		npc = personagem;
		this.gm = gm;
		new_scene = goto_scene;
		spawn = position;
		spawn_point = "";
	}

	public MudarLocalPersonagem(GameController gm, string personagem, string spawn_point, int goto_scene) {
		npc = personagem;
		this.gm = gm;
		new_scene = goto_scene;
		this.spawn_point = spawn_point;
	}

	public override bool Update(){
		if (new_scene != -1) {
			ObjectController o = gm.getNPC(npc);
			if (spawn_point != "") {
				GameObject sp = gm.getSpawnPoint(spawn_point);
				spawn = sp.transform.position;
			}
			spawn.z = spawn.y;
			o.gameObject.transform.position = spawn;
		}
		else {
			//TODO
		}
		return true;
	}
}