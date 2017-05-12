using UnityEngine;

public class DestroyCharacter : MonoBehaviour {

	public GameMaster gm;

	public void Destroy(){

		if(gm.isTimeToBuild == true){
			return;
		} 

		gm.isTimeToDestroy = true;
		
	}
}
