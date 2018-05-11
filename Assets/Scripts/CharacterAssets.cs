using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework.Internal;
using UnityEngine.Analytics;

public class CharacterAssets : MonoBehaviour {


	public GameObject[] characterMesh;
	public GameObject[] helmetMesh;
	public GameObject[] chestArmorMesh;
	public GameObject[] lShoulderArmorMesh;
	public GameObject[] rShoulderArmorMesh;
	public GameObject[] lArmArmorMesh;
	public GameObject[] rArmArmorMesh;
	public GameObject[] lKneeArmorMesh;
	public GameObject[] rKneeArmorMesh;
	public GameObject[] beltArmorMesh;
	public GameObject[] lHipArmorMesh;
	public GameObject[] rHipArmorMesh;

	public GameObject[] lHandWeaponMesh;
	public GameObject[] rHandWeaponMesh;

	public Material[] chestMaterial;
	public Material[] headMaterial;

	void Awake(){
		DontDestroyOnLoad(this);
	}
}
