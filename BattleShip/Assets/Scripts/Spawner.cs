using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Spawner : MonoBehaviour {

	public Button button;
	public int size;

	void Start () {
		spawnGrid ();
	}

	private void spawnGrid(){
		for(int i = 0; i < 5; i++){	
			for(int j = 0; j < 5; j++){
				Button btn;
				btn = Instantiate(button, new Vector3(-300 + i * size, 50 - j * size, 0), Quaternion.identity) as Button;
				btn.transform.SetParent(transform, false);
			}
		}
	}
}
