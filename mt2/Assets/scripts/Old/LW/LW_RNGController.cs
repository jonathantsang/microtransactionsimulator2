﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LW_RNGController : MonoBehaviour {

	// indicies of rolling for BF
	int low = 15;
	int high = 41; // 26-50 TODO temp

	public int getRandom(){
		int index = Random.Range (low, high - 1);
		return index;
	}
}
