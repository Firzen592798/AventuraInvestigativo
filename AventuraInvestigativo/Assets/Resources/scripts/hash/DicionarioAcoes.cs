using UnityEngine;
using System.Collections;

public struct PositionGlobal {
	public bool initialized;
	public Vector3 position;
	public int scene_index;
};

public class DicionarioAcoes {

	protected Hashtable acoesHashtable = new Hashtable();
	protected int actualState;
	protected int initState;
	protected bool initialized_global_position = false;

	protected PositionGlobal pg;

	public DicionarioAcoes() {

	}
	
	public state getStatePersonagem(int estado){
		return (state)acoesHashtable[estado];
	}

	protected void AddStateTo(state estado) {
		acoesHashtable.Add(estado.id, estado);
	}

	public void setInitState(int istate) {
		initState = istate;
		actualState = istate;
	}

	public void setAState (int stateN)
	{
		actualState = stateN;
	}

	public int getAState ()
	{
		return actualState;
	}

	public void setGloabalPosition(Vector3 pos, int scene) {
		initialized_global_position = true;
		pg.initialized = true;
		pg.position = pos;
		pg.scene_index = scene;
	}

	public PositionGlobal getGlobalPosition() {
		PositionGlobal p;
		p.initialized = initialized_global_position;
		p.position = pg.position;
		p.scene_index = pg.scene_index;

		return p;
	}
}

