using UnityEngine;
using System;

[Serializable]
public class Item{
	private string descricao;
	private string nome;
	private bool consumivel;
	private string spritepath;
	public void usar () {
	}
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
		Sprite s = (Sprite)Resources.Load<Sprite>(spritepath);
		return s;
	}
	public string getSpritePath(){
		return this.spritepath;
	}
	public void setSprite(string spritepath){
		this.spritepath = spritepath;
	}
	public Item(string _nome, string _descricao, bool _consumivel, string _spritepath){
		this.nome = _nome;
		this.descricao = _descricao;
		this.consumivel = _consumivel;
		this.spritepath = _spritepath; 
		Debug.Log ("Sprite = "+spritepath);
	}
}