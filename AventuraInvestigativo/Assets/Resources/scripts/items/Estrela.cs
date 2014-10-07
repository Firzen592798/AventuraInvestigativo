using UnityEngine;
using System.Collections;
public class Estrela : Item{
	public Estrela(string nome, string descricao, bool consumivel, Sprite sprite):base(nome, descricao, consumivel, sprite)
	{
		
	}
	public override void usar(){
		Debug.Log ("Usando estrela");
	}
}
