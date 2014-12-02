using System;
using System.Collections;
using UnityEngine;
/**
 * Classe que gerencia o backlog. Implementa o padrao Singleton
 * */
public class BacklogManager {

	private static BacklogManager instance;
	ArrayList backlog;

	public static BacklogManager getInstance(){
		if (instance == null) {
			instance = new BacklogManager ();
		}
		return instance;
	}
	
	private BacklogManager(){
		this.backlog = new ArrayList ();
	}

	//Adiciona uma fala ao backlog
	public void addToBacklog(DialogLine dialogLine){
		Debug.Log ("Adicionou para o backlog" + dialogLine.getTexto());
		this.backlog.Add (dialogLine);
	}

	//Recupera o backlog inteiro, ja na ordem do mais atual para o mais antigo
	public ArrayList getBacklog(){
		ArrayList backlogReverse = (ArrayList)backlog.Clone();
		backlogReverse.Reverse();
		for (int i = 0; i < backlogReverse.Count; i++) {
			Debug.Log ("Retornou" + ((DialogLine)backlogReverse[i]).getTexto());
		}
		return backlogReverse;
	}
}

