using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitchShoot : MonoBehaviour {

	public GameObject witchShot;
	public Transform shootPoint;

	public float startTimeBtwShots = 2f;
	float timeBtwShoots;

	Enemy enemy;


	void Start(){

		enemy= GetComponent<Enemy>();
		timeBtwShoots = startTimeBtwShots;
	}

	void Update(){

		if(timeBtwShoots <= 0 && enemy.health > 0){

			Instantiate(witchShot, shootPoint.position, shootPoint.rotation);
			timeBtwShoots = startTimeBtwShots;

		} else {
			timeBtwShoots -= Time.deltaTime;
		}
	}
}
