using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Spawner : MonoBehaviour {

	public Button button;

	void Start () {
		for(int i = 0; i < 5; i++){	
			for(int j = 0; j < 5; j++){
				Instantiate(button, new Vector3(-300 + i * 30, 100 + j * 30, 0), Quaternion.identity);
			}
		}
	}

}
