using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BF_RNGController : MonoBehaviour {

	// indicies of rolling for BF
	int low = 1;
	int high = 26; // First 25 items

	public int getRandom(){
		int index = Random.Range (low, high - 1);
		return index;
	}
}
