using UnityEngine;

public class Miner : MonoBehaviour {

	public GameObject goldCollect;
	GameMaster gm;
	public GameObject goldEffect;

	public float TimeBtwGoldSpawns = 5f;
	public float goldBoost = 5;

	AudioSource audio;
	public AudioClip gold;

	void Start(){
		audio = GetComponent<AudioSource>();
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
		audio.clip = gold;
		audio.Play();
		Debug.Log("gooolllldd");
		TimeBtwGoldSpawns = 5f;
		gm.gold += goldBoost;
		Vector3 goldEffectPos = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z - 1 );
		GameObject goldFX = (GameObject)Instantiate(goldEffect, goldEffectPos, transform.rotation);
		Destroy(goldFX, 5f);
	}
}
