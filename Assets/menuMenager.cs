using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class menuMenager : MonoBehaviour {
	public Text txt;
	public int c;

	public void SetC(float x)
	{
		c=(int)x;
		PlayerPrefs.SetInt("mines",c);
	}
	void Start () {
		c=15;
	}
	
	void Update () {
	 txt.text = "Mines: "+c;
	 
	}
}
