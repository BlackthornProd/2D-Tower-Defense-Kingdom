using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneMaster : MonoBehaviour {

	public Text aboutText;
	public GameObject backButton;
	public Animator mainMenu;

	public GameObject ruleBook;

	[Header ("Sounds")]
	AudioSource audio;
	public AudioClip pop;

	void Start(){

		ruleBook.SetActive(false);
		audio = GetComponent<AudioSource>();
		aboutText.enabled = false;
		backButton.SetActive(false);

	}
	public void Play(){

		SceneManager.LoadScene("GameSave03");
	}

	public void About(){
		audio.clip = pop;
		audio.Play();
		mainMenu.Play("Hop Animation");
		StartCoroutine(GoToAbout());
	}

	public void Back(){
		audio.clip = pop;
		audio.Play();
		backButton.SetActive(false);
		aboutText.enabled = false;
		ruleBook.SetActive(false);
		mainMenu.Play("Back Hop Animation");
	}


	public void Rules(){
		audio.clip = pop;
		audio.Play();
		mainMenu.Play("Hop Animation");
		StartCoroutine(GoToRules());
	}

	IEnumerator GoToAbout(){
		yield return new WaitForSeconds(1f);
		aboutText.enabled = true;
		backButton.SetActive(true);
	}

	IEnumerator GoToRules(){

		yield return new WaitForSeconds(1f);
		ruleBook.SetActive(true);
		backButton.SetActive(true);
	}

}
