using UnityEngine;
using System.Collections;
public class GerenciadorEstados {

	private static GerenciadorEstados instance;
	Hashtable hash;
	public static GerenciadorEstados getInstance(){
		if (instance == null) {
			instance = new GerenciadorEstados();
		}
		return instance;
	}

	private GerenciadorEstados() {
		hash = new Hashtable();
		hash.Add ("Dark Megaman", 0);
		hash.Add ("Tapete", 0);
		hash.Add ("Papel", 0);
		hash.Add ("Eduardo", 0);
		hash.Add ("Porta", 0);
	}

	public void alterarEstado(string personagem, int novoEstado){
		if (hash.ContainsKey(personagem)) {
			hash[personagem] = novoEstado;
		}
	}

	public int getEstado(string personagem) {
		//Debug.Log ("Estado de " + personagem + " = " + (int)hash [personagem]);
		return (int)hash[personagem];
	}
}