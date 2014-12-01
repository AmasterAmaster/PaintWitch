using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour
{
	public bool inTutorial = false;
	public Animator animator;

	void Start()
	{
		//Save the settings from the menu
		if(GameObject.Find("Menu Object") != null)
		{

		}
	}

	public void thePauseMenu()
	{
		//layout start
		GUI.BeginGroup(new Rect(Screen.width / 2 - 150, 50, 300, 450));
		
		//the menu background box
		GUI.Box(new Rect(0, 0, 300, 450), "");
		
		//logo picture
		//GUI.Label(new Rect(15, 10, 300, 68), logoTexture);
		
		///////pause menu buttons
		//game resume button
		if(GUI.Button(new Rect(55, 100, 180, 40), "Resume"))
		{
			//resume the game
			Time.timeScale = 1.0f;

			animator.SetBool("Move", false);
			
			gameObject.GetComponent<PauseMenu>().enabled = false;
		}
		
		//main menu return button (level 0)
		if(GUI.Button(new Rect(55, 150, 180, 40), "Main Menu"))
		{
			Time.timeScale = 1.0f;
			Application.LoadLevel("MainMenu");
		}

		if(GUI.Button(new Rect(55, 200, 180, 40), "Save"))
		{
			//Save the game
		}

		if(GUI.Button(new Rect(55, 250, 180, 40), "Combos"))
		{
			//List combos
		}

		if(GUI.Button(new Rect(55, 300, 180, 40), "Map"))
		{
			//show the map screen
		}

		if(GUI.Button(new Rect(55, 350, 180, 40), "Items"))
		{
			//show the items menu
		}
		
		if(inTutorial)
		{
			if(GUI.Button(new Rect(55, 400, 180, 40), "Skip tutorial"))
			{
				//Skips the tutorial if in the tutorial scene
				inTutorial = false;
				Time.timeScale = 1.0f;
				Application.LoadLevel("Game");
			}
		}
		
		//layout end
		GUI.EndGroup();
	
	}

	void OnGUI()
	{
		//run the pause menu script
		thePauseMenu();
	}
}