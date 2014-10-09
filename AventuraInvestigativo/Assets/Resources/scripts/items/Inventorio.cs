using System.Collections;
using UnityEngine;
public class Inventorio{
	private Item[] itemsPegos;
	private Hashtable items;
	private int itemIndex;
	private int size;
	public Inventorio(int size){
		itemIndex = 0;
		itemsPegos = new Item[size];
		this.size = size;
		items = new Hashtable ();
		//Sprite spriteEspada = Resources.Load<Sprite>("Assets/Resources/prefab/
		items.Add ("Espada", new Espada ("Espada", "corta alguem", false, null));
		//Sprite spritePocao = Resources.Load<Sprite> ("Assets/Resources/prefab/Pocao");
		items.Add ("Pocao", new Pocao ("Pocao", "mapa da mansao", true, null));
		items.Add ("Estrela", new Espada ("Estrela", "Solta magia", false, null));
		items.Add ("Escudo", new Pocao ("Escudo", "Protege", false, null));

		items.Add ("Chave", new Chave ("Chave", "Uma misteriosa chave que abre alguma porta da mansao", false, null));

	}

	public Item[] getItems(){
		return itemsPegos;
	}

	public int count(){
		return itemIndex;
	}

	public void addItem(string item, Sprite sprite){
		if (itemIndex < size) {
			Debug.Log ("Pegou " + item);	
			((Item)items[item]).setSprite(sprite);
			Debug.Log (sprite);
			itemsPegos [itemIndex] = (Item)items [item];
			itemIndex++;
		}
	}


	public void removerItem(string item){
		if(itemIndex > 0)
			for (int i = 0; i < itemsPegos.Length; i++) {
				if(itemsPegos[i].getNome().Equals(item)){
					for(int j = i; j < itemIndex - 1; j++){
						itemsPegos[j] = itemsPegos[j + 1];
					}
					itemIndex --;
				}
			}

	}
}