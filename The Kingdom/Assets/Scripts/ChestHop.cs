using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestHop : MonoBehaviour {

	Animator anim;
	public GameMaster gm;
	float detectionGold;

	void Start(){
		
		anim = GetComponent<Animator>();
		detectionGold = gm.gold;
	}

	void Update(){

		Debug.Log(detectionGold + " " +  gm.gold);

		if(detectionGold != gm.gold){
		StartCoroutine(Hopping());
			detectionGold = gm.gold;
		
		} 
	}

	IEnumerator Hopping(){
		anim.Play("Hop Animation");
		yield return new WaitForSeconds(1f);
		anim.Play("Idle Animation");
	}
}
