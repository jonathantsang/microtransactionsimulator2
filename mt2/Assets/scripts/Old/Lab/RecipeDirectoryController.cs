using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeDirectoryController : MonoBehaviour {

	public Sprite onetwosix, onetwoseven, onetwoeight, onetwonine, onethreezero, onethreeone, onethreetwo, onethreethree, onethreefour, onethreefive;
	public Sprite onethreesix, onethreeseven, onethreeeight, onethreenine, onefourzero, onefourone, onefourtwo, onefourthree, onefourfour, onefourfive;
	public Sprite onefoursix, onefourseven, onefoureight, onefournine, onefivezero, onefiveone, onefivetwo, onefivethree;
	List<Recipe> Recipes;
	List<Sprite> Sprites;

	// Use this for initialization
	void Start () {
		Recipes = new List<Recipe> () {
			new Recipe(126,15,15,"Big Smoke order"),
			new Recipe(127,10,18,"War, war never changes"),
			new Recipe(128,4,4,"deBono"),
			new Recipe(129,19,20,"Normiecash"),
			new Recipe(130,49,18,"Patrolling the mojave makes you wish for a"),
			new Recipe(131,9,10,"Bad consumer practices"),
			new Recipe(132,21,12, "Major leagues"),
			new Recipe(133,27,5, "Man's not hot"),
			new Recipe(134,12,23, "All chips on the table"),
			new Recipe(135,24,25, "Value combo"),
			new Recipe(136,24,14, "Health value combo"),
			new Recipe(137,26,16, "Watch flicks and chill"),
			new Recipe(138,32,33, "Quater-Lambda 3"),
			new Recipe(139,34,35, "Harambe"),
			new Recipe(140,40,41, "Classy"),
			new Recipe(141,38,6, "Burning ants"),
			new Recipe(142,36,36, "You feel lucky punk"),
			new Recipe(143,37,32, "A TF2 classic"),
			new Recipe(144,1,33, "That's one way to open it"),
			new Recipe(145,8,2, "Inflation"),
			new Recipe(146,13,47, "iJobs"),
			new Recipe(147,21,12, "Backstab"),
			new Recipe(148,46,7, "Frontal Battle 2"),
			new Recipe(149,36,46, "Missingno"),
			new Recipe(150,37,17, "Tailer Tinker"),
			new Recipe(151,39,32, "Aquaman"),
			new Recipe(152,18,47, "Doomsday"),
			new Recipe(153,6,16, "Avatar...not the blue ones"),
		};
		Sprites = new List<Sprite> () {
			onetwosix, onetwoseven, onetwoeight, onetwonine, onethreezero, onethreeone, onethreetwo, onethreethree, onethreefour, onethreefive,
			onethreesix, onethreeseven, onethreeeight, onethreenine, onefourzero, onefourone, onefourtwo, onefourthree, onefourfour, onefourfive,
			onefoursix, onefourseven, onefoureight, onefournine, onefivezero, onefiveone, onefivetwo, onefivethree
		};
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Checks if it is a recipe, and returns the id or -1 if it fails
	public int CheckRecipes(int i1, int i2){
		// Go through each recipe and check
		for(int i = 0; i < Recipes.Count; i++){
			if (Recipes [i].CheckRecipe (i1, i2)) {
				return i;
			}
		}
		return -1;
	}

	public Sprite getSprite(int i){
		// i is probably from CheckRecipes, so it is the normallized index value, not 126+
		return Sprites [i];
	}

	public string getRecipeName(int i){
		return Recipes [i].getName ();
	}
}
