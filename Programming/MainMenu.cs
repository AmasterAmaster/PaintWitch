using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour
{
	public bool showOptions = false;
	public bool showCredits = false;

	public int fontSize = 20;

	void Awake()
	{
		gameObject.GetComponent<MainMenu>().enabled = true;
    }

	void Start()
	{
		gameObject.GetComponent<MainMenu>().enabled = true;
	}

	void OnGUI()
	{
		//If the user wants to see the options...
		if(showOptions)
		{
			
		}

		if(showCredits)
		{
			
		}

		if(GUI.Button (new Rect (Screen.width / 2 - 100, 50, 200, 50), "Start Game!"))
		{
			//Load the main game
			Application.LoadLevel("TutorialStage");

			//turn off the menu
			gameObject.GetComponent<MainMenu>().enabled = false;
		}

		if(GUI.Button (new Rect (Screen.width / 2 - 100, 150, 200, 50), "Options"))
		{
			//Show the options
			showOptions = !showOptions;
			showCredits = false;
		}

		if(GUI.Button (new Rect (Screen.width / 2 - 100, 250, 200, 50), "credits"))
		{
			//Show the credits
			showOptions = false;
			showCredits = !showCredits;
		}

		if(GUI.Button (new Rect (Screen.width / 2 - 100, 350, 200, 50), "Quit"))
		{
			//Quit the game
			Application.Quit();
		}
	}
}