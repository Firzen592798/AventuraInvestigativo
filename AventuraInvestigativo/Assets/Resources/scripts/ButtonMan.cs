using UnityEngine;
using System.Collections;

public class ButtonMan : MonoBehaviour {

	GameObject g;
	GameController gm;
	TextMesh txt;
	float charsize;
	float lim1; float lim2;
	bool increases;
	SpriteRenderer logo;
	// Use this for initialization
	void Start () {
		g = GameObject.FindGameObjectWithTag("GameManager");
		gm = (GameController) g.GetComponent(typeof(GameController));
		logo = GameObject.FindGameObjectWithTag ("Logo").GetComponent<SpriteRenderer>();
		txt = GetComponent<TextMesh> ();
		charsize = txt.characterSize;
		lim1 = charsize - 0.05f;
		lim2 = charsize + 0.05f;
		increases = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (increases == true) 
		{
			if (txt.characterSize < lim2)
			{
				txt.characterSize += 0.0025f;
				//txt.transform.Rotate(new Vector3(0.0f,0.0f,0.1f));
				//txt.transform.position += new Vector3(0.0f,0.01f,0.0f);
			}
			else
			{
				increases = false;
			}
		} else
		{
			if (txt.characterSize > lim1)
			{
				txt.characterSize -= 0.0025f;
				//txt.transform.Rotate(new Vector3(0.0f,0.0f,-0.1f));
				//txt.transform.position += new Vector3(0.0f,-0.01f,0.0f);
			}
			else
			{
				increases = true;
			}
		}
		if (logo.color.a < 1.0f) 
		{
			logo.color+= new Color(0.0f,0.0f,0.0f,0.01f);
			txt.color+= new Color(0.0f,0.0f,0.0f,0.01f);
		}
	
	}

	void OnMouseOver()
	{
		txt.color += new Color (1.0f, -1.0f, -1.0f, 0.0f);

		if (Input.GetMouseButton(0)) { //left-click
			//MusicManager mm = (MusicManager) g.GetComponent(typeof(MusicManager));
			//mm.playnew(1);
			gm.TransiteScene("Cena1", "initial_spot");
		}
	}

	void OnMouseExit()
	{
		txt.color += new Color (1.0f, 1.0f, 1.0f, 0.0f);
	}
}
