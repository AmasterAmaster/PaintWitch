//Notes:
//When using the save feature, this is supported for mobile development and desktop development.
//This will not work for web development, for that kind of saving, it must be saved to the web server.

using UnityEngine;
using System.Collections;
using System;											//Use the System functions
using System.Runtime.Serialization.Formatters.Binary;	//Make the save files formated in binary
using System.IO;										//Use the input and output

public class PersistenceTest : MonoBehaviour
{
	public static PersistenceTest test;	//Can be accessed as a singleton

	//Example stuff to keep track of
	public int health = 100;
	public int exp = 1200;

	//Do this before the game starts (Making a snigleton)
	void Awake()
	{
		//If there is no persistence yet...
		if(test == null)
		{
			//Set this script/gameObject as the persisting values
			DontDestroyOnLoad(gameObject);
			test = this;
		}
		//else if there is already a persisting object like this...
		else if(test != this)
		{
			//destroy this immediatly
			Destroy(gameObject);
		}
	}

	//Show an example
	void OnGUI()
	{
		//Show that data is persisting
		GUI.Label(new Rect(10, 10, 100, 30), "Health: " + health);
		GUI.Label(new Rect(10, 40, 130, 30), "Experience: " + exp);
	}

	//If you want to automatically save/load when the script is enabled
	//void OnEnable()
	//{
    //    print("script was enabled");
    //}

	//void OnDisable()
	//{
    //    print("script was removed");
    //}

	//Save the game data (only works for desktop and mobile development)
	public void Save()
	{
		//Open the file location (player info)
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");

		//Create (instanciate) the class (data container)
		PlayerData data = new PlayerData();

		//Store the values here (recommeneded to use getters and setters for this)
		data.health = health;
		data.exp = exp;

		//Write to the file
		bf.Serialize(file, data);
		file.Close();
	}

	//Load the game data (only works for desktop and mobile development)
	public void Load()
	{
		//If the file exists...
		if(File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
		{
			//Open the file location (player info)
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);

			//Get the information out of the file
			PlayerData data = (PlayerData)bf.Deserialize(file);
			file.Close();

			//Get the information you want
			health = data.health;
			exp = data.exp;
		}
	}
}

//A private class to store the data, then the class is serialized to fit nicely in a binary file.
[Serializable]
class PlayerData
{
	//Store whatever you need here, this is a data container to store your data
	//Recommeneded to do basic OOP prectice here (constructers and etc...)
	public int health;
	public int exp;
}