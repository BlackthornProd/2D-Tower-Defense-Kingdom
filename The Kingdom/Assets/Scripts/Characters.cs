using UnityEngine;
using UnityEngine.UI;

public class Characters : MonoBehaviour {

	public int health = 5;
	public int maxHealth;
	public int damage = 2;
	public float refund = 10;

	public Text healthDisplay;
	public Text refundDisplay;
	public GameObject goldUI;
	public Text damageDisplay;
	public GameObject swordUI;
	//public GameObject damageUI;

	Animator anim;

	Castle castle;

	void Start(){
		castle = GameObject.FindGameObjectWithTag("Game Master").GetComponent<Castle>();
		anim = GetComponent<Animator>();
		refundDisplay.enabled = false;
		damageDisplay.enabled = false;
		goldUI.SetActive(false);
		swordUI.SetActive(false);
	}

	void Update(){

		healthDisplay.text = health.ToString();

		if(health <= 0){
			anim.Play("Death Animation");
			damage = 0;
			Destroy(gameObject, 1.25f);
		}

		if(castle.gameOver == true){
			health = 0;
		}
	}



	void OnMouseEnter(){

		// Displays some extra stats of the character
		refundDisplay.enabled = true;
		goldUI.SetActive(true);
		swordUI.SetActive(true);
		damageDisplay.enabled = true;
		refundDisplay.text = refund.ToString();
		damageDisplay.text  = damage.ToString();

		// Makes the character a littke bigger when the mouse hovers over it.
		transform.localScale += new Vector3(0.05f, 0.05f, 0.05f);
	}

	void OnMouseExit(){

		// Hides the extra stats of the character 
		refundDisplay.enabled = false;
		damageDisplay.enabled = false;
		goldUI.SetActive(false);
		swordUI.SetActive(false);

		// Turns the character back to it's default size
		transform.localScale -= new Vector3(0.05f, 0.05f, 0.05f);
	}

	void OnTriggerEnter2D(Collider2D other){

		if(other.CompareTag ("Healing Orb")){

			if(health < maxHealth){
				health ++;
			}
		}

		if(other.CompareTag("Witch Orb")){
			health--;
		}
	}
}
