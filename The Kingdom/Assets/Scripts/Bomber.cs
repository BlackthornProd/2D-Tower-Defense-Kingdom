using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomber : MonoBehaviour {

	GameMaster gm;
	Castle castle;

	public int damage = 2;

	void Start(){
		castle = GameObject.FindGameObjectWithTag("Game Master").GetComponent<Castle>();
		gm = GameObject.FindGameObjectWithTag("Game Master").GetComponent<GameMaster>();
	}

	void OnTriggerEnter2D(Collider2D other){

		if(other.CompareTag("Enemy")){
			gm.hasBomb = true;
			castle.healthCastle1 -= damage;
			castle.healthCastle2 -= damage;
			castle.healthCastle3 -= damage;
		}
	}

}
