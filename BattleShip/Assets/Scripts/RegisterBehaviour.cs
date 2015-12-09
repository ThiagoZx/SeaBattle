using UnityEngine;
using UnityEditor;
using System.Net;
using System.Collections;
using UnityEngine.UI;

public class RegisterBehaviour: MonoBehaviour {
	
	private string username;
	private string password;

	public GameObject username_Input;
	public GameObject password_Input;

	private string db_url = "http://sixteen.hol.es/phpFiles/";

	public GameObject loading;

	void Update(){
		username = username_Input.GetComponent<Text> ().text;
		password = password_Input.GetComponent<Text> ().text;
	}

	public void db_start() {

		if (username != "" && password != "") {
			db_url = "http://sixteen.hol.es/phpFiles/";
			StartCoroutine (Register ());
		} else {
			EditorUtility.DisplayDialog("Erro ao se registrar!", "Favor preencher todos os campos corretamente!", "Ok!");
		}
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
		Instantiate (loading);
		if (CheckConnection(db_url + "Register.php")) {
			WWWForm form = new WWWForm ();
			form.AddField ("username", username);
			form.AddField ("password", password);
			WWW webRequest = new WWW (db_url + "Register.php", form);
			yield return webRequest;
			if(webRequest.text == "user taken"){
				EditorUtility.DisplayDialog("Registro incompleto!", "Nome de usuario ja esta sendo utilizado. Favor escolha outro para continuar.", "Ok");
			} else {
				EditorUtility.DisplayDialog("Registro completo!", "Conta criada com sucesso! Favor fazer login para continuar!", "Ok");
			}
		} else {
			EditorUtility.DisplayDialog("Problemas de rede!", "Impossivel se conectar com o banco de dados. Verifique sua rede de internet ou tente novamente mais tarde!", "Ok");
			yield return Register();
		}
		Destroy(GameObject.FindWithTag("Loading"));
	}

	// Yes, I realise that I could put everything in only 2 scripts (1 .cs and 1 .php), but it's my first time on php so let's take it easy, shall we? - Zx
}