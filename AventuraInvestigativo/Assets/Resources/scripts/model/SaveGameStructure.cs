using UnityEngine;
using System.Collections;
using System;

[Serializable]
public struct PositionGlobalSerializable {
	public bool is_initialized;
	public float x;
	public float y;
	public float z;
	public int scene_index;
}

[Serializable]
public class SaveGameStructure {

	public bool show_menu;

	public bool[] events;
	public string[] nomes;
	public int[] states;
	public PositionGlobalSerializable[] positions;

	public string[,] itempegos;

	public int music;
	public int anbient;

	public SaveGameStructure () {

		GameObject g = GameObject.FindGameObjectWithTag("GameManager");
		GameController gm = (GameController) g.GetComponent(typeof(GameController));

		//this.current_scene = Application.loadedLevel;

		show_menu = gm.show_menu_GUI;

		this.events = gm.getEvents();

		ArrayList l = gm.getNomePersonagens();
		nomes = new string[l.Count];
		states = new int[l.Count];
		positions = new PositionGlobalSerializable[l.Count];

		for(int i = 0; i < l.Count; i++) {
			nomes[i] = (string)l[i];
			states[i] = gm.getStateIndex(nomes[i]);
			PositionGlobal pg = gm.getGlobalPosition(nomes[i]);
			PositionGlobalSerializable pgs;
			pgs.is_initialized = pg.initialized;
			pgs.x = pg.position.x;
			pgs.y = pg.position.y;
			pgs.z = pg.position.z;
			pgs.scene_index = pg.scene_index;
			positions[i] = pgs;
		}

		/*
		foreach(string nome in gm.getNomePersonagens()) {
			states.Add(nome, gm.getStateIndex(nome));
			PositionGlobal pg = gm.getGlobalPosition(nome);
			PositionGlobalSerializable pgs;
			pgs.is_initialized = pg.initialized;
			pgs.x = pg.position.x;
			pgs.y = pg.position.y;
			pgs.z = pg.position.z;
			pgs.scene_index = pg.scene_index;
			positions.Add(nome, pgs);
		}*/

		Item[] IL = gm.getItems();

		itempegos = new string[IL.Length,2];
		for(int i = 0; i < IL.Length; i++) {
			itempegos[i,0] = IL[i].getNome();
			itempegos[i,1] = IL[i].getSpritePath();
		}
		//itempegos = gm.getItems();

		music = gm.getMusic();
		anbient = gm.getAnbient();

	}

	public PositionGlobal getPositionGlobal(int index) {
		string nome = nomes[index];
		PositionGlobal pg;
		PositionGlobalSerializable pgs = positions[index];
		pg.initialized = pgs.is_initialized;
		pg.position = new Vector3(pgs.x, pgs.y, pgs.z);
		pg.scene_index = pgs.scene_index;
		return pg;
	}
}

