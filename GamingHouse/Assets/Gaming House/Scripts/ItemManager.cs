using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ItemManager : MonoBehaviour {
	public UnityEngine.UI.Text itemInfo;
	public Aumentar click;
	public float cost;
	public int tickValue;
	public int count;
	public string itemName;
	public Color standard;
	public Color disponible;
	private float baseCost;

	void Start (){
		baseCost = cost;
	}

	void Update (){
		itemInfo.text = itemName + "\nLv:" +count + "\nCoast: " + cost + "\nGold: " + tickValue + "/s";
		if (click.gold >= cost) {
			GetComponent<Image> ().color = disponible;
		} else {
			GetComponent<Image> ().color = standard;
		}
	}

	public void PurchasedItem(){
		if (click.gold >= cost) {
			click.gold -= cost;
			count += 1;
			cost = Mathf.Round(baseCost * Mathf.Pow(1.15f, count));
		}
	}
}