using UnityEngine;
using System.Collections;
public class GerenciadorEstados {

	string[][] estadosPersonagens;
	public GerenciadorEstados(){
		estadosPersonagens = new string[1][];
		estadosPersonagens[0][0] = "Dark Megaman";
		estadosPersonagens[0][1] = "0";
	}
	public void alterarEstado(string personagem, int novoEstado){
		for (int i = 0; i < 1; i++) {
			if(estadosPersonagens[i][0].Equals(personagem)){
				estadosPersonagens[i][1] = novoEstado.ToString();
			}
		}
	}

	public int getEstado(string personagem){
		int result = 0;
		for (int i = 0; i < 1; i++) {
			if(estadosPersonagens[i][0].Equals(personagem)){
				result = int.Parse(estadosPersonagens[i][1]);
			}
		}
		return result;
	}
}