using UnityEngine;
using System.Collections;

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
	void GetDrink() {
		Debug.Log ("Got a Drink");
	}

	void GenerateRequest() {
		// TODO: Perfomance Issue!
		string[] drinkList = Drink.GetDrinkList ();
		this.Request =  drinkList[Random.Range(0, drinkList.Length)];
		Debug.Log (this.Request);
	}
}
