using UnityEngine;
using System.Collections;
public class MostrarImagemCentral : Acao
{
	string[] textos;
	int[] nimg;
	Rect tarea;
	float xd;
	float yd;
	int fs;
	int textoatual;
	Color tcolor;

	public MostrarImagemCentral(int[] n, Rect textarea, float xdev, float ydev, int fsize, string[] texto, Color color)
	{
		nimg = n;
		tarea = textarea;
		xd = xdev;
		yd = ydev;
		fs = fsize;
		textos = texto;
		tcolor = color;
		textoatual = 0;
		g = GameObject.FindGameObjectWithTag("GameManager");
		gm = (GameController) g.GetComponent(typeof(GameController));
	}

	public override bool Update()
	{
		gm.lockplayer();
		if (textoatual == 0)
		{
			string t = textos [textoatual];
			int ti = nimg[textoatual];
			gm.showbigimage (ti, tarea, xd, yd, fs, t, tcolor);
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
			gm.showbigimage (ti, tarea, xd, yd, fs, t, tcolor);
			textoatual++;
		}

		return false;

	}
}
