using UnityEngine;
public class DialogLine {
	string texto;
	string personagem;
	string imagempath;
	public DialogLine(){
		
	}

	public DialogLine(string personagem, string texto, string imagempath){
		this.personagem = personagem;
		this.texto = texto;
		this.imagempath = imagempath;
	}
	public string getTexto(){
		return texto;
	}
	public string getPersonagem(){
		return personagem;
	}
	public string getImagempath(){
		return imagempath;
	}
}