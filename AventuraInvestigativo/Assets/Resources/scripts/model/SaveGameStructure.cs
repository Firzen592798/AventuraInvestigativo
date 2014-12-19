using UnityEngine;
using System.Collections;
using System;
using System.Text;

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

	public string[,] profiles;

	public string backlog;

	public string notes;
	//public byte[] bnotes;

	public int music;
	public int anbient;

	public SaveGameStructure () {

		GameObject g = GameObject.FindGameObjectWithTag("GameManager");
		GameController gm = (GameController) g.GetComponent(typeof(GameController));

		show_menu = gm.GameInterface.ShowingQuickMenuGUI;//.show_menu_GUI;

		events = gm.getEvents();

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

		Item[] IL = gm.getItems();

		itempegos = new string[IL.Length,2];
		for(int i = 0; i < IL.Length; i++) {
			itempegos[i,0] = IL[i].getNome();
			itempegos[i,1] = IL[i].getSpritePath();
		}

		Profile[] perfis = gm.Profiles;
		profiles = new string[perfis.Length, 4];
		for(int i = 0; i < perfis.Length; i++) {
			profiles[i,0] = perfis[i].Nome;
			profiles[i,1] = perfis[i].Idade;
			profiles[i,2] = perfis[i].Sexo;
			profiles[i,3] = perfis[i].Descricao;
		}

		BacklogManager bm = BacklogManager.getInstance();
		Conversa[] historic = bm.getHistoric();
		backlog = "";
		for (int i = 0; i < historic.Length; i++) {
			Conversa c = historic[i];
			backlog = backlog+c.getRotulo()+"\n";
		}

		string[] playernotes = gm.GameInterface.PlayerNotes;
		notes = "";
		for(int i = 0; i < playernotes.Length; i++) {
			if (playernotes[i].Length > 0) {
				notes = notes + i.ToString("00") + playernotes[i] + '\0';
			}
		}
		//bnotes = Encoding.UTF8.GetBytes(notes);

		music = gm.getMusic();
		anbient = gm.getAnbient();
	}

	public PositionGlobal getPositionGlobal(int index) {
		PositionGlobal pg;
		PositionGlobalSerializable pgs = positions[index];
		pg.initialized = pgs.is_initialized;
		pg.position = new Vector3(pgs.x, pgs.y, pgs.z);
		pg.scene_index = pgs.scene_index;
		return pg;
	}

	public string[] getRotulosBacklog() {
		ArrayList bk = new ArrayList();
		if (backlog.Length > 0) {
			int init = 0;
			int index = backlog.IndexOf('\n', 0);
			while (index >= init) {
				string rotulo = backlog.Substring(init, index-init);
				bk.Add(rotulo);
				init = index+1;
				if (init < backlog.Length) {
					index = backlog.IndexOf('\n', init);
				}
			}
		}
		string[] rotulos = new string[bk.Count];
		for(int i = 0; i < bk.Count; i++) {
			rotulos[i] = (string)bk[i];
		}
		return rotulos;
	}

	public string[] getPlayerNotes() {
		string[] playernotes = new string[50];
		for (int n = 0; n < 50 ;n++) {
			playernotes[n] = "";
		}
		//string notes = Encoding.UTF8.GetString(bnotes);
		if (notes.Length > 0) {
			int init = 0;
			int index = notes.IndexOf('\0', 0);
			while (index >= init) {
				int page = Convert.ToInt32(notes.Substring(init, 2));
				string note = notes.Substring(init+2, index-init-2);
				playernotes[page] = note;
				init = index+1;
				if (init < notes.Length) {
					index = notes.IndexOf('\0', init);
				}
			}
		}
		return playernotes;
	}
}

