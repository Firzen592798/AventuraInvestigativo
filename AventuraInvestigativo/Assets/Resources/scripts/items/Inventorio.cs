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
		items.Add ("Papel", new Papel ("Papel", "Um papel encontrado na sala da mansao", false, null));

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

	public bool TemItem(string item){
		if(itemIndex > 0)
		for (int i = 0; i < itemIndex; i++) {
			if(itemsPegos[i].getNome().Equals(item)){
				return true;
			}
		}
		return false;
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