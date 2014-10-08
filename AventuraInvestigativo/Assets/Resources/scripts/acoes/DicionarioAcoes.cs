using UnityEngine;
using System.Collections;
public class DicionarioAcoes {

	private Hashtable acoesHashtable;
	public DicionarioAcoes(){
		acoesHashtable = new Hashtable ();
		DialogLine d1 = new DialogLine ("Dark Megaman", "Oi", "");
		DialogLine d2 = new DialogLine ("Dark Megaman", "Testando o dialogo", "");
		DialogLine d3 = new DialogLine ("Dark Megaman", "Victor Hugo", "");
		DialogLine d4 = new DialogLine ("Dark Megaman", "Gin", "");
		ArrayList dialogos = new ArrayList ();
		dialogos.Add (d1);
		dialogos.Add (d2);
		dialogos.Add (d3);
		dialogos.Add (d4);
		Acao a1 = new  MostrarDialogos(dialogos);
		ArrayList escolhas = new ArrayList ();
		escolhas.Add ("Explodir");
		escolhas.Add ("Detonar");
		escolhas.Add ("Ganhar");
		Acao a2 = new MostrarEscolhas(new DialogLine("Dark Megaman", "O que voce deseja?", ""), escolhas);
	
		ArrayList acoesDarkMegamanEstadoZero = new ArrayList();
		acoesDarkMegamanEstadoZero.Add (a1);
		acoesDarkMegamanEstadoZero.Add (a2);


		acoesHashtable.Add("Dark Megaman-0", acoesDarkMegamanEstadoZero);
		DialogLine dd1 = new DialogLine ("Dark Megaman", "Mudando o estado", "");
		DialogLine dd2 = new DialogLine ("Dark Megaman", "Testando o novo dialogo", "");
		ArrayList dialogos2 = new ArrayList();
		dialogos2.Add (dd1);
		dialogos2.Add (dd2);
		Acao aa1 = new  MostrarDialogos(dialogos2);
		//Acao aa2 = new MostrarDialogos (dd2);
		ArrayList acoesDarkMegamanEstadoUm = new ArrayList();
		acoesDarkMegamanEstadoUm.Add (aa1);
		//acoesDarkMegamanEstadoUm.Add (aa2);
		acoesHashtable.Add("Dark Megaman-1", acoesDarkMegamanEstadoUm);
	}
	
	public ArrayList getAcoesPersonagem(string personagem, int estado){
		return (ArrayList)acoesHashtable[personagem + "-" + estado];
	}
	
}