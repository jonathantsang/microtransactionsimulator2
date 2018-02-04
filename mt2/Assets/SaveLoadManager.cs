using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveLoadManager {

	public static void SaveData(int i){
		BinaryFormatter bf = new BinaryFormatter();
		FileStream stream = new FileStream (Application.persistentDataPath + "/data.sav", FileMode.Create);

		SaveData data = new SaveData (i);
		bf.Serialize (stream, data);
		stream.Close ();
	}

	public static SaveData LoadData(){
		if (File.Exists (Application.persistentDataPath + "/data.sav")) {
			Debug.Log ("loaded");
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream stream = new FileStream (Application.persistentDataPath + "/data.sav", FileMode.Open);

			SaveData data = bf.Deserialize (stream) as SaveData;

			stream.Close ();
			return data;
		} else {
			Debug.Log ("create new");
			Debug.LogError ("File does not exist");
			return new global::SaveData (0);
		}
	}
}

[System.Serializable]
public class SaveData {

	public int NumberOpened = 0; // How many crates opened
	public int Currency = 10; // How much currency they have
	public int OpenCount = 1; // How many to open at once

	public int[] Inventory;
	public int[] Collected;
	public int[] RecipesUnlocked;
	public int[] Stats;
	public int[] ShopUnlocked;

	public SaveData(int currency){
		Inventory = new int[50];
		Collected = new int[50];
		RecipesUnlocked = new int[50];
		Stats = new int[50];
		NumberOpened = 0;
		Debug.Log (currency + " is currency");
		Currency = currency;
		OpenCount = 0;
	}
}