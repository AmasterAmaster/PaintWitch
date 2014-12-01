using UnityEngine;
using System.Collections;

public class ComboMeter : MonoBehaviour
{
	public float resetTimer = 5;
	public int combo = 0;

	public GUIText comboMeterText;
	public GUIText resetText;

	void Start()
	{
		comboMeterText.text = "";
		resetText.text = "";
	}

	//Update is called once per frame
	void Update()
	{
		//Test: when the key is pressed, update the combo meter
		if(Input.GetButtonDown("Count"))
		{
			//Update the combo meter
			combo++;

			//reset the reset timer
			resetTimer = 5;
		}

		if(resetTimer <= 0)
		{
			//Reset the combo to 0;
			combo = 0;
		}

		//Update the reset timer
		resetTimer = resetTimer - Time.deltaTime;

		//Show the user
		comboMeterText.text = "" + combo + "X kill count";
		resetText.text = "" + (int)resetTimer;
	}
}