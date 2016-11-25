using UnityEngine;
using System.Collections;

public class ClientController : MonoBehaviour {

	public string Message;

	// Use this for initialization
	void Start () {
	
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
}
