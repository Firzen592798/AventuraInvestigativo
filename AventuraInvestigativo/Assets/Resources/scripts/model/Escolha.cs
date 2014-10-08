using UnityEngine;
public class Escolha{
	public string escolha;
	public int novoEstado;
	public Escolha(string escolha, int novoEstado){
		this.escolha = escolha;
		this.novoEstado = novoEstado;
	}
	public string getEscolha(){
		return escolha;
	}
	public void setEscolha(string escolha){
		this.escolha = escolha;
	}
	public int getNovoEstado(){
		return novoEstado;
	}
}