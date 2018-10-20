using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GannCell : MonoBehaviour {

	private Text text;
	private Image img;


	public int value;
	public GannMain.NumberType type;

	public void Initial()
	{
		text = GetComponentInChildren<Text> ();
		img = GetComponentInChildren<Image> ();
	}

	public void SetValue(int _value , GannMain.NumberType _type)
	{
		value = _value;
		type = _type;

		text.text = value.ToString ();

		if (type == GannMain.NumberType.cross || type == GannMain.NumberType.edge) {
			img.color = new Color (204.0f/255.0f, 204.0f/255.0f, 204.0f/255.0f);
		}
		if (type == GannMain.NumberType.edgearea) {
			img.color = new Color (230.0f/255.0f, 230.0f/255.0f, 232.0f/255.0f);
		}
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void TriggerColor(Color imgcolor, Color textcolor)
	{
		text.color = textcolor;
		img.color = imgcolor;
	}

	public void Reset()
	{
		text.color = Color.black;

		if (type == GannMain.NumberType.cross || type == GannMain.NumberType.edge) {
			img.color = new Color (204.0f / 255.0f, 204.0f / 255.0f, 204.0f / 255.0f);
		} else if (type == GannMain.NumberType.edgearea) {
			img.color = new Color (239.0f / 255.0f, 240.0f / 255.0f, 242.0f / 255.0f);
		} else {
			img.color = Color.white;
		}
	}
}
