using UnityEngine;
using System.Collections;

public class CombatScript : MonoBehaviour
{
	//Numbers to keep track of
	public float resetTimer = 1f;
	public int hit = 0;
	public float waitTimer = 0.25f;

	//triggers for entering the button press for the first time
	public bool firstTimeEntering01 = true;
	public bool firstTimeEntering02 = true;
	public bool firstTimeEntering03 = true;
	public bool firstTimeEntering04 = true;
	public bool firstTimeEntering05 = true;
	public bool firstTimeEntering06 = true;

	//triggers if the button was already pressed
	public bool triggered01 = false;
	public bool triggered02 = false;
	public bool triggered03 = false;
	public bool triggered04 = false;
	public bool triggered05 = false;
	public bool triggered06 = false;

	//Locked moves (unlocked by pressing a button)
	public bool lockedCombo01 = true;
	public bool lockedCombo02 = true;
	public bool lockedCombo03 = true;

	public GUIText combatText;
	public GUIText resetText;

	void Start()
	{
		combatText.text = "";
		resetText.text = "";
	}

	//Update is called once per frame
	void Update()
	{
		//Test: when the key is pressed, update the combo meter
		if(Input.GetButtonDown("Count") || triggered01)
		{
			//Update the hit meter
			if(firstTimeEntering01)
			{
				hit++;
				//reset the reset timer
				resetTimer = 1;
				firstTimeEntering01 = false;
				triggered01 = true;

				//wait for the waitTimer to finish before swinging again
				waitTimer = 0.25f;
			}
			
			//Check for another button to be pressed
			if((Input.GetButtonDown("Count") || triggered02) && waitTimer <= 0)
			{
				//Update the hit meter
				if(firstTimeEntering02)
				{
					hit++;
					//reset the reset timer
					resetTimer = 1;
					firstTimeEntering02 = false;
					triggered02 = true;

					//wait for the waitTimer to finish before swinging again
					waitTimer = 0.25f;
				}

				//Check for another button to be pressed
				if((Input.GetButtonDown("Count") || triggered03) && waitTimer <= 0)
				{
					//Update the hit meter
					if(firstTimeEntering03)
					{
						hit++;
						//reset the reset timer
						resetTimer = 1;
						firstTimeEntering03 = false;
						triggered03 = true;

						//wait for the waitTimer to finish before swinging again
						waitTimer = 0.25f;
					}

					//Check for another button to be pressed ---------------------(UNLOCKABLE COMBOS START)-----------------------------
					if((Input.GetButtonDown("Count") || triggered04) && waitTimer <= 0 && !lockedCombo01)
					{
						//Update the hit meter
						if(firstTimeEntering04)
						{
							hit++;
							//reset the reset timer
							resetTimer = 1;
							firstTimeEntering04 = false;
							triggered04 = true;
	
							//wait for the waitTimer to finish before swinging again
							waitTimer = 0.25f;
						}
	
						//Check for another button to be pressed 
						if((Input.GetButtonDown("Count") || triggered05) && waitTimer <= 0 && !lockedCombo02)
						{
							//Update the hit meter
							if(firstTimeEntering05)
							{
								hit++;
								//reset the reset timer
								resetTimer = 1;
								firstTimeEntering05 = false;
								triggered05 = true;
		
								//wait for the waitTimer to finish before swinging again
								waitTimer = 0.25f;
							}
		
							//Check for another button to be pressed 
							if((Input.GetButtonDown("Count") || triggered06) && waitTimer <= 0 && !lockedCombo03)
							{
								//Update the hit meter
								if(firstTimeEntering06)
								{
									hit++;
									//reset the reset timer
									resetTimer = 1;
									firstTimeEntering06 = false;
									triggered06 = true;
			
									//wait for the waitTimer to finish before swinging again
									waitTimer = 0.25f;
								}
			
								//Check for another button to be pressed 
								//Copy and paste here
							}
						}
					}
				}
			}
		}

		if(resetTimer <= 0)
		{
			//Reset the hit to 0;
			hit = 0;

			//reset the entry points for consecutive hits
			firstTimeEntering01 = true;
			firstTimeEntering02 = true;
			firstTimeEntering03 = true;
			firstTimeEntering04 = true;
			firstTimeEntering05 = true;
			firstTimeEntering06 = true;

			//Reset the button press history
			triggered01 = false;
			triggered02 = false;
			triggered03 = false;
			triggered04 = false;
			triggered05 = false;
			triggered06 = false;

			//Reset the waitTimer
			waitTimer = 0.25f;
		}

		//Update the reset timer
		resetTimer = resetTimer - Time.deltaTime;
		waitTimer = waitTimer - Time.deltaTime;

		//Show the user
		combatText.text = "" + hit + " Hit(s)";
		resetText.text = "" + (int)resetTimer;

		//unlock more combos
		if(Input.GetKey("1"))
		{
			//Unlock the 4th combo
			lockedCombo01 = false;
		}

		if(Input.GetKey("2"))
		{
			//Unlock the 5th combo
			lockedCombo02 = false;
		}

		if(Input.GetKey("3"))
		{
			//Unlock the 6th combo
			lockedCombo03 = false;
		}
	}
}