using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Saper : MonoBehaviour {


	public Button good;
	public Button bad;
	public Transform canvas;
	[SerializeField]
	private Button[] buttons;
	public int x;
	public int y;
	public int max;
	private int win;

	
	void Spam(int x, int y)
	{
		for(int i=0;i<x;i++)
		{
			for(int j=0;j<y;j++)
			{
			Button butt;
			butt = Instantiate(good) as Button;
			butt.transform.SetParent(canvas,false);
			RectTransform rect = butt.GetComponent<RectTransform>();
			rect.anchorMin=new Vector2(0.1f+i/10f,0.1f+j/10f);
			rect.anchorMax=new Vector2(0.2f+i/10f,0.2f+j/10f);
			buttons[i*x+j]=butt;
			}
		}
		while(max!=0)
		{
			int i = Random.Range(0,buttons.Length);
			while(buttons[i].name == "BadButton(Clone)")
			{i = Random.Range(0,buttons.Length);}
			Button butt;
			butt = Instantiate(bad) as Button;
			butt.transform.SetParent(canvas,false);
			RectTransform rect = butt.GetComponent<RectTransform>();
			RectTransform rectOld = buttons[i].GetComponent<RectTransform>();
			rect.anchorMin=rectOld.anchorMin;
			rect.anchorMax=rectOld.anchorMax;
			Destroy(buttons[i]);
			buttons[i]=butt;
			max-=1;
			
		}
		
	}
	
	bool inRange(int i,Button[] butt)
	{
		if(i > 0 && i < butt.Length)
			return true;
		else
			return false;
	}
	void FixButtons(int x, int y)
		{
		for(int i=0;i<x;i++)
		{
			for(int j=0;j<y;j++)
			{
				int c=0;
				Button buttCompare;
				Button butt = buttons[i*x+j];
				Text text = butt.GetComponentInChildren<Text>();
			if(butt.name == "GoodButton(Clone)")
			{
				if(inRange(i*x+j-1,buttons) && (i*x+j)%x!=0)
				{
					buttCompare = buttons[i*x+j-1];
					if(buttCompare.name == "BadButton(Clone)")
					c+=1;
				}
					if(inRange(i*x+j+1,buttons)&& (i*x+j)%x!=x-1)
				{
					buttCompare = buttons[i*x+j+1];
					if(buttCompare.name == "BadButton(Clone)")
						c+=1;
				}
					if(inRange(i*x+j-x-1,buttons) && (i*x+j)%x!=0)
				{
					buttCompare = buttons[i*x+j-x-1];
					if(buttCompare.name == "BadButton(Clone)")
						c+=1;
				}
				if(inRange(i*x+j-x,buttons))
				{
					buttCompare = buttons[i*x+j-x];
					if(buttCompare.name == "BadButton(Clone)")
						c+=1;
				}
					if(inRange(i*x+j-x+1,buttons)&& (i*x+j)%x!=x-1)
				{
						buttCompare = buttons[i*x+j-x+1];
					if(buttCompare.name == "BadButton(Clone)")
						c+=1;
				}
					if(inRange(i*x+j+x-1,buttons)&& (i*x+j)%x!=0)
				{
					buttCompare = buttons[i*x+j+x-1];
					if(buttCompare.name == "BadButton(Clone)")
						c+=1;
				}
				if(inRange(i*x+j+x,buttons))
				{
					buttCompare = buttons[i*x+j+x];
					if(buttCompare.name == "BadButton(Clone)")
						c+=1;
				}
					if(inRange(i*x+j+x+1,buttons)&& (i*x+j)%x!=x-1)
				{
					buttCompare = buttons[i*x+j+x+1];
					if(buttCompare.name == "BadButton(Clone)")
						c+=1;
				}
				
				
				text.text = ""+c;
				
				}
			text.gameObject.SetActive(false);
			}
		}
		}
	
	void Start () {
		max=PlayerPrefs.GetInt("mines");
		if(max==0)
			max=15;
		Debug.Log(""+max);
		win = x*y-max;
		PlayerPrefs.SetInt("pts",win);
		buttons = new Button[x*y];
		Spam(x,y);
		FixButtons(x,y);
	}
	
	void Update () {
		if(PlayerPrefs.GetInt("pts")==0)
		Application.LoadLevel("win");
	
	}
}
