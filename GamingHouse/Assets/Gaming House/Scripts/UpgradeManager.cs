using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UpgradeManager : MonoBehaviour {
	public Aumentar click;
	public UnityEngine.UI.Text itemInfo;
	public float cost;
	public int count = 0;
	public int clickPower;
	public string itemName;
	public Color standard;
	public Color disponible;
	private float baseCost;

	void Start (){
		baseCost = cost;
	}

	void Update(){
		itemInfo.text = itemName + "\nCost: " + cost + "\nPower: +" + clickPower;
		if (click.gold >= cost) {
			GetComponent<Image> ().color = disponible;
		} else {
			GetComponent<Image> ().color = standard;
		}
	}

	public void PurchasedUpgrade(){
		if (click.gold >= cost){
			click.gold -= cost;
			count += 1;
			click.goldperclick += clickPower;
			cost = Mathf.Round (baseCost * Mathf.Pow(1.15f, count));
			}
		}
}