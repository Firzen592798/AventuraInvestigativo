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

	public MostrarImagemCentral(GameController gm, int[] n, float xta, float yta, float xdev, float ydev, float fsize, string[] texto, Color color)
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
		this.gm = gm;
	}

	public override bool Update()
	{
		gm.lockplayer();
		if (textoatual == 0)
		{
			string t = textos [textoatual];
			int ti = nimg[textoatual];
			gm.showbigimage (ti, tax, tay, xd, yd, fs, t, tcolor);
			textoatual++;
		}
		else if (Input.GetKeyDown (Teclas.Confirma))
		{
			if (textoatual == textos.Length)
			{
				//gm.hidebigimage();
				return true;
			}
			string t = textos [textoatual];
			int ti = nimg[textoatual];
			gm.showbigimage (ti, tax, tay, xd, yd, fs, t, tcolor);
			textoatual++;
		}

		return false;

	}
}
