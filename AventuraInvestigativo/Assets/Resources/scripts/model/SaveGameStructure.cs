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
	public Hashtable states;
	public Hashtable positions;

	public Item[] itempegos;

	public int music;
	public int anbient;

	public SaveGameStructure () {

		GameObject g = GameObject.FindGameObjectWithTag("GameManager");
		GameController gm = (GameController) g.GetComponent(typeof(GameController));

		//this.current_scene = Application.loadedLevel;

		show_menu = gm.show_menu_GUI;

		this.events = gm.getEvents();

		states = new Hashtable();
		positions = new Hashtable();

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
		}

		itempegos = gm.getItems();

		music = gm.getMusic();
		anbient = gm.getAnbient();

	}

	public PositionGlobal getPositionGlobal(string nome) {
		PositionGlobal pg;
		PositionGlobalSerializable pgs = (PositionGlobalSerializable)positions[nome];
		pg.initialized = pgs.is_initialized;
		pg.position = new Vector3(pgs.x, pgs.y, pgs.z);
		pg.scene_index = pgs.scene_index;
		return pg;
	}
}

