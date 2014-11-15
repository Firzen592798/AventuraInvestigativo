using UnityEngine;
using System.Collections;

public class MudarLocalPersonagem : Acao{

	string new_scene;
	Vector3 spawn;
	
	public MudarLocalPersonagem(GameController gm, string goto_scene, Vector3 position){
		this.gm = gm;
		new_scene = goto_scene;
		spawn = position;
	}
	
	public override bool Update(){
		//TODO
		return true;
	}
}