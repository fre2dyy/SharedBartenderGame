using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ClientController : MonoBehaviour {

	public string Message;
	public string Request;
	public bool RequestMatch;

	// Use this for initialization
	void Start () {
		GenerateRequest ();		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/*
	 * Will be called when Barkeeper gives a Drink to the client
	 */
	void GetDrink(Dictionary<string, int> receivedDrink) {
		this.RequestMatch = false;
		Drink targetDrink = new Drink(this.Request);
		// Check if Ingredients from DrinkController match Ingredients of requested Drink
		foreach(var item in targetDrink.Ingredients) {
			int amount;
			if (receivedDrink.TryGetValue (item.Key, out amount)) {
				this.RequestMatch = true;
			} else {
				this.RequestMatch = false;
				break;
			}
		}
		Debug.Log ("Got a Drink");
		if (this.RequestMatch)
			Debug.Log ("Thank you! :)");
		else
			Debug.Log ("That was not what I've ordered! :(");
	}

	void GenerateRequest() {
		// TODO: Perfomance Issue!
		string[] drinkList = Drink.GetDrinkList ();
		this.Request =  drinkList[Random.Range(0, drinkList.Length)];
		Debug.Log (this.Request);
	}

	void AssessSatisfaction() {
	}
}
