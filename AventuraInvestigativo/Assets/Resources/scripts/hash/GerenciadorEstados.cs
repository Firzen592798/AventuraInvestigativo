using UnityEngine;
using System.Collections;
public class GerenciadorEstados {

	private static GerenciadorEstados instance;
	DicionarioAcoes dict;
	Hashtable hash;
	public static GerenciadorEstados getInstance(){
		if (instance == null) {
			instance = new GerenciadorEstados();
		}
		return instance;
	}

	private GerenciadorEstados() {
		dict = new DicionarioAcoes();
		hash = new Hashtable();
		hash.Add ("Tapete", 0);
		hash.Add ("Papel", 0);
		hash.Add ("Eduardo", 0);
	}

	public void alterarEstado(string personagem, int novoEstado){
		if (hash.ContainsKey(personagem)) {
			hash[personagem] = novoEstado;
		}
	}

	public int getEstadoIndex(string personagem) {
		//Debug.Log ("Estado de " + personagem + " = " + (int)hash [personagem]);
		return (int)hash[personagem];
	}

	public state getEstado(string personagem) {
		return dict.getStatePersonagem(personagem, (int)hash[personagem]);
	}
}