using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ClientController : MonoBehaviour {

	public string Message;
	public string Request;
	private string name;
	public bool RequestMatch;
	public UiController Ui;

	// Use this for initialization
	void Start () {
		this.name = this.gameObject.name;
		Ui = GameObject.FindGameObjectWithTag("UI").GetComponent<UiController>();
		Invoke ("GenerateRequest", 1);
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
		if (this.RequestMatch) {
			Ui.ReceiveMoney (10);
			Ui.ReceiveChat(this.name + ": Thank you, sir! :)\n");
			GenerateRequest ();
		} else {
			Ui.ReceiveChat(this.name + ": That was not what I've ordered! :(\n");
		}
	}

	void GenerateRequest() {
		// TODO: Perfomance Issue!
		string[] drinkList = Drink.GetDrinkList ();
		this.Request =  drinkList[Random.Range(0, drinkList.Length)];
		Ui.ReceiveChat (this.name + ": I would like to have a " + this.Request + "\n");
	}

	void AssessSatisfaction() {
	}
}
