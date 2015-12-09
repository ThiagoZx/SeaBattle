using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PlaceShipBehaviourScript : MonoBehaviour {
	
	private Vector2 lastDif;
	private string direction;
	private bool isMoving;
	private bool placed;
	private List<string> positions = new List<string>();
	public GameObject Holder;
	public Quaternion rotation = Quaternion.identity;
	public GameObject quantity;
	public Camera mainCamera;
	public int troop;

	private void fillPositions(){
		for (int i = 0; i < Holder.transform.childCount; i++) {
			GameObject btn = GameObject.Find("" + (i / 5) + "_" + (i % 5) +  "");
			string position = (btn.transform.position.x) + ":" + (btn.transform.position.y) + ": _" + (i / 5) + "_" + (i % 5);
			print(position);
			positions.Add(position);
		}
	}

	private int getDiference(){
		Vector2 dif = mainCamera.ScreenToWorldPoint(Input.mousePosition);
		if(Mathf.Abs(dif.x - lastDif.x) > Mathf.Abs(dif.y - lastDif.y)){
			lastDif = dif;
			return 1;
		} else if(Mathf.Abs(dif.x - lastDif.x) < Mathf.Abs(dif.y - lastDif.y)) {
			lastDif = dif;
			return 0;
		} else {
			return -1;
		}
	}

	private void adjustDir(){
		int dir = getDiference ();
		if (dir == 1) {
			rotation.eulerAngles = new Vector3 (0, 0, 0);
		} else if (dir == 0) {
			rotation.eulerAngles = new Vector3 (0, 0, 90);
		}
	}

	private void adaptToGrid(int shpNmbr){
		if (shpNmbr == 2) {
		//Do stuff
		//if correctly alligned, placed = true
		} else if (shpNmbr == 3) {
		//Do more stuff
		//if correctly alligned, placed = true
		}
	}

	private void followCursor(){
		adaptToGrid (troop);
		Vector3 pos = new Vector3 (mainCamera.ScreenToWorldPoint (Input.mousePosition).x, mainCamera.ScreenToWorldPoint (Input.mousePosition).y, 0);
		gameObject.transform.position = pos;
	}

	public void click(){
		if (isMoving){
			isMoving = false;
		} else {
			isMoving = true;
		}
	}

	void Start () {
		isMoving = false;
		placed = false;
		mainCamera = Camera.main;
		fillPositions ();
		lastDif = mainCamera.ScreenToWorldPoint(Input.mousePosition);
	}
	
	void Update () {
		if (isMoving) {
			followCursor();
			adjustDir();
			quantity.GetComponent<Text>().text = "x0";
		}

		gameObject.transform.rotation = rotation;

	}
}
