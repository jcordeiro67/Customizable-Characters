using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemName : MonoBehaviour {

	public string itemName;

	void Start(){
		SetItemTag ();
	}

	void SetItemTag(){

		transform.name = itemName;
	}
}
