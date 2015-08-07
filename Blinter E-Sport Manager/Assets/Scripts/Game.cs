using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// Made by 1MachoKualquiera
// Last update 12/7/15 

public class Game : MonoBehaviour {
	public GameObject screen;
    public bool Gender;
    public bool GenderSelected;
	public float dampTime = 0.15f;
	private Vector3 speed = Vector3.zero;
    public int page; 
	public Vector3 target;
    public Image Male;
    public Image Female;
    public Color Marked;
    public Color Dismarked;
    public Button GenderNext;
    public InputField NameBox;
    public InputField SurnameBox;
    public string Name;
    public string Surname;
    public Button NameNext;
    public bool NameandSurname;
    public Text SaveFoundText;
    public int Money;

	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () 
	{
        smoothDamp();
        RecalculatePage();
        checkNameFields();
	}

	public void introacceptbutton ()
	{
        PlayerPrefs.SetString("AcceptedTerms", "True");
        page = 1;
        if (PlayerPrefs.HasKey("Name"))
        {
            page = -1;
            SaveFoundText.text = "¡Parece que ya tienes una partida guardada!\nNombre: " + Name + Surname + "\nCréditos: " + Money;
        }
	}
	public void saraintrobutton ()
	{
        page = 2;
	}
	public void male ()
	{
        Gender = true;
        GenderSelected = true;
        GenderOperations();
	}
	public void female ()
	{
        Gender = false;
        GenderSelected = true;
        GenderOperations();
	}
	public void sexselectionscreenforward ()
	{
        page = 3;
	}
	public void namebackward ()
	{
        page = 2;
	}
    public void checkNameFields ()
    {
        if (page == 3)
        {
            NameandSurname = NameBox.text == "" && SurnameBox.text == "";
            if (!NameandSurname)
            {
                NameNext.interactable = true;
            }
        }
    }
	public void nameforward ()
	{
        Name = NameBox.text;
        Surname = SurnameBox.text;
        page = 4;
        PlayerPrefs.SetString("Name", Name);
        PlayerPrefs.SetString("Surname", Surname);
    }

    public void GenderOperations ()
    {
        if (Gender)
        {
            Male.color = Marked;
            Female.color = Dismarked;
            PlayerPrefs.SetInt("Gender", 1);
        }
        else
        {
            Female.color = Marked;
            Male.color = Dismarked;
            PlayerPrefs.SetInt("Gender", 0);
        }
        if (GenderSelected)
        {
            GenderNext.interactable = true;
        }
    }

	public void smoothDamp ()
	{
        Vector3 destination = new Vector3(-target.x + 473.9999f, -target.y + 266.5003f);
        transform.position = Vector3.SmoothDamp(transform.position, destination, ref speed, dampTime);
    }

    public Vector3 IndexToCoords (int index)
    {
        return new Vector3(index * 956, 0);
    }
    public void RecalculatePage ()
    {
        target = IndexToCoords(page);
    }
    public void AlreadyHasSaved ()
    {
        
    }
}
