using UnityEngine;
public abstract class Item{
	public string descricao;
	public string nome;
	public bool consumivel;
	private Sprite sprite;
	public abstract void usar ();
	public string getNome(){
		return nome;
	}
	public void setNome(string nome){
		this.nome = nome;
	}
	public void setDescricao(string descricao){
		this.descricao = descricao;
	}
	public string getDescricao(){
		return descricao;
	}
	public Sprite getSprite(){
		return sprite;
	}
	public void setSprite(Sprite s){
		this.sprite = s;
	}
	protected Item(string _nome, string _descricao, bool _consumivel, Sprite _sprite){
		this.nome = _nome;
		this.descricao = _descricao;
		this.consumivel = _consumivel;
		this.sprite = _sprite; 
		Debug.Log ("Sprite");
		Debug.Log (sprite);
	}
}