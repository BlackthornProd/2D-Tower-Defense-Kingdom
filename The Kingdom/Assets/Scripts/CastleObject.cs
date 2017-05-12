using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleObject : MonoBehaviour {

	Animator anim;
	float detectionRadius = 10;
	public LayerMask enemy;

	void Start(){

		anim = GetComponent<Animator>();
		anim.enabled = false;
	}

	void Update(){

		Collider[] isAttacked = Physics.OverlapSphere(transform.position, detectionRadius, enemy);
		if(isAttacked.Length != 0){
			Debug.Log("GITTTT");
			anim.enabled = true;
		} else {
			anim.enabled = false;
		}


	}

}
