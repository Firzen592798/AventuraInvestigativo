using UnityEngine;
using System.Collections;
public class Pocao : Item{
	public Pocao(string nome, string descricao, bool consumivel, Sprite sprite):base(nome, descricao, consumivel, sprite)
	{
		
	}
	public override void usar(){
		Debug.Log ("Usando pocao");
	}
}
