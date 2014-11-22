using UnityEngine;
using System.Collections;

public class MudarLocalPersonagem : Acao{

	string new_scene;
	Vector3 spawn;
	string spawn_point;
	
	public MudarLocalPersonagem(GameController gm, string goto_scene, Vector3 position){
		this.gm = gm;
		new_scene = goto_scene;
		spawn = position;
	}

	public MudarLocalPersonagem(GameController gm, string goto_scene, string spawn_point) {
		this.gm = gm;
		new_scene = goto_scene;
		this.spawn_point = spawn_point;
	}

	public override bool Update(){
		//TODO
		return true;
	}
}