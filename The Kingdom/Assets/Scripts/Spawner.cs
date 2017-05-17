using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour {

	public GameObject[] enemiesLevel1;

	public Transform[] spawnPoints;

	public Text waveDisplay;

	Castle castle;

	[Header("Wave Attributes")]
	public int waveNumber = 1;
	public int waveLevel = 1;
	public float timeBtwWaves = 15f;

	[Header("Number of Enemies Attributes")]
	public int numberOfEnemies;
	public int maxNumOfEnemies = 25;
	public int startNumberOfEnemies = 5;
	public int numberOfEnemiesIncrease = 2;

	[Header("Time Btw Spawns Attributes")]
	public float timeBtwSpawns;
	public float maxTimeBtwSpawns = 1.25f;
	public float startTimeBtwSpawns = 5f;
	public float timeBtwSpawnsDecrease = 0.25f;



	void Start(){

		timeBtwSpawns = startTimeBtwSpawns;
		numberOfEnemies = startNumberOfEnemies;
		timeBtwWaves = 5f;
		castle = GetComponent<Castle>();
	}

	void Update(){

		
		waveDisplay.text = "WAVE : " + waveNumber;
		// Remember to increase the wave level with the WaveNumber variable right here !

		if(timeBtwWaves <= 0 && castle.gameOver == false){

			if(timeBtwSpawns <= 0 && numberOfEnemies > 0 && castle.gameOver == false){
				numberOfEnemies--;
				// Spawns a random level 1 enemy at a random location
				if(waveLevel == 1){
					int randomEnemyLevel1 = Random.Range(0, enemiesLevel1.Length);
					for (int i = 0; i < enemiesLevel1.Length; i++) {
						if(i == randomEnemyLevel1){
							int randomSpawnPoint = Random.Range(0, spawnPoints.Length);
							Instantiate(enemiesLevel1[i], spawnPoints[randomSpawnPoint].position, spawnPoints[randomSpawnPoint].rotation);
						}
					}
				timeBtwSpawns = startTimeBtwSpawns; // resets the time btw individual spawns.
				}	
			} else {
				timeBtwSpawns -= Time.deltaTime;
			}

			// Make sure the wave is over before starting a new wave.
			if(numberOfEnemies > 0){
				return;
			}

			// Reseting to a new wave and making this new wave harder !
			timeBtwWaves = 10f;
			waveNumber++;

			if(startNumberOfEnemies < maxNumOfEnemies){

				startNumberOfEnemies += numberOfEnemiesIncrease;
				numberOfEnemies = startNumberOfEnemies;

			} else {

				startNumberOfEnemies = maxNumOfEnemies;
				numberOfEnemies = startNumberOfEnemies;
			}

			if(startTimeBtwSpawns >  maxTimeBtwSpawns){
				startTimeBtwSpawns -= timeBtwSpawnsDecrease;
				timeBtwSpawns = startTimeBtwSpawns;
			}

		} else {
			timeBtwWaves -= Time.deltaTime;
		}


	}

	
}
