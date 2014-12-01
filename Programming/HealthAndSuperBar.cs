using UnityEngine;
using System.Collections;

public class HealthAndSuperBar : MonoBehaviour
{
	public int health = 1000;
	public int superBar = 0;

	public float healthAxis;
	public float superAxis;

	void OnGUI()
	{
		GUI.Box(new Rect(10, 10, health, 100), "Health");
		GUI.Box(new Rect(10, 110, superBar, 100), "Super Bar");
	}
	
	//Update is called once per frame
	void Update ()
	{
		healthAxis = Input.GetAxis("Health");
		superAxis = Input.GetAxis("SuperBar");

		//When the health down is pressed...
		if(healthAxis < 0 )
		{
			//lower the health
			health = health - 100;
		}

		//When the health up is pressed...
		if(healthAxis > 0)
		{
			//lower the health
			health = health + 100;
		}

		//When the super down is pressed...
		if(superAxis < 0)
		{
			//lower the health
			superBar = superBar - 100;
		}

		//When the super up is pressed...
		if(superAxis > 0)
		{
			//lower the health
			superBar = superBar + 100;
		}
	}
}