using UnityEngine;
using System.Collections;

public class MudarLocalPersonagem : Acao{
	
	GameController gm;

	string new_scene;
	Vector3 spawn;
	
	public MudarLocalPersonagem(string goto_scene, Vector3 position){
		g = GameObject.FindGameObjectWithTag("GameManager");
		gm = (GameController) g.GetComponent(typeof(GameController));
		new_scene = goto_scene;
		spawn = position;
	}
	
	public override bool Update(){
		//TODO
		return true;
	}
}