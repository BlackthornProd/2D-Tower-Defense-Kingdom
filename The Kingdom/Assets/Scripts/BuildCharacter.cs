using UnityEngine;

public class BuildCharacter : MonoBehaviour {

	[Header ("Characters")]	
	public GameObject archerCharacter;
	public GameObject defenderCharacter;
	public GameObject minerCharacter;
	public GameObject bomberCharacter;
	public GameObject priestCharacter;

	[Header("Character Cost")]
	public float archerCost = 25f;
	public float defenderCost = 20f;
	public float minerCost = 25f;
	public float bomberCost = 20f;
	public float priestCost = 30f;

	GameMaster gm;
	RandomAction randomAction;

	void Start(){
		randomAction = GetComponent<RandomAction>();
		gm = GetComponent<GameMaster>();
	}

	public void BuildArcher(){

		// Makes sure you don't build a character if you are in destroy character mode.
		if(gm.isTimeToDestroy == true){
			return;
		} 


		// Building an archer if you have enough gold...
		if(gm.gold >= archerCost){
			gm.gold -= archerCost;
			gm.isTimeToBuild = true;
			gm.currentCharacterToBuild = archerCharacter;
			gm.currentCharacterValue = Mathf.Round(archerCost/2);
			randomAction.Disable();
		}

	}

	public void BuildDefender(){

		if(gm.isTimeToDestroy == true){
			return;
		}

		if(gm.gold >= defenderCost){
			gm.gold -= defenderCost;
			gm.isTimeToBuild = true;
			gm.currentCharacterToBuild = defenderCharacter;
			gm.currentCharacterValue = Mathf.Round(defenderCost/2);
			randomAction.Disable();
		}
	}

	public void BuildMiner(){

		if(gm.isTimeToDestroy == true){
			Debug.Log("FFFFF");
			return;
		}

		if(gm.gold >= minerCost){
			Debug.Log("ffffdfdfsd");
			gm.gold -= minerCost;
			gm.isTimeToBuild = true;
			gm.currentCharacterToBuild = minerCharacter;
			gm.currentCharacterValue = Mathf.Round(minerCost / 2);
			randomAction.Disable();
		}
	}

	public void BuildBomber(){
		if(gm.isTimeToDestroy == true){
			return;
		}

		if(gm.gold >= bomberCost ){
			gm.gold -= bomberCost;
			gm.isTimeToBuild = true;
			gm.currentCharacterToBuild = bomberCharacter;
			gm.currentCharacterValue = Mathf.Round(bomberCost / 2);
			randomAction.Disable();
		}
		
	}

	public void BuildPriest(){

		if(gm.isTimeToDestroy == true){
			return;
		}

		if(gm.gold >= priestCost){
			gm.gold -= priestCost;
			gm.isTimeToBuild = true;
			gm.currentCharacterToBuild = priestCharacter;
			gm.currentCharacterValue = Mathf.Round(priestCost / 2);
			randomAction.Disable();
		}
	}
}
