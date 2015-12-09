using UnityEngine;
using System.Collections;

public class LoadingBehaviour : MonoBehaviour {

	public float time;
	public GameObject obj;
	public GameObject holder;

	void Start () {
		StartCoroutine (LaunchAnimation());
	}

	//Actually, now I realise that I could have used a sort of delay on the animation itself, no need for this for loop.
	//																									"for this for"    -Zx

	IEnumerator LaunchAnimation(){
		for(int i = 0; i < 3; i++){
			yield return new WaitForSeconds (time);
			obj = Instantiate(obj, new Vector3(-0.6f + 0.3f * i,0,0), Quaternion.identity) as GameObject;
			obj.transform.SetParent(holder.transform, false);
		}
	}
}
