using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

	public float speed = 10f;
	public int damage = 1;

	void Update(){

		Destroy(gameObject, 10f);
		transform.Translate(Vector2.left * speed * Time.deltaTime);
	}

	void OnTriggerEnter2D(Collider2D other){

		if(other.tag == "Enemy"){
			Destroy(this.gameObject);
		}
	}
}
