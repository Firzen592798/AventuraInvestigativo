using UnityEngine;
using System.Collections;
public class Escudo : Item{
	public Escudo(string nome, string descricao, bool consumivel, Sprite sprite):base(nome, descricao, consumivel, sprite)
	{
		
	}
	public override void usar(){
		Debug.Log ("Usando escudo");
	}
}
