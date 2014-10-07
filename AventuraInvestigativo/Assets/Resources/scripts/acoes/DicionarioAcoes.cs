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
		Acao a1 = new  MostrarDialogos(d1);
		Acao a2 = new MostrarDialogos (d2);
		Acao a3 = new MostrarDialogos (d3);
		Acao a4 = new MostrarDialogos (d4);
		/*ArrayList dialogos = new ArrayList ();
		dialogos.Add (d1);
		dialogos.Add (d2);
		dialogos.Add (d3);
		dialogos.Add (d4);*/
		//MostrarDialogos mostrarDialogo1 = new MostrarDialogos (dialogos);
		ArrayList acoesDarkMegamanEstadoZero = new ArrayList();
		acoesDarkMegamanEstadoZero.Add (a1);
		acoesDarkMegamanEstadoZero.Add (a2);
		acoesDarkMegamanEstadoZero.Add (a3);
		acoesDarkMegamanEstadoZero.Add (a4);
		acoesHashtable.Add("Dark Megaman-0", acoesDarkMegamanEstadoZero);
	}
	
	public ArrayList getAcoesPersonagem(string personagem, int estado){
		return (ArrayList)acoesHashtable[personagem + "-" + estado];
	}
	
}