using UnityEngine;
using System.Collections;

public class LoadingScript : MonoBehaviour
{
	public Texture2D loadingScreen;
	public int loading = 0;

	void OnGUI()
	{
		if(Application.isLoadingLevel)
		{
			GUI.Box(new Rect(0, 0, Screen.width, Screen.height), loadingScreen);
			GUI.Label(new Rect(Screen.width / 2 - 10, Screen.height * 3 / 4, 200, 100), loading.ToString() + " %");
			loading += Random.Range(10, 30);
		}
	}
}