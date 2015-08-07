using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Login : MonoBehaviour {
    public InputField Usernamef;
    public InputField Passwordf;
    private string Username;
    private string Password;
    public WWW Server;
    public Text Logtext;
    public string Output;
    public Image loadingContainer;
    public Color Incorrect;
    public Color Loading;
    public Toggle Remember;
    public Toggle Autologin;
    // Use this for initialization
	void Start () {
        if(PlayerPrefs.HasKey("Remember"))
        {
            if (PlayerPrefs.GetInt("Remember") == 1)
            {
                Usernamef.text = PlayerPrefs.GetString("Username");
                Passwordf.text = PlayerPrefs.GetString("Password");
                Remember.isOn = true;
            }
        }
        if (PlayerPrefs.HasKey("Autologin"))
        { 
            if (PlayerPrefs.GetInt("Autologin") == 1)
            {
                Autologin.isOn = true;
                RunInput();
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
	    if (Remember.isOn)
        {
            Autologin.interactable = true;
        }
        else
        {
            Autologin.interactable = false;
            Autologin.isOn = false;
        }
	}
    public void RunInput ()
    {
        StartCoroutine("InputData");
    }
    public IEnumerator InputData ()
    {
        Username = Usernamef.text;
        Password = Passwordf.text;
        Logtext.color = Loading;
        Logtext.text = "Cargando...";
        loadingContainer.enabled = true;
        Server = new WWW("http://blinteruniverse.com/Alpha/BlinterManagerTeamLogin.php?login=" + Username +"&password=" + Password);
        yield return Server;
        loadingContainer.enabled = false;
        Logtext.text = "";
        Logtext.color = Incorrect;
        Output = Server.text;
        CheckData();
        if (Remember.isOn)
        {
            PlayerPrefs.SetInt("Remember", 1);
            PlayerPrefs.SetString("Username", Username);
            PlayerPrefs.SetString("Password", Password);
        }
        else
        {
            PlayerPrefs.SetInt("Remeber", 0);
            PlayerPrefs.DeleteKey("Username");
            PlayerPrefs.DeleteKey("Password");
        }
        if (Autologin.isOn)
        {
            PlayerPrefs.SetInt("Autologin", 1);
        }
        else
        {
            PlayerPrefs.SetInt("Autologin", 0);
        }
    }
    public void CheckData()
    {
        if (Output == "1")
        {
            Logtext.text = "";
            Application.LoadLevel("Expo");
        }
        else
        {
            Logtext.text = "Tu nombre de usuario o contraseña no son correctos";
        }
    }
    public void ForgotPassword ()
    {
        Application.OpenURL("http://blinteruniverse.com/Alpha/my-account/lost-password/");
    }
    public void Register ()
    {
        Application.OpenURL("http://blinteruniverse.com/Alpha/registro/");
    }
    public void Facebook ()
    {
        Application.OpenURL("https://www.facebook.com/ViElectronicEntertainment");
    }
    public void Twitter ()
    {
        Application.OpenURL("https://twitter.com/BlinterUniverse");
    }
    public void Instagram ()
    {
        Application.OpenURL("https://instagram.com/velozasergio/");
    }
}
