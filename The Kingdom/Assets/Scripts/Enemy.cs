using UnityEngine;
using UnityEngine.UI;
public class Enemy : MonoBehaviour {

	[Header ("Enemy Stats")]
	public float speed = 10f;
	public int damage = 2;
	public int health = 3;

	public GameObject swordUI;
	public GameObject healthUI;
	public Text damageText;
	public Text healthText;

	// References
	Rigidbody2D rb2D;
	Castle castle;
	Characters characters;
	Arrow arrow;
	Animator anim;
	GameMaster gm;


	void Start(){
		gm = GameObject.FindGameObjectWithTag("Game Master").GetComponent<GameMaster>();
		anim = GetComponent<Animator>();
		rb2D = GetComponent<Rigidbody2D>();
		castle = GameObject.FindGameObjectWithTag("Game Master").GetComponent<Castle>();
		swordUI.SetActive(false);
		damageText.enabled = false;
	}

	void Update(){

		if(gm.hasBomb == true){
			health = 0;
		}

		healthText.text = health.ToString();

		if(health <= 0){
			anim.SetBool("IsDead", true);
			healthUI.SetActive(false);
			healthText.enabled = false;
			speed = 0;
			damage = 0;
			Destroy(this.gameObject, 2f);
		} 
	}

	void FixedUpdate(){

		// Moves the enemy forward
		Vector2 movement = new Vector2(speed, 0f);
		rb2D.MovePosition(rb2D.position + movement * Time.fixedDeltaTime);
	}

	void OnTriggerEnter2D(Collider2D other){

		// Deals damage to the right castle 
		if(other.CompareTag ("Castle1")){
			castle.healthCastle1 -= damage;
			health = 0;
		} else if(other.CompareTag ("Castle2")){
			castle.healthCastle2 -= damage;
			health = 0;
		} else if(other.CompareTag ("Castle3")){
			castle.healthCastle3 -= damage;
			health = 0;
		} 

		// Deals damage to the character when it contacts it 
		if(other.CompareTag ("Character")){
			characters = other.GetComponent<Characters>();
			if(characters.health >= health){
				// if the friendly character has more health than the enemy, than the enemy dies straight away and the friendly character takes damage.
				characters.health -= damage;
				health = 0;
			} else {
				// if the enemy has more health than the friendly character than it is the friendly character that dies automatically and the enemy that takes damage.
				characters.health = 0;
				health -= characters.damage;
			}

		}

		if(other.CompareTag("Arrow")){
			arrow = other.GetComponent<Arrow>();
			health -= arrow.damage;
			Debug.Log("OUCh");
		}
	}

	void OnMouseEnter(){

		if(health > 0){
			swordUI.SetActive(true);
			damageText.enabled = true;
			damageText.text = damage.ToString();

		}
		transform.localScale += new Vector3(0.05f, 0.05f, 0.05f);
		
	}

	void OnMouseExit(){
		damageText.enabled = false;
		swordUI.SetActive(false);
		transform.localScale -= new Vector3(0.05f, 0.05f, 0.05f);
	}
}
