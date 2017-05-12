using UnityEngine;

public class Miner : MonoBehaviour {

	public GameObject goldCollect;
	GameMaster gm;

	public float TimeBtwGoldSpawns = 5f;
	public float goldBoost = 5;

	void Start(){
		gm = GameObject.FindGameObjectWithTag("Game Master").GetComponent<GameMaster>();
		goldCollect.SetActive(false);
	}

	void Update(){


		// Making sure it is time for the miner to produce some gold.
		if(TimeBtwGoldSpawns <= 0){
			goldCollect.SetActive(true);

			if(Input.GetKeyDown(KeyCode.C)){

				CollectGold();
			}
		} else {
			goldCollect.SetActive(false);
			TimeBtwGoldSpawns -= Time.deltaTime;
		}
	}

	public void CollectGold(){
		Debug.Log("gooolllldd");
		TimeBtwGoldSpawns = 5f;
		gm.gold += goldBoost;
	}
}
