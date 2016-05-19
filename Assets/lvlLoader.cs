using UnityEngine;
using System.Collections;

public class lvlLoader : MonoBehaviour {

	// Use this for initialization
	public void LoadLVL(string name)
	{
		Application.LoadLevel(name);
	}
	public void PP()
	{
		PlayerPrefs.SetInt("pts",PlayerPrefs.GetInt("pts")-1);
	}
	
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
