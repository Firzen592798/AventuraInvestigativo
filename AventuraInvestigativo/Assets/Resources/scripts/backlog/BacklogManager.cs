using System;
using System.Collections;
using UnityEngine;
/**
 * Classe que gerencia o backlog. Implementa o padrao Singleton
 * */
public class BacklogManager {

	private static BacklogManager instance;
	ArrayList backlog;

	ArrayList conversas;

	public static BacklogManager getInstance(){
		if (instance == null) {
			instance = new BacklogManager ();
		}
		return instance;
	}
	
	private BacklogManager(){
		this.backlog = new ArrayList ();
		this.conversas = new ArrayList ();
	}

	//Adiciona uma fala ao backlog
	public void addToBacklog(DialogLine dialogLine){
		//Debug.Log ("Adicionou para o backlog" + dialogLine.getTexto());
		this.backlog.Add (dialogLine);
	}

	//Adiciona uma fala ao backlog
	public void addToBacklog(Conversa conversa){
		//Debug.Log ("Adicionou para o backlog uma conversa");
		this.conversas.Add (conversa);
	}

	public ArrayList getPersonagemBacklog(String nome){
		ArrayList conversasBacklog = new ArrayList ();
		for(int i = conversas.Count - 1; i >= 0; i--){
			Conversa c = (Conversa)conversas[i];
			//Debug.Log (c);
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
		for (int i = 0; i < backlogReverse.Count; i++) {
			//Debug.Log ("Retornou" + ((DialogLine)backlogReverse[i]).getTexto());
		}
		return backlogReverse;
	}
}

