using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Spawner : MonoBehaviour {

	[Header("Prefab")]
	public Button button;

	[Header("Player 1 Grid Position")]
	public float gridPosition_1_x;
	public float gridPosition_1_y;
	public int gridSize_1;
	
	[Header("Player 2 Grid Position")]
	public float gridPosition_2_x;
	public float gridPosition_2_y;
	public int gridSize_2;

	void Start () {
		StartCoroutine(spawnGrid (gridPosition_1_x, gridPosition_1_y, gridSize_1));
		StartCoroutine(spawnGrid (gridPosition_2_x, gridPosition_2_y, -gridSize_2));
	}

	private IEnumerator spawnGrid(float position_x, float position_y, int size){
		for(int i = 0; i < 5; i++){	
			for(int j = 0; j < 5; j++){
				Button btn;
				btn = Instantiate(button, new Vector3(position_x + j * size, position_y - i * size, 0), Quaternion.identity) as Button;
				btn.transform.SetParent(transform, false);
				yield return new WaitForSeconds(0.1f);
			}
		}
	}
}
