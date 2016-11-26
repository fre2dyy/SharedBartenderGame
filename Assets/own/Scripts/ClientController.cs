using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ClientController : MonoBehaviour {

	public string Message;
	public string Request;

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
	void GetDrink(Transform mixedDrink) {
		// Check if Ingredients from DrinkController match Ingredients of requested Drink
		Drink targetDrink = new Drink(this.Request);
		foreach(var item in targetDrink.Ingredients) {
			Debug.Log (item.Key);
		}
		Debug.Log ("Got a Drink");
		Debug.Log (mixedDrink.GetComponent);
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
