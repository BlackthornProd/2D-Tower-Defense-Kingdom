using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour {

	[Header("Build and Destroy")]
	public bool isTimeToBuild = false;
	public bool isTimeToDestroy = false;
	public GameObject cancelDestroyButton;

	[Header("Character Attributes")]
	public GameObject currentCharacterToBuild;
	public float currentCharacterValue;

	[Header("Gold Attributes")]
	public float gold = 100;
	public ChestHop chest;
	public float TimeBtwFreeGold = 7.5f;
	public Text goldDisplay;

	public bool hasBomb = false;

	Spawner spawner;
	Castle castle;

	public Text freeGoldIncomeDisplay;
	public float freeGold;


	void Start(){

		castle = GetComponent<Castle>();
		spawner = GetComponent<Spawner>();
		cancelDestroyButton.SetActive(false);
		currentCharacterToBuild = null;
		freeGoldIncomeDisplay.enabled = false;
	}

	void Update(){

		if(hasBomb == true){
			StartCoroutine(StopBomb());
		}
		goldDisplay.text = gold.ToString();

		if(TimeBtwFreeGold <= 0 && castle.gameOver == false){
			
			if(spawner.waveNumber <= 4){
				freeGold = 10f;
			} else if(spawner.waveNumber > 4 && spawner.waveNumber <= 7){
				freeGold = 20f;
			} else if(spawner.waveNumber > 7){
				freeGold = 30f;
			}
			gold += freeGold;
			TimeBtwFreeGold = 8.5f;
			StartCoroutine(ShowFreeGold());
		} else {
			TimeBtwFreeGold -= Time.deltaTime;
		}

		if(isTimeToDestroy == true){
			cancelDestroyButton.SetActive(true);
		}

	}

	public void CancelDestroy(){

		isTimeToDestroy = false;
		cancelDestroyButton.SetActive(false);
	}

	IEnumerator StopBomb(){

		yield return new WaitForSeconds(1f);
		hasBomb = false;
	}



	IEnumerator ShowFreeGold(){

		freeGoldIncomeDisplay.enabled = true;
		freeGoldIncomeDisplay.text = "FREE GOLD : " + freeGold;
		yield return new WaitForSeconds(3f);
		freeGoldIncomeDisplay.enabled = false;
	}
}
