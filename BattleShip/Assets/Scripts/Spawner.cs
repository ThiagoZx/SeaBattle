using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Spawner : MonoBehaviour {

	[Header("Prefab")]
	public Button button;
	public GameObject Holder_01;
	public GameObject Holder_02;

	[Header("Player 1 Grid Position")]
	public float gridPosition_1_x;
	public float gridPosition_1_y;
	public int gridSize_1;
	
	[Header("Player 2 Grid Position")]
	public float gridPosition_2_x;
	public float gridPosition_2_y;
	public int gridSize_2;


	void Start () {
		StartCoroutine(spawnGrid (gridPosition_1_x, gridPosition_1_y, gridSize_1, 1, Holder_01));
		StartCoroutine(spawnGrid (gridPosition_2_x, gridPosition_2_y, -gridSize_2, 2, Holder_02));
	}

	private IEnumerator spawnGrid(float position_x, float position_y, int size, int player, GameObject holder){
		for(int i = 5; i > 0; i--){	
			for(int j = 5; j > 0; j--){
				Button btn;
				btn = Instantiate(button, new Vector3(position_x + j * size, position_y - i * size, 0), Quaternion.identity) as Button;
				btn.transform.SetParent(holder.transform, false);
				btn.name = player == 2 ? btn.name = "Grid_0" + player + "_ID:" + (5 - i) + "_" + (5 - j) : btn.name = "YourGrid_" + (5 - i) + "_" + (5 - j);
				yield return new WaitForSeconds(0.1f);
			}
		}
	}
}
