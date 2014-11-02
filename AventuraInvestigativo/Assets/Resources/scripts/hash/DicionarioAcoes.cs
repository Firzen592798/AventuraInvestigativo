using UnityEngine;
using System.Collections;
public class DicionarioAcoes {

	protected Hashtable acoesHashtable = new Hashtable();
	protected int actualState;

	public DicionarioAcoes() {

	}
	
	public state getStatePersonagem(int estado){
		return (state)acoesHashtable[estado];
	}

	protected void AddStateTo(state estado) {
		acoesHashtable.Add(estado.id, estado);
	}

	public void setAState (int stateN)
	{
		actualState = stateN;
	}

	public int getAState ()
	{
		return actualState;
	}
}

