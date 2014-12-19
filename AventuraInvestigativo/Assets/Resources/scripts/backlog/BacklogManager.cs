using System;
using System.Collections;
using UnityEngine;
/**
 * Classe que gerencia o backlog. Implementa o padrao Singleton
 * */
public class BacklogManager {

	private static BacklogManager instance;
	ArrayList backlog;

	ArrayList historic;
	//ArrayList conversas;
	Hashtable conversas;

	public static BacklogManager getInstance(){
		if (instance == null) {
			instance = new BacklogManager ();
		}
		return instance;
	}
	
	private BacklogManager(){
		this.backlog = new ArrayList ();
		//this.conversas = new ArrayList ();
		this.conversas = new Hashtable();
		this.historic = new ArrayList();
	}

	public void reset() {
		if (historic.Count > 0) {
			for(int i = 0; i < historic.Count; i++) {
				Conversa c = (Conversa)historic[i];
				conversas[c.getRotulo()] = c;
			}
			historic = new ArrayList();
		}
	}

	public Conversa[] getHistoric() {
		Conversa[] clist = new Conversa[historic.Count];
		for(int i = 0; i < historic.Count; i++) {
			clist[i] = (Conversa)historic[i];
		}
		return clist;
	}

	//Adiciona uma fala ao backlog
	public void addToBacklog(DialogLine dialogLine){
		//Debug.Log ("Adicionou para o backlog" + dialogLine.getTexto());
		this.backlog.Add (dialogLine);
	}

	//Adiciona uma fala ao backlog
	public void addToBacklog(string rotulo){//Conversa conversa){
		//Debug.Log ("Adicionou para o backlog uma conversa");
		//this.conversas.Add (conversa);

		if (conversas.ContainsKey(rotulo)) {
			historic.Add(conversas[rotulo]);
			conversas.Remove(rotulo);
		}
	}

	public void addConversa(Conversa c) {
		if (c != null) {
			string rotulo = c.getRotulo();
			this.conversas[rotulo] = c;
			//this.conversas.Add(c);
		}
	}

	public ArrayList getPersonagemBacklog(String nome){
		ArrayList conversasBacklog = new ArrayList ();
		//for(int i = conversas.Count - 1; i >= 0; i--){
		for(int i = historic.Count - 1; i >= 0; i--){
			Conversa c = (Conversa)historic[i];//(Conversa)conversas[i];

			int count = 0;
			if(c != null){
				count = c.getPersonagens().Count;
			}
			for(int j = 0; j < count; j++){
				string personagem = (String)c.getPersonagens()[j];
				if(personagem.Contains(nome)){
					if(!conversasBacklog.Contains(c)){
						conversasBacklog.Add(c);
					}
					j = c.getPersonagens().Count;
					
				}
			}
		}
		return conversasBacklog;
	}

	public ArrayList getDialogos(Conversa c){
		return c.getDialogos ();
	}

	//Recupera o backlog inteiro, ja na ordem do mais atual para o mais antigo
	public ArrayList getBacklog(){
		ArrayList backlogReverse = (ArrayList)backlog.Clone();
		backlogReverse.Reverse();
		//for (int i = 0; i < backlogReverse.Count; i++) {
		//	Debug.Log ("Retornou" + ((DialogLine)backlogReverse[i]).getTexto());
		//}
		return backlogReverse;
	}
}

