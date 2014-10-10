using UnityEngine;
public class DialogLine {
	string texto;
	string personagem;
	int sprite;
	int pos;
	public DialogLine(){
		
	}

	public DialogLine(string personagem, string texto, int imagempath){
		this.personagem = personagem;
		this.texto = texto;
		this.sprite = imagempath;
		//this.imagempath = Intimagempath;
	}

	public DialogLine(string personagem, string texto, int imagempath, int pos){
		this.personagem = personagem;
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