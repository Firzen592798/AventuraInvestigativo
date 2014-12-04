using UnityEngine;
using System.Collections;

public class Escolha{
	private string escolha;
	//private int novoEstado;
	private ArrayList lista_acoes;

	public Escolha(string escolha, int novoEstado, string personagem){
		this.escolha = escolha;
		//this.novoEstado = novoEstado;
		this.lista_acoes = new ArrayList();
		GameObject g = GameObject.FindGameObjectWithTag("GameManager");
		GameController gm = (GameController) g.GetComponent(typeof(GameController));
		this.lista_acoes.Add(new MudarEstado(gm, personagem, novoEstado));
	}

	public Escolha(string escolha, ArrayList ListaAcoes) {
		this.escolha = escolha;
		this.lista_acoes = ListaAcoes;
	}

	public Escolha(string escolha) {
		this.escolha = escolha;
		this.lista_acoes = new ArrayList();
	}
	public string getEscolha(){
		return escolha;
	}

	public void setEscolha(string escolha){
		this.escolha = escolha;
	}

	public ArrayList getListaAcoes(){
		return lista_acoes;
	}

	public void addAcao(Acao a) {
		lista_acoes.Add(a);
	}
}