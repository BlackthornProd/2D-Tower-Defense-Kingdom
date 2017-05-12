using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitchOrb : MonoBehaviour {

	public float speed = 10f;


	void Update(){

		Destroy(gameObject, 10f);
		transform.Translate(Vector2.right * speed * Time.deltaTime);
	}

	void OnTriggerEnter2D(Collider2D other){

		if(other.CompareTag("Character")){
			Destroy(gameObject);
		}
	}
}
