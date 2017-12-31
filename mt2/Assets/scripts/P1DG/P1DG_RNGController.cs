using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1DG_RNGController : MonoBehaviour {

	// indicies of rolling for BF
	int low = 30;
	int high = 51; // First 30-50

	public int getRandom(){
		int index = Random.Range (low, high - 1);
		return index;
	}
}
