using UnityEngine;
using System.Net;
using System.Collections;
using UnityEngine.UI;

public class RegisterBehaviour: MonoBehaviour {

	public int userID = 1;
	private string username;
	private string password;

	public GameObject username_Input;
	public GameObject password_Input;

	private string db_url = "http://sixteen.hol.es/phpFiles/";

	void Update(){
		username = username_Input.GetComponent<Text> ().text;
		password = password_Input.GetComponent<Text> ().text;
	}

	public void db_start() {

		db_url = "http://sixteen.hol.es/phpFiles/";
		StartCoroutine (Register());

	}
	
	bool CheckConnection(string URL)
	{
		try {
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
			request.Timeout = 5000;
			request.Credentials = CredentialCache.DefaultNetworkCredentials;
			HttpWebResponse response = (HttpWebResponse)request.GetResponse();
			if (response.StatusCode == HttpStatusCode.OK) {return true;} 
			return false;

		} catch {
			return false;
		}
	}
	
	public IEnumerator Register() {
		if (CheckConnection(db_url + "Register.php")) {
			WWWForm form = new WWWForm ();
			form.AddField ("userID", userID);
			form.AddField ("username", username);
			form.AddField ("password", password);
			WWW webRequest = new WWW (db_url + "Register.php", form);
			yield return webRequest;
			print(webRequest.text);
		} else {
			yield return Register();
		}
	}
}