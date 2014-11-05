using UnityEngine;
using System.Collections;
public class MostrarImagemCentral : Acao
{
	string[] textos;
	int nimg;
	Rect tarea;
	float xd;
	float yd;
	int fs;
	int textoatual;

	public MostrarImagemCentral(int n, Rect textarea, float xdev, float ydev, int fsize, string[] texto)
	{
		nimg = n;
		tarea = textarea;
		xd = xdev;
		yd = ydev;
		fs = fsize;
		textos = texto;
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
			gm.showbigimage (nimg, tarea, xd, yd, fs, t);
			textoatual++;
		}
		else if (Input.GetKeyDown (Teclas.Confirma))
		{
			if (textoatual == textos.Length)
			{
				gm.hidebigimage();
				return true;
			}
			string t = textos [textoatual];
			gm.showbigimage (nimg, tarea, xd, yd, fs, t);
			textoatual++;
		}

		return false;

	}
}
