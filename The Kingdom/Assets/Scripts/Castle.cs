using UnityEngine;
using UnityEngine.UI;

public class Castle : MonoBehaviour {

	[Header("Castle Health Attributes")]
	public int healthCastle1 = 20;
	public int healthCastle2 = 20;
	public int healthCastle3 = 20;

	public GameObject castleDebris1;
	public GameObject castle1;

	public GameObject castleDebris2;
	public GameObject castle2;

	public GameObject castleDebris3;
	public GameObject castle3;


	public Text healthCastle1Text;
	public Text healthCastle2Text;
	public Text healthCastle3Text;

	public bool gameOver = false;
	public GameObject gameOverPanel;
	public Text endGameText;
	public Text waveText;
	Spawner spawner;
	public Text restartText;

	void Start(){

		spawner = GetComponent<Spawner>();
	}


	void Update(){

		healthCastle1Text.text = healthCastle1.ToString();
		healthCastle2Text.text = healthCastle2.ToString();
		healthCastle3Text.text = healthCastle3.ToString();

		if(healthCastle1 <= 0 || healthCastle2 <= 0 || healthCastle3 <= 0){
			healthCastle1 = 0;
			healthCastle2 = 0;
			healthCastle3 = 0;
		}

		if(healthCastle1 <= 0){
			gameOver = true;
			castleDebris1.SetActive(true);
			castle1.SetActive(false);
		}

		if(healthCastle2 <= 0){
			gameOver = true;
			castleDebris2.SetActive(true);
			castle2.SetActive(false);
		}

		if(healthCastle3 <= 0){
			gameOver = true;
			castleDebris3.SetActive(true);
			castle3.SetActive(false);
		}

		if(gameOver == true){
			gameOverPanel.SetActive(true);
			waveText.text = spawner.waveNumber.ToString();
			if(spawner.waveNumber <= 1){
				endGameText.text = "YOU ARE EITHER A DRUNK, INCOMPETENT, SICK OR VERY OLD RULER... OR MAYBE ALL FOUR !";
			} else if(spawner.waveNumber > 1 && spawner.waveNumber < 5){
				endGameText.text = "YOU LET YOUR PEOPLE DIE, WITHOUT PUTTING UP MUCH OF A FIGHT...";
			} else if(spawner.waveNumber >= 5 && spawner.waveNumber <= 10){
				endGameText.text = "YOU WERE BRAVE AND STRONG, A SHAME IT DID NOT LAST...";
			} else if(spawner.waveNumber > 10){
				endGameText.text = "YOU ARE A REAL DEFENDER, POWER RUNS THROUGH YOUR VEINS !";
			}

		}
	}

}
