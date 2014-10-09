using UnityEngine;
public abstract class Acao{
	protected GameController gm;
	protected GameObject g;
	public string nome;
	private bool teclaPressionada = false;

	public abstract bool Update ();
	public string getNome(){
		return nome;
	}
	public void setNome(string nome){
		this.nome = nome;
	}
	public Acao(){

	}

	public Acao(string nome){
		this.nome = nome;
	}

	public void pressionarTecla(){
		this.teclaPressionada = true;
	}
}