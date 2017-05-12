using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonTint : MonoBehaviour {

	public int buttonCost;
	public GameMaster gm;

	Image image;
	public Color negativeColor;
	public Color positiveColor;

	void Start(){
		image = GetComponent<Image>();
		if(gm.gold < buttonCost){
			image.color = negativeColor;
		} else {
			image.color = positiveColor;
		}
	}

	void Update(){

		if(gm.gold < buttonCost){
			image.color = negativeColor;
		} else {
			image.color = positiveColor;
		}
	}
}
