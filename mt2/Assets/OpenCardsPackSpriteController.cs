using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenCardsPackSpriteController : MonoBehaviour {

	public Sprite pack1;
	public Sprite pack2;
	public Sprite pack3;
	public Sprite pack4;
	public Sprite pack5;
	public Sprite pack6;

	int idx = 0;
	Sprite[] sprites = new Sprite[6];

	Image packImage;

	// Use this for initialization
	void Start () {
		publicMethodLink ();

		// Init sprites
		sprites[0] = pack1;
		sprites[1] = pack2;
		sprites[2] = pack3;
		sprites[3] = pack4;
		sprites[4] = pack5;
		sprites[5] = pack6;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void incrementPack(){
		publicMethodLink ();

		idx++;
		idx = Mathf.Min (idx, sprites.Length-1);
		packImage.sprite = sprites [idx];
	}

	public void decrementPack(){
		publicMethodLink ();

		idx--;
		idx = Mathf.Max (idx, 0);
		packImage.sprite = sprites [idx];
	}

	void publicMethodLink(){
		if (packImage == null) {
			packImage = GameObject.FindGameObjectWithTag ("PackInfo").transform.GetChild(1).GetComponent<Image> ();
		}
	}
}
