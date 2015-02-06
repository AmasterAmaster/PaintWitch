using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundManager : MonoBehaviour 
{
	private static SoundManager instance;

	public AudioSource player;

	//for use with the GUI script to control the master volume
	public float masterVolume;

	//Ensures that only one of this object is created
	//when using multiple scenes
	void Awake()
	{
		if( instance != null && instance != this )
		{
			Destroy( this.gameObject );
			return;
		}

		else
		{
			instance = this;
		}


		DontDestroyOnLoad( this.gameObject );
	}

	//to update all sounds that this class controls
	public static void updateSoundVolumes()
	{

	}
	
	[HideInInspector]
	public AudioSource BGMInstance;

	public AudioClip BGM;

	/*
	 * To add music/sfx
	 * 1. create a new public AudioClip and name it apporiately
	 * 		ex. public AudioClip foo;
	 * 
	 * 2. add a public static function that plays the AudioClip and returns nothing
	 * 		ex. public static void playFoo()
	 * 			{
	 * 				Play( instance.foo, Vector3.zero );
	 * 			}
	 */





	//plays Background music and also loops it
	public static AudioSource PlayBGM( )
	{
		GameObject temp = new GameObject ( "BGM" );		
		temp.transform.position = Vector3.zero;

		AudioSource source = temp.AddComponent<AudioSource>();
		source.clip = instance.BGM;
		source.volume = 1f;
		source.pitch = 1f;
		source.loop = true;
		source.Play();
		//Destroy(go, clip.length);

		return source;

	}

	//plays a clip with only the point needed
	public static AudioSource Play(AudioClip clip, Vector3 point)
	{
		return Play(clip, point, 1f, 1f);
	}

	//plays a clip with the point and the volume needed
	public static AudioSource Play(AudioClip clip, Vector3 point, float volume)
	{
		return Play(clip, point, volume, 1f);
	}

	//plays a clip with the point, volume and pitch needed
	public static AudioSource Play(AudioClip clip, Vector3 point, float volume, float pitch)
	{
		GameObject temp = new GameObject("Audio: " + clip.name);
		temp.transform.position = point;

		AudioSource source = temp.AddComponent<AudioSource>();
		source.clip = clip;
		source.volume = volume;
		source.pitch = pitch;
		source.Play();
		Destroy(temp, clip.length);


		return source;
	}


}
