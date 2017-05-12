using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour {

	public GameObject healingOrb;
	public Transform healSpawnPoint;

	public float startTimeToHeal = 6f;
	float timeBtwHealing = 6f;

	void Update(){


		if(timeBtwHealing <= 0){

			Instantiate(healingOrb, healSpawnPoint.position, healSpawnPoint.rotation);
			timeBtwHealing = 6f;

		} else {

			timeBtwHealing -= Time.deltaTime;
		}
	}
}
