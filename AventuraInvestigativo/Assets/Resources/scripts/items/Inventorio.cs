using System.Collections;
using UnityEngine;
public class Inventorio{
	private ArrayList itemsPegos;
	//private Item[] itemsPegos;
	private Hashtable items;
	private int items_quant;
	public Inventorio(){
		itemsPegos = new ArrayList();
		items_quant = 0;
		items = new Hashtable ();
		items.Add ("Papel", new Item ("Papel", "Um papel encontrado na sala da mansão", false, null));
		items.Add ("Chave", new Item ("Chave", "Uma misteriosa chave que abre alguma porta da mansão", false, null));

	}

	public Item[] getItems(){
		Item[] _items = new Item[items_quant];
		for(int i = 0; i < items_quant; i++) {
			_items[i] = (Item)itemsPegos[i];
		}
		return _items;
	}

	public Item[,,] getItemGrid() {
		Item[,,] item_grid = new Item[4,4,3];

		int i, j, k;
		int q = Mathf.Min(items_quant, 48);
		for (int n = 0; n < q; n++) {
			i = (n/4)%4;
			j = n%4;
			k = n/16;
			item_grid[i,j,k] = (Item)itemsPegos[n];
		}
		return item_grid;
	}

	public int count(){
		return items_quant;
	}

	public void addItem(string item, string spritepath){
		Debug.Log ("Pegou " + item);
		((Item)items[item]).setSprite(spritepath);
		Debug.Log (spritepath);
		itemsPegos.Add((Item)items[item]);
		items_quant++;
	}

	public bool TemItem(string item){
		for (int i = 0; i < items_quant; i++) {
			if(((Item)itemsPegos[i]).getNome().Equals(item)){
				return true;
			}
		}
		return false;
	}

	public void removerItem(string item){
		for (int i = 0; i < items_quant; i++) {
			if(((Item)itemsPegos[i]).getNome().Equals(item)){
				itemsPegos.RemoveAt(i);
			}
		}
	}
}