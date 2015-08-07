using UnityEngine;
using System.Collections;

public class Aumentar : MonoBehaviour {
	public UnityEngine.UI.Text gpc;
	public UnityEngine.UI.Text Money;
	public float gold = 0;
	public int goldperclick = 1;

	void Update(){
		Money.text = "Gold: " + CurrencyConverter.Instance.GetCurrencyIntoString(gold,false,false);
		gpc.text = CurrencyConverter.Instance.GetCurrencyIntoString(goldperclick,false,true) + "Gold/click";
	}
	public void Cliked(){
		gold += goldperclick; 
	}
}