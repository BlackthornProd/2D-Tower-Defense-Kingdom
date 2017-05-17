using UnityEngine;

public class DestroyCharacter : MonoBehaviour {

	public GameMaster gm;

	void Update(){

		if(Input.GetKeyDown(KeyCode.D)){
			if(gm.isTimeToBuild == true){
				return;
			}

			gm.isTimeToDestroy = true;
		}
	}

	public void Destroy(){

		if(gm.isTimeToBuild == true){
			return;
		} 

		gm.isTimeToDestroy = true;
		
	}
}
