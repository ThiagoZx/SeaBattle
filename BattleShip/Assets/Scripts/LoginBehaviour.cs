using UnityEngine;
using UnityEditor;
using System.Net;
using System.Collections;
using UnityEngine.UI;

public class LoginBehaviour: MonoBehaviour {
	
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
		
		if (username != "" && password != "") {
			db_url = "http://sixteen.hol.es/phpFiles/";
			StartCoroutine (Login ());
		} else {
			EditorUtility.DisplayDialog("Erro ao se conectar!", "Favor preencher todos os campos corretamente!", "Ok!");
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
	
	public IEnumerator Login() {

		if (CheckConnection(db_url + "Login.php")) {
			WWWForm form = new WWWForm ();
			form.AddField ("username", username);
			form.AddField ("password", password);
			WWW webRequest = new WWW (db_url + "Login.php", form);
			yield return webRequest;
			if(webRequest.text == "wrong"){
				EditorUtility.DisplayDialog("Campos errados", "Nome de usuario nao coinscide com com a senha. Usuario inexistente ou senha incorreta.", "Ok");
			} else {
				//Application.LoadLevel();
				EditorUtility.DisplayDialog("Sucesso", "Login autenticado com sucesso, prosseguindo para a pagina principal", "Show.");
			}

			print(webRequest.text);

		} else {
			EditorUtility.DisplayDialog("Problemas de rede!", "Impossivel se conectar com o banco de dados. Verifique sua rede de internet ou tente novamente mais tarde!", "Ok");
			yield return Login();
		}
	}

	// Yes, I realise that I could put everything in only 2 scripts (1 .cs and 1 .php), but it's my first time on php so let's take it easy, shall we? - Zx
}