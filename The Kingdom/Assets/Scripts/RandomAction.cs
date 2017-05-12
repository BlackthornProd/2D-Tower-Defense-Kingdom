using UnityEngine;

public class RandomAction : MonoBehaviour {

	public GameObject[] actionButtons;
	public GameObject noneAction;

	GameMaster gm;
	Castle castle;

	public int actionCost = 10;

	[Header("Button Placement")]
	public Transform buttonTransform01;
	public Transform buttonTransform02;
	public Transform noneButtonTransform;


	void Start(){
		castle = GetComponent<Castle>();
		gm = GetComponent<GameMaster>();
	}

	void Update(){

		// Making sure we have enough gold to buy an action, and if we do, we buy one.
		if(Input.GetKeyDown(KeyCode.Space) && gm.gold >= actionCost && castle.gameOver == false){
			gm.gold -= actionCost;
			TakeAction();
		} 

		if(gm.isTimeToDestroy == true){
			
			NoneAction();
		}

	}


	public void TakeAction(){

		// taking a random action out of all the actions in the actionButtons array.
		int randomAction1 = Random.Range (0, actionButtons.Length);
		int randomAction2 = Random.Range(0, actionButtons.Length);

		// makes sure that the 2 actions proposed aren't the same !
		while(randomAction1 == randomAction2){
			randomAction1 = Random.Range (0, actionButtons.Length);
		}

		// enables the none action and places it in the rigth placement
		Vector3 nonePlacement = new Vector3(noneButtonTransform.position.x, noneButtonTransform.position.y, noneButtonTransform.position.z);
		noneAction.transform.position = nonePlacement;
		noneAction.SetActive(true);

		// enables the 2 random actions you can take.
		for (int i = 0; i < actionButtons.Length; i++) {
			if(i == randomAction1){
				Vector3 buttonPlacement1 = new Vector3(buttonTransform01.position.x, buttonTransform01.position.y, buttonTransform01.position.z);
				actionButtons[i].transform.position = buttonPlacement1;
				actionButtons[i].SetActive(true);

			} else if(i == randomAction2){
				Vector3 buttonPlacement2 = new Vector3(buttonTransform02.position.x, buttonTransform02.position.y, buttonTransform02.position.z);
				actionButtons[i].transform.position = buttonPlacement2;
				actionButtons[i].SetActive(true);

			} else {
				actionButtons[i].SetActive(false);
			}
		}
	}

	public void NoneAction(){

		for (int i = 0; i < actionButtons.Length; i++) {
			actionButtons[i].SetActive(false);
			noneAction.SetActive(false);
			gm.isTimeToBuild = false;
		}
	}

	public void Disable(){

		for (int i = 0; i < actionButtons.Length; i++) {
			actionButtons[i].SetActive(false);
			noneAction.SetActive(false);
		}
	}
}
