using UnityEngine;
using System.Collections;

public class TestExamine : MonoBehaviour {

	GameObject g;
	GameController gm;
	TextPlaceholder scr;
	MusicManager mm;
	int objectindex;

	int objectstate;
	int nextstate;

	int textindex;
	int textpages;
	int pagetype;
	bool onregion;

	bool dialog_button_pressed;
	bool up_button_pressed;
	bool down_button_pressed;
	bool showingtext;

	bool choosing;
	int choiceindex;
	string[] choices;

	int faceset;
	int faceind;
	int facepos;

	int charsPerUpdate = 1;
	float timeelapsed;
	float timePerUpdate = 1f;
	float soundPerUpdate = 0.5f;
	float soundelapse;
	string showtext;

	// Use this for initialization
	void Start () {
		g = GameObject.FindGameObjectWithTag("GameManager");
		gm = (GameController) g.GetComponent(typeof(GameController));
		scr = (TextPlaceholder)g.GetComponent (typeof(TextPlaceholder));
		objectindex = GetComponent<NPCController> ().indexnum;
		mm = (MusicManager) g.GetComponent(typeof(MusicManager));
		onregion = false;
		objectstate = 0;
		dialog_button_pressed = false;
		up_button_pressed = false;
		down_button_pressed = false;
		showingtext = false;
		choosing = false;
		choiceindex = 0;
		nextstate = 0;
		faceset = 0;
		facepos = 0;
		faceind = 0;
		timeelapsed = 0;
		soundelapse = 0;
		mm.loadsound (0);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (Teclas.Confirma)) 
		{
			dialog_button_pressed = true;
		}
		if (Input.GetKeyUp (Teclas.Confirma)) 
		{
			dialog_button_pressed = false;
		}
		if (Input.GetKeyDown (KeyCode.DownArrow)) 
		{
			down_button_pressed = true;
		}
		if (Input.GetKeyDown (KeyCode.UpArrow)) 
		{
			up_button_pressed = true;
		}
		if (Input.GetKeyUp (KeyCode.DownArrow)) 
		{
			down_button_pressed = false;
		}
		if (Input.GetKeyUp (KeyCode.UpArrow)) 
		{
			up_button_pressed = false;
		}
		if (showingtext == true) 
		{
			string s2 = gettxt(showtext,Mathf.RoundToInt(timeelapsed*charsPerUpdate));
			if (s2 != null)
			{
				timeelapsed = timeelapsed + timePerUpdate;
				gm.LoadShowTxt(s2);
				soundelapse = soundelapse + soundPerUpdate;
				if (soundelapse == 2f)
				{
					mm.playsound();
					soundelapse = 0f;
				}
			}
			else
			{
				showingtext = false;
				timeelapsed = 0;
				if (pagetype == 1)
				{
					choosing = true;
					choices = scr.LoadChoices(objectindex,objectstate,textindex);
					gm.showchoicebox(choices);
				}
				textindex = textindex+1;
			}
		}
		if (choosing == true) 
		{
			if (up_button_pressed == true)
			{
				if ( choiceindex > 0)
				{
					choiceindex = choiceindex - 1;
					gm.highlightchoice(choiceindex);
					up_button_pressed = false;
				}
			}
			if (down_button_pressed == true)
			{
				if (choiceindex < choices.Length-1)
				{
					choiceindex = choiceindex + 1;
					gm.highlightchoice(choiceindex);
					down_button_pressed = false;
				}
			}
			if (dialog_button_pressed == true)
			{
				// aqui se seleciona o que se faz na escolha
				//teste
				nextstate = scr.LoadChoiceState(objectindex,objectstate,(textindex-1),choiceindex);
				GetComponent<NPCController>().setNext(nextstate);
				nextstate = GetComponent<NPCController>().getState();
				objectstate = nextstate;
				choosing = false;
				textindex = 0;
				gm.hidechoicebox();
				choiceindex = 0;
			}
		}
		if ((dialog_button_pressed == true)&&(onregion == true)&&(choosing == false)) 
		{

			gm.hideppbutton();
			if (textindex == 0)
			{
				gm.lockplayer();
				gm.showdialogbox();
				textpages = scr.NumText(objectindex,objectstate);
			}

			if (textindex < textpages)
			{
				if (showingtext == false)
				{
					showtext = scr.LoadText(objectindex,objectstate,textindex);
					pagetype = scr.LoadType(objectindex,objectstate,textindex);
					faceset = scr.LoadFaceSet(objectindex,objectstate,textindex);
					faceind = scr.LoadFaceIndex(objectindex,objectstate,textindex);
					facepos = scr.LoadFacePos(objectindex,objectstate,textindex);
					gm.showface(facepos,faceset,faceind);
					showingtext = true;
					dialog_button_pressed = false;
				} else
				{
					showingtext = false;
					gm.LoadShowTxt(showtext);
					timeelapsed = 0;
					if (pagetype == 1)
					{
						choosing = true;
						choices = scr.LoadChoices(objectindex,objectstate,textindex);
						gm.showchoicebox(choices);
					}
					textindex = textindex+1;
					dialog_button_pressed = false;
				}
			} else
			{
				textindex = 0;
				dialog_button_pressed = false;
				showtext = "";
				pagetype = -1;
				GetComponent<NPCController>().setNext(0);
				nextstate = GetComponent<NPCController>().getState();
				objectstate = nextstate;
				gm.hideface(0);
				gm.hideface(1);
				gm.LoadShowTxt(showtext);
				gm.hidedialogbox();
				gm.showppbutton();
				gm.unlockplayer();

			}
			
		}
	}

	string gettxt(string text, int charcount)
	{
		if (charcount <= text.Length) {
			return text.Substring(0,charcount);
		}
		else {
			return null;
		}
	}

}
