using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingScreenController : MonoBehaviour {

	// Objects
	GameObject loadingScreen;
	Text loadingText;
	Text bottomText1;
	Text bottomText2;
	Text bottomText3;
	GameObject loadingBar;

	// Consts
	static string LOADING = "Loading";
	static string BT1 = "Opening digital currency";
	static string BT2 = "Subverting gambling laws";
	static string BT3 = "Artificially raising buds";
	static int loadingBarMaxLength = 1600;
	static int loadingBarHeight = 40;

	float changeTime = 0.3f;
	float loadBarTime = 3f;

	int dotCount = 0;

	float dotTime = 0; // time to rotate dots.
	float current = 0; // total time elapsed


	// Use this for initialization
	void Start () {
		loadingScreen = GameObject.FindGameObjectWithTag ("LoadingScreen").gameObject;
		loadingText = loadingScreen.transform.GetChild (1).GetComponent<Text> ();

		// Prep bottom text
		bottomText1 = loadingScreen.transform.GetChild (2).GetChild (0).GetComponent<Text> ();
		bottomText2 = loadingScreen.transform.GetChild (2).GetChild (1).GetComponent<Text> ();
		bottomText3 = loadingScreen.transform.GetChild (2).GetChild (2).GetComponent<Text> ();

		// Loading bar on the bottom
		loadingBar = loadingScreen.transform.GetChild (3).GetChild (0).gameObject;

		// Turn off the start
		// DEMO
		// loadingScreen.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (loadingScreen.activeInHierarchy) {
			current += Time.deltaTime;
			dotTime += Time.deltaTime;

			if (dotTime > changeTime) {
				dotTime = 0;
				dotCount = (dotCount + 1) % 4;

				// Change the loadingText and bottomText1,2,3
				string dots = new string('.', dotCount);

				loadingText.text = LOADING + dots;
				bottomText1.text = BT1 + dots;
				bottomText2.text = BT2 + dots;
				bottomText3.text = BT3 + dots;

			}

			if (current > loadBarTime) {
				// End the screen
				turnOffLoadingScreen();
			}

			// Update the loading bar
			loadingBar.GetComponent<RectTransform>().sizeDelta = 
				new Vector2(loadingBarMaxLength / loadBarTime * current, loadingBarHeight);
		}
	}

	public void turnOnLoadingScreen(){
		loadingScreen.SetActive (true);

		// ... for Loading (index 1)


		// ... for the bottomText words (index 2, index i++)

		// Loading bar loads slowly for 3 second
	}

	public void turnOffLoadingScreen(){
		current = 0;
		dotTime = 0;
		loadingScreen.SetActive(false);
	}
}
