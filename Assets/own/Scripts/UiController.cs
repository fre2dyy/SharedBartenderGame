using UnityEngine;
using System.Collections;

public class UiController : MonoBehaviour {

	GameObject CrosshairActive;
	GameObject CrosshairInactive;

	// Use this for initialization
	void Start () {
		CrosshairActive = GameObject.Find ("Crosshair active");
		CrosshairInactive = GameObject.Find ("Crosshair inactive");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/*
	 * Change Crosshair active/inactive
	 */
	void ToggleCrosshair() {
		if(CrosshairActive.activeSelf) {
			CrosshairActive.SetActive (false);
			CrosshairInactive.SetActive (true);
		} else {
			CrosshairActive.SetActive (true);
			CrosshairInactive.SetActive (false);
		}
	}

	/*
	 * Change Crosshair to active
	 */
	public void ActivateCrosshair() {
		CrosshairActive.SetActive (true);
		CrosshairInactive.SetActive (false);		
	}

	/*
	 * Change Crosshair to inactive
	 */
	public void DeactivateCrosshair() {
		CrosshairActive.SetActive (false);
		CrosshairInactive.SetActive (true);		
	}
}
