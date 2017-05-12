using UnityEngine;
using UnityEngine.UI;

public class Node : MonoBehaviour {

	[Header("Node Display Attributes")]
	Image img;
	public Color positiveHoverColor;
	public Color negativeHoverColor;
	public Color destroyColor;

	public float posOffset;

	[Header ("Rows")]
	public Node[] nodesRow1;
	public Node[] nodesRow2;
	public Node[] nodesRow3;
	public Node[] nodesRow4;
	public Node[] nodesRow5;
	public Node[] nodesRow6;
	public Node[] nodesRow7;
	public Node[] nodesRow8;
	public Node[] nodesRow9;

	public GameMaster gm;
	public RandomAction gmRandomAction;

	[Header("Character attributes")]
	private GameObject character;
	private float characterDestroyCost;

	void Start(){
		img = GetComponent<Image>();
		//img.enabled = false;
	}

	void Update(){

		// enable the nodes at the right moment
		if(gm.isTimeToBuild == true || gm.isTimeToDestroy == true){
			img.enabled = true;
		} else {
			img.enabled = false;
		}

		// highlight the nodes in the rigth color when it is time to build
		if(character == null && gm.isTimeToBuild == true){
			img.color = positiveHoverColor;
		} else if(character != null && gm.isTimeToBuild == true) {
			img.color = negativeHoverColor;
		} 

		// highlight the nodes in yellow when it is time to destroy them !
		if(gm.isTimeToDestroy == true){
			img.color = destroyColor;
		}

		// checking if there is already a character on that particular row.
		if(this.gameObject.tag == "Row1" && this.character != null){
			for (int i = 0; i < nodesRow1.Length; i++) {
				if(gm.isTimeToBuild == true){
					nodesRow1[i].img.color = negativeHoverColor;
				}

				nodesRow1[i].character = this.character;
			}
		} else if(this.gameObject.tag == "Row2" && this.character != null){
			for (int i = 0; i < nodesRow2.Length; i++) {
				if(gm.isTimeToBuild == true){
					nodesRow2[i].img.color = negativeHoverColor;
				}
				nodesRow2[i].character = this.character;
			}
		} else if(this.gameObject.tag == "Row3" && this.character != null){
			for (int i = 0; i < nodesRow3.Length; i++) {
				if(gm.isTimeToBuild == true){
					nodesRow3[i].img.color = negativeHoverColor;
				}
				nodesRow3[i].character = this.character;
			}
		} else if(this.gameObject.tag == "Row4" && this.character != null){
			for (int i = 0; i < nodesRow4.Length; i++) {
				if(gm.isTimeToBuild == true){
					nodesRow4[i].img.color = negativeHoverColor;
				}
				nodesRow4[i].character = this.character;
			}
		} else if(this.gameObject.tag == "Row5" && this.character != null){
			for (int i = 0; i < nodesRow5.Length; i++) {
				if(gm.isTimeToBuild == true){
					nodesRow5[i].img.color = negativeHoverColor;
				}
				nodesRow5[i].character = this.character;
			}
		} else if(this.gameObject.tag == "Row6" && this.character != null){
			for (int i = 0; i < nodesRow6.Length; i++) {
				if(gm.isTimeToBuild == true){
					nodesRow6[i].img.color = negativeHoverColor;
				}
				nodesRow6[i].character = this.character;
			}
		} else if(this.gameObject.tag == "Row7" && this.character != null){
			for (int i = 0; i < nodesRow7.Length; i++) {
				if(gm.isTimeToBuild == true){
					nodesRow7[i].img.color = negativeHoverColor;
				}
				nodesRow7[i].character = this.character;
			}
		} else if(this.gameObject.tag == "Row8" && this.character != null){
			for (int i = 0; i < nodesRow8.Length; i++) {
				if(gm.isTimeToBuild == true){
					nodesRow8[i].img.color = negativeHoverColor;
				}
				nodesRow8[i].character = this.character;
			}
		} else if(this.gameObject.tag == "Row9" && this.character != null){
			for (int i = 0; i < nodesRow9.Length; i++) {
				if(gm.isTimeToBuild == true){
					nodesRow9[i].img.color = negativeHoverColor;
				}
				nodesRow9[i].character = this.character;
			}
		}
	}

	public void BuildOrDestroy(){

		// this is to build a character
		if(character == null && gm.isTimeToBuild == true){
			gm.isTimeToBuild = false;
			Vector2 spawnPos = new Vector2(transform.position.x, transform.position.y -0.3f);
			character = (GameObject) Instantiate(gm.currentCharacterToBuild, spawnPos, Quaternion.identity); // spawn character
			characterDestroyCost = gm.currentCharacterValue; // if we destroy the character later on, we know how much he is worth..

		// turns the action buttons off once the player has chosen what action to perform !
		if(gm.isTimeToBuild == false){

				gmRandomAction.noneAction.SetActive(false);
				
				for (int i = 0; i < gmRandomAction.actionButtons.Length; i++) {
					gmRandomAction.actionButtons[i].SetActive(false);
			}
		}
	} 
		// In the player has no more free spaces and clicks on create character... he will simply not be able to build a character !
		if(character != null){
			gm.isTimeToBuild = false;
		}

		// this is to destroy a character
		if(gm.isTimeToDestroy == true){
			gm.isTimeToDestroy = false;
			gm.gold += characterDestroyCost; // give the player back some gold.
			gm.cancelDestroyButton.SetActive(false); 
			Destroy(character);
		}

	}

	void OnMouseEnter(){
		transform.localScale -= new Vector3(0.02f, 0.02f, 0.02f);
	}

	void OnMouseExit(){
		transform.localScale += new Vector3(0.02f, 0.02f, 0.02f);
	}

}
