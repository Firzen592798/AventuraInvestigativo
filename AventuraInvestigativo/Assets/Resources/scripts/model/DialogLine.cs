using UnityEngine;
public class DialogLine {
	string texto;
	string personagem;
	int sprite;
	int pos;
	public DialogLine(){
		
	}

	public DialogLine(string texto, int imagempath){
		this.texto = texto;
		this.sprite = imagempath;
		//this.imagempath = Intimagempath;
	}

	public DialogLine(string texto, int imagempath, int pos){
		this.texto = texto;
		this.sprite = imagempath;
		this.pos = pos;
		//this.imagempath = Intimagempath;
	}

	public int getPos(){
		return pos;
	}

	public string getTexto(){
		return texto;
	}
	public string getPersonagem(){
		return personagem;
	}
	public int getSprite(){
		return sprite;
	}
}