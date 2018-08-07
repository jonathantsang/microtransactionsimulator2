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

	string[] quotes = { "Becoming a lemonade stand tycoon", "Learning frame data", "Shooting 7/44 from the field", "Blowing a 3-1 lead",
	"Making a cheap survival game and publishing it", "Installing crypto miner", "Hacking the world", "Making waffles", "Not asking for this", 
	"Catching a ride", "Being met with a terrible fate", "Changing up war", "Making my choices in the end", "Playing pachinko", "Studying python",
	"Opening digital currency", "Subverting gambling laws", "Artificially raising buds", "Finding princess in castle",
	"Remembering no Russian", "...", "Defending Burger Town", "FUS RO DAH", "Changing war", "Enduring and surviving", "Taking an arrow to the knee",
	"Darude Sandstorming", "Gambling virtual skins", "Not getting interviewed by $A", "California Dreamin'", "Coding in C#"
	};

	static int loadingBarMaxLength = 1600;
	static int loadingBarHeight = 40;

	float changeTime = 0.5f;
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

		// Loading bar on the bottom
		loadingBar = loadingScreen.transform.GetChild (3).GetChild (0).gameObject;

		// Turn off the start
		// DEMO
		loadingScreen.SetActive (false);
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

				int rand = Random.Range (0, quotes.Length);

				bottomText1.text = quotes [rand];
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
		// public method link
		publicMethodLink();

		// Roll for random quote

		loadingScreen.SetActive (true);
	}

	public void turnOffLoadingScreen(){
		current = 0;
		dotTime = 0;
		loadingScreen.SetActive(false);
	}

	void publicMethodLink(){
		if (loadingScreen == null) {
			loadingScreen = GameObject.FindGameObjectWithTag ("LoadingScreen").gameObject;
		}

		loadingText = loadingScreen.transform.GetChild (1).GetComponent<Text> ();

		// Prep bottom text
		bottomText1 = loadingScreen.transform.GetChild (2).GetChild (0).GetComponent<Text> ();

		// Loading bar on the bottom
		loadingBar = loadingScreen.transform.GetChild (3).GetChild (0).gameObject;
	}
}
