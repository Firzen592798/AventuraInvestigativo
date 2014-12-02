using UnityEngine;
using System.Collections;
public class Conversa {
	private string rotulo;
	private ArrayList dialogos;
	private ArrayList personagens;
	public Conversa(){
		this.rotulo = "";
		this.dialogos = new ArrayList ();
		this.personagens = new ArrayList ();
	}
	
	public Conversa(string rotulo, ArrayList dialogos, ArrayList personagens){
		this.rotulo = rotulo;
		this.dialogos = dialogos;
		this.personagens = personagens;
	}

	public Conversa(string rotulo, DialogLine dialog){
		this.rotulo = rotulo;
		this.dialogos = dialogos;
		dialogos = new ArrayList ();
		dialogos.Add (dialog);
		personagens = new ArrayList ();
		personagens.Add (dialog.getPersonagem ());
	}



	public Conversa(string rotulo, ArrayList dialogos){
		this.rotulo = rotulo;
		this.dialogos = dialogos;
		this.personagens = new ArrayList ();
		for (int i = 0; i < dialogos.Count; i++) {
			DialogLine d = ((DialogLine)dialogos[i]);
			if(d.getPersonagem() != null && !d.getPersonagem().Equals("") && !personagens.Contains(d.getPersonagem())){
				personagens.Add(d.getPersonagem());
			}
		}
	}

	public string getRotulo(){
		return rotulo;
	}

	public ArrayList getDialogos(){
		return dialogos;
	}

	public ArrayList getPersonagens(){
		return personagens;
	}
}