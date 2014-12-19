using UnityEngine;
using System.Collections;
public class MostrarImagemCentral : Acao
{
	string[] textos;
	int[] nimg;
	float tax;
	float tay;
	float xd;
	float yd;
	float fs;
	int textoatual;
	Color tcolor;
	TextAnchor alig;
	double[] ptm;
	float tempo_inicial;
	double wait_seconds;

	public MostrarImagemCentral(GameController gm, int[] n, float xta, float yta, float xdev, float ydev, float fsize, string[] texto, Color color, TextAnchor alin)
	{
		nimg = n;
		tax = xta;
		tay = yta;
		xd = xdev;
		yd = ydev;
		fs = fsize;
		textos = texto;
		tcolor = color;
		textoatual = 0;
		ptm = new double[texto.Length];
		for(int i = 0; i < ptm.Length; i++) {ptm[i] = -1;}
		alig = alin;
		tempo_inicial = -1;
		this.gm = gm;
	}

	public MostrarImagemCentral(GameController gm, int[] n, float xta, float yta, float xdev, float ydev, float fsize, string[] texto, Color color, TextAnchor alin, double[] ptimer) {
		nimg = n;
		tax = xta;
		tay = yta;
		xd = xdev;
		yd = ydev;
		fs = fsize;
		textos = texto;
		tcolor = color;
		textoatual = 0;
		ptm = ptimer;
		alig = alin;
		tempo_inicial = -1;
		this.gm = gm;
	}

	public override bool Update()
	{
		gm.lockplayer();
		if (textoatual == 0)
		{
			string t = textos [textoatual];
			int ti = nimg[textoatual];
			wait_seconds = ptm[textoatual];
			gm.GameInterface.showbigimage (ti, tax, tay, xd, yd, fs, t, tcolor, alig);
			//textoatual++;
		}
		else 
			Debug.Log(textoatual+","+(textos.Length-1));
		if (ptm[textoatual] == -1)
		{
			if (Input.GetKeyDown (Teclas.Confirma))
			{
				if (textoatual == textos.Length-1)
				{
					//gm.hidebigimage();
					return true;
				}
				string t = textos [textoatual];
				int ti = nimg[textoatual];
				gm.GameInterface.showbigimage (ti, tax, tay, xd, yd, fs, t, tcolor, alig);
				textoatual++;
			}
		}else
		{
			if (tempo_inicial == -1) {
				tempo_inicial = Time.time;
			}
			if (Time.time - tempo_inicial < wait_seconds) {
				return false;
			}
			else {
				if (textoatual == textos.Length-1)
				{
					//gm.hidebigimage();
					Debug.Log("Acabou");
					return true;
				}
				textoatual++;
				tempo_inicial = -1;
				wait_seconds = ptm[textoatual];
				string t = textos [textoatual];
				int ti = nimg[textoatual];
				gm.GameInterface.showbigimage (ti, tax, tay, xd, yd, fs, t, tcolor, alig);


			}
		}
			
		return false;

	}
}
