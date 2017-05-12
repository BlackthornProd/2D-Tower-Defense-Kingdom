using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterShoot : MonoBehaviour {

	[Header("Arrow Attributes")]
	public GameObject arrow;
	public Transform shootPoint;
	public float timeBtwShoots = 2f;

	[Header("Target Attributes")]
	bool isTarget = false;
	public LayerMask enemy;

	Animator anim;

	void Start(){

		anim = GetComponent<Animator>();
	}

	void FixedUpdate(){

		// Here the character is detecting wether or not a character is in front of him. If there is a character then he will be able to shoot.
		Vector2 forward = transform.TransformDirection(Vector2.left);
		if(Physics2D.Raycast(transform.position, forward, 100, enemy)){
			isTarget = true;
		} else {
			isTarget = false;
		}

		// the character is shooting
		if(timeBtwShoots <= 0 && isTarget == true){
			anim.Play("Attack Animation");
			Instantiate(arrow, shootPoint.position, shootPoint.rotation);
			timeBtwShoots = 2f;
		} else {
			timeBtwShoots -= Time.deltaTime;
		}

	} 
}
