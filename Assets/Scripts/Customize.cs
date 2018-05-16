using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Customize : MonoBehaviour {

	#region Class Vriables
	public enum CharacterMeshMaterial{

		Chest,
		Arms,
		Pants,
		Boots,
		Hands,
		Head
	}

	public GameObject playerStart;

	// Character Mesh Variables
	private int _characterMeshIndex = 0;
	private string _charMeshName = "Warrior";

	// Armor mesh  Index variables
	private int _chestArmorIndex = 0;
	private int _lShoulderArmorIndex = 0;
	private int _rShoulderArmorIndex = 0;
	private int _helmetArmorIndex = 0;
	private int _lKneeArmorIndex = 0;
	private int _rKneeArmorIndex = 0;
	private int _beltArmorIndex = 0;
	private int _lHipArmorIndex = 0;
	private int _rHipArmorIndex = 0;
	private int _lArmArmorIndex = 0;
	private int _rArmArmorIndex = 0;

	private int _lHandWeaponIndex = 0;
	private int _rHandWeaponIndex = 0;

	// Material Index Variables
	private int _chestMaterialIndex = 0;
	private int _headMaterialIndex = 0;
	private string _headMaterialName = "Normal";

	// Script Pointer Variables
	private CharacterAssets ca;
	private PlayerCharacter pc;

	private bool isUpdated = false;

	// Variables used for Instantiate
	private GameObject chestArmorMesh;
	private GameObject shoulderArmorMesh;
	private GameObject helmetMesh;
	private GameObject lKneeMesh;
	private GameObject rKneeMesh;
	private GameObject beltArmorMesh;
	private GameObject lHipArmorMesh;
	private GameObject rHipArmorMesh;
	private GameObject lArmArmorMesh;
	private GameObject rArmArmorMesh;
	private GameObject lHandWeaponMesh;
	private GameObject rHandWeaponMesh;

	private GameObject armorMesh;
	private GameObject spawnPoint;

	#endregion
	// Use this for initialization
	void Start () {
		
		ca = GetComponent<CharacterAssets>();
		spawnPoint = Instantiate(playerStart, new Vector3 (0,0,0), Quaternion.identity) as GameObject;
		InstantiateCharacterMesh(_characterMeshIndex, ca.characterMesh);

		//pc = GameObject.FindObjectOfType<PlayerCharacter>();

		InstantiateChestArmorMesh();
		InstantiateLeftShoulderArmorMesh();
		InstantiateRightShoulderArmorMesh();
		InstantiateHelmetMesh();
		InstantiateLeftKneeMesh();
		InstantiateRightKneeMesh();
		InstantiateBeltArmorMesh();
		InstantiateLeftHipArmorMesh();
		InstantiateRightHipArmorMesh();
		InstantiateLeftArmArmorMesh();
		InstantiateRightArmArmorMesh();
		InstantiateLeftHandWeaponMesh();
		InstantiateRightHandWeaponMesh();
	}

	void Update(){
		
		if(isUpdated){
			UpdateCharacter();
		}
	}

	void OnGUI(){
		
		ChangeCharacterMesh();
		ChangeChestArmorMesh();
		ChangeLeftShoulderGuardMesh();
		ChangeRightShoulderGuardMesh();
		ChangeHelmetArmorMesh();
		ChangeLeftKneeArmorMesh();
		ChangeRightKneeArmorMesh();
		ChangeBeltArmorMesh();
		ChangeLeftArmArmorMesh();
		ChangeRightArmArmorMesh();
		ChangeLeftHandWeaponMesh();
		ChangeRightHandWeaponMesh();
		ChangeRightHipArmorMesh();
		ChangeLeftHipArmorMesh();

		ChangeHeadMaterial();

	}

	void UpdateCharacter(){

		pc = GameObject.FindObjectOfType<PlayerCharacter>();
		isUpdated = false;
	}

	////////////////////////////////////////////////////
	/// 	INSTANTIATE MESHES						///
	//////////////////////////////////////////////////

	#region Instantiate Meshes
	void InstantiateLeftShoulderArmorMesh(){

		if (_lShoulderArmorIndex > ca.lShoulderArmorMesh.Length - 1) {
			_lShoulderArmorIndex = 0;
		}

		if (pc.LF_ShoulderGuardNode.transform.childCount > 0) {
			for (int i = 0; i < pc.LF_ShoulderGuardNode.transform.childCount; i++) {
				Destroy(pc.LF_ShoulderGuardNode.transform.GetChild(i).gameObject);
			}
		}

		shoulderArmorMesh = Instantiate(ca.lShoulderArmorMesh[_lShoulderArmorIndex], pc.LF_ShoulderGuardNode.transform.position, 
			Quaternion.identity) as GameObject;
		shoulderArmorMesh.transform.parent = pc.LF_ShoulderGuardNode.transform;
		shoulderArmorMesh.transform.rotation = new Quaternion(0, 0, 0, 0);
		shoulderArmorMesh.transform.localScale = pc.LF_ShoulderGuardNode.transform.localScale;

		switch (_lShoulderArmorIndex) {

			case 1:
				_lShoulderArmorIndex = 1;

				break;

			default:
				_lShoulderArmorIndex = 0;
				break;
		}
	}

	void InstantiateRightShoulderArmorMesh(){

		if (_rShoulderArmorIndex > ca.rShoulderArmorMesh.Length - 1) {
			_rShoulderArmorIndex = 0;
		}

		if (pc.RT_ShoulderGuardNode.transform.childCount > 0) {
			for (int i = 0; i < pc.RT_ShoulderGuardNode.transform.childCount; i++) {
				Destroy(pc.RT_ShoulderGuardNode.transform.GetChild(i).gameObject);
			}
		}

		shoulderArmorMesh = Instantiate(ca.rShoulderArmorMesh[_rShoulderArmorIndex], pc.RT_ShoulderGuardNode.transform.position, 
			Quaternion.identity) as GameObject;
		shoulderArmorMesh.transform.parent = pc.RT_ShoulderGuardNode.transform;
		shoulderArmorMesh.transform.rotation = new Quaternion(0, 0, 0, 0);

		switch (_rShoulderArmorIndex) {

			case 1:
				_rShoulderArmorIndex = 1;
				break;

			default:
				_rShoulderArmorIndex = 0;
				break;
		}


	}

	void InstantiateLeftHandWeaponMesh(){

		if (_lHandWeaponIndex > ca.lHandWeaponMesh.Length - 1) {
			_lHandWeaponIndex = 0;
		}

		if (pc.LF_HandWeaponNode.transform.childCount > 0) {
			for (int i = 0; i < pc.LF_HandWeaponNode.transform.childCount; i++) {
				Destroy(pc.LF_HandWeaponNode.transform.GetChild(i).gameObject);
			}
		}

		lHandWeaponMesh = Instantiate(ca.lHandWeaponMesh[_lHandWeaponIndex], pc.LF_HandWeaponNode.transform.position, 
			Quaternion.identity) as GameObject;
		lHandWeaponMesh.transform.parent = pc.LF_HandWeaponNode.transform;
		lHandWeaponMesh.transform.rotation = new Quaternion(0, 0, 0, 0);
		lHandWeaponMesh.transform.localScale = pc.LF_HandWeaponNode.transform.localScale;

		switch (_lHandWeaponIndex) {

			case 1:
				_lHandWeaponIndex = 1;
				break;

			default:
				_lHandWeaponIndex = 0;
				break;
		}
	}

	void InstantiateRightHandWeaponMesh(){

		if (_rHandWeaponIndex > ca.rHandWeaponMesh.Length - 1) {
			_rHandWeaponIndex = 0;
		}

		if (pc.RT_HandWeaponNode.transform.childCount > 0) {
			for (int i = 0; i < pc.RT_HandWeaponNode.transform.childCount; i++) {
				Destroy(pc.RT_HandWeaponNode.transform.GetChild(i).gameObject);
			}
		}

		rHandWeaponMesh = Instantiate(ca.rHandWeaponMesh[_rHandWeaponIndex], pc.RT_HandWeaponNode.transform.position, 
			Quaternion.identity) as GameObject;
		rHandWeaponMesh.transform.parent = pc.RT_HandWeaponNode.transform;
		rHandWeaponMesh.transform.rotation = new Quaternion(0, 0, 0, 0);
		rHandWeaponMesh.transform.localScale = pc.RT_HandWeaponNode.transform.localScale;

		switch (_rHandWeaponIndex) {

			case 1:
				_rHandWeaponIndex = 1;
				break;

			default:
				_rHandWeaponIndex = 0;
				break;
		}
	}

	void InstantiateLeftArmArmorMesh(){

		if (_lArmArmorIndex > ca.lArmArmorMesh.Length - 1) {
			_lArmArmorIndex = 0;
		}

		if (pc.LF_ArmNode.transform.childCount > 0) {
			for (int i = 0; i < pc.LF_ArmNode.transform.childCount; i++) {
				Destroy(pc.LF_ArmNode.transform.GetChild(i).gameObject);
			}
		}

		lArmArmorMesh = Instantiate(ca.lArmArmorMesh[_lArmArmorIndex], pc.LF_ArmNode.transform.position, 
			Quaternion.identity) as GameObject;
		lArmArmorMesh.transform.parent = pc.LF_ArmNode.transform;
		lArmArmorMesh.transform.rotation = new Quaternion(0, 0, 0, 0);
		Vector3 nodeScale = new Vector3(pc.LF_ArmNode.transform.localScale.x, pc.LF_ArmNode.transform.localScale.y, pc.LF_ArmNode.transform.localScale.z);
		nodeScale.x = nodeScale.x * -1;
		lArmArmorMesh.transform.localScale = nodeScale;

		switch (_lArmArmorIndex) {

			case 1:
				_lArmArmorIndex = 1;
				break;

			default:
				_lArmArmorIndex = 0;
				break;
		}
	}

	void InstantiateRightArmArmorMesh(){

		if (_rArmArmorIndex > ca.rArmArmorMesh.Length - 1) {
			_rArmArmorIndex = 0;
		}

		if (pc.RT_ArmNode.transform.childCount > 0) {
			for (int i = 0; i < pc.RT_ArmNode.transform.childCount; i++) {
				Destroy(pc.RT_ArmNode.transform.GetChild(i).gameObject);
			}
		}

		rArmArmorMesh = Instantiate(ca.rArmArmorMesh[_rArmArmorIndex], pc.RT_ArmNode.transform.position, 
			Quaternion.identity) as GameObject;
		rArmArmorMesh.transform.parent = pc.RT_ArmNode.transform;
		rArmArmorMesh.transform.rotation = new Quaternion(0, 0, 0, 0);
		rArmArmorMesh.transform.localScale = pc.RT_ArmNode.transform.localScale;

		switch (_rArmArmorIndex) {

			case 1:
				_rArmArmorIndex = 1;
				break;

			default:
				_rArmArmorIndex = 0;
				break;
		}
	}

	void InstantiateChestArmorMesh(){
		
		if (_chestArmorIndex > ca.chestArmorMesh.Length - 1) {
			_chestArmorIndex = 0;
		}


		if (pc.chestNode.transform.childCount > 0) {
			for (int i = 0; i < pc.chestNode.transform.childCount; i++) {
				Destroy(pc.chestNode.transform.GetChild(i).gameObject);
			}
		}
		
		chestArmorMesh = Instantiate(ca.chestArmorMesh[_chestArmorIndex], pc.chestNode.transform.position, Quaternion.identity) as GameObject;
		chestArmorMesh.transform.parent = pc.chestNode.transform;
		chestArmorMesh.transform.rotation = new Quaternion(0, 0, 0, 0);

		switch (_chestArmorIndex) {

			case 1:
				_chestArmorIndex = 1;
				break;

			default:
				_chestArmorIndex = 0;
				break;
		}


	}

	void InstantiateHelmetMesh(){

		if (_helmetArmorIndex > ca.helmetMesh.Length - 1) {
			_helmetArmorIndex = 0;
		}

		if (pc.helmetNode.transform.childCount > 0) {
			for (int i = 0; i < pc.helmetNode.transform.childCount; i++) {
				Destroy(pc.helmetNode.transform.GetChild(i).gameObject);
			}
		}
		
		helmetMesh = Instantiate(ca.helmetMesh[_helmetArmorIndex], pc.helmetNode.transform.position, Quaternion.identity) as GameObject;
		helmetMesh.transform.parent = pc.helmetNode.transform;
		helmetMesh.transform.rotation = new Quaternion(0, 0, 0, 0);

		switch (_helmetArmorIndex) {

			case 1:
				_helmetArmorIndex = 1;
				break;

			default:
				_helmetArmorIndex = 0;
				break;
		}


	}

	void InstantiateLeftKneeMesh(){

		if (_lKneeArmorIndex > ca.lKneeArmorMesh.Length - 1) {
			_lKneeArmorIndex = 0;
		}

		if (pc.LF_KneeNode.transform.childCount > 0) {
			for (int i = 0; i < pc.LF_KneeNode.transform.childCount; i++) {
				Destroy(pc.LF_KneeNode.transform.GetChild(i).gameObject);
			}
		}

		lKneeMesh = Instantiate(ca.lKneeArmorMesh[_lKneeArmorIndex], pc.LF_KneeNode.transform.position, Quaternion.identity) as GameObject;
		lKneeMesh.transform.parent = pc.LF_KneeNode.transform;
		lKneeMesh.transform.rotation = pc.LF_KneeNode.transform.rotation;

		switch (_lKneeArmorIndex) {

			case 1:
				_lKneeArmorIndex = 1;
				break;

			default:
				_lKneeArmorIndex = 0;
				break;
		}


	}

	void InstantiateRightKneeMesh(){

		if (_rKneeArmorIndex > ca.rKneeArmorMesh.Length - 1) {
			_rKneeArmorIndex = 0;
		}

		if (pc.RT_KneeNode.transform.childCount > 0) {
			for (int i = 0; i < pc.RT_KneeNode.transform.childCount; i++) {
				Destroy(pc.RT_KneeNode.transform.GetChild(i).gameObject);
			}
		}

		rKneeMesh = Instantiate(ca.rKneeArmorMesh[_rKneeArmorIndex], pc.RT_KneeNode.transform.position, Quaternion.identity) as GameObject;
		rKneeMesh.transform.parent = pc.RT_KneeNode.transform;
		rKneeMesh.transform.rotation = pc.RT_KneeNode.transform.rotation;

		switch (_rKneeArmorIndex) {

			case 1:
				_rKneeArmorIndex = 1;
				break;

			default:
				_rKneeArmorIndex = 0;
				break;
		}


	}

	void InstantiateBeltArmorMesh(){

		if (_beltArmorIndex > ca.beltArmorMesh.Length - 1) {
			_beltArmorIndex = 0;
		}

		if (pc.beltNode.transform.childCount > 0) {
			for (int i = 0; i < pc.beltNode.transform.childCount; i++) {
				Destroy(pc.beltNode.transform.GetChild(i).gameObject);
			}
		}

		beltArmorMesh = Instantiate(ca.beltArmorMesh[_beltArmorIndex], pc.beltNode.transform.position, Quaternion.identity) as GameObject;
		beltArmorMesh.transform.parent = pc.beltNode.transform;
		beltArmorMesh.transform.rotation = new Quaternion(0, 0, 0, 0);

		switch (_beltArmorIndex) {

			case 1:
				_beltArmorIndex = 1;
				break;

			default:
				_beltArmorIndex = 0;
				break;
		}



	}

	void InstantiateLeftHipArmorMesh(){

		if (_lHipArmorIndex > ca.lHipArmorMesh.Length - 1) {
			_lHipArmorIndex = 0;
		}

		if (pc.LF_HipNode.transform.childCount > 0) {
			for (int i = 0; i < pc.LF_HipNode.transform.childCount; i++) {
				Destroy(pc.LF_HipNode.transform.GetChild(i).gameObject);
			}
		}

		lHipArmorMesh = Instantiate(ca.lHipArmorMesh[_lHipArmorIndex], pc.LF_HipNode.transform.position, Quaternion.identity) as GameObject;
		lHipArmorMesh.transform.parent = pc.LF_HipNode.transform;
		lHipArmorMesh.transform.rotation = pc.LF_HipNode.transform.rotation;

		switch (_lHipArmorIndex) {

			case 1:
				_lHipArmorIndex = 1;
				break;

			default:
				_lHipArmorIndex = 0;
				break;
		}
	}

	void InstantiateRightHipArmorMesh(){

		if (_rHipArmorIndex > ca.rHipArmorMesh.Length - 1) {
			_rHipArmorIndex = 0;
		}

		if (pc.LF_HipNode.transform.childCount > 0) {
			for (int i = 0; i < pc.RT_HipNode.transform.childCount; i++) {
				Destroy(pc.RT_HipNode.transform.GetChild(i).gameObject);
			}
		}

		rHipArmorMesh = Instantiate(ca.rHipArmorMesh[_rHipArmorIndex], pc.RT_HipNode.transform.position, Quaternion.identity) as GameObject;
		rHipArmorMesh.transform.parent = pc.RT_HipNode.transform;
		rHipArmorMesh.transform.rotation = pc.RT_HipNode.transform.rotation;



		switch (_rHipArmorIndex) {

			case 1:
				_rHipArmorIndex = 1;
				break;

			default:
				_rHipArmorIndex = 0;
				break;
		}
	}

	void InstantiateArmorMesh(int _meshIndex, GameObject[] _armorMesh, GameObject _parentNode){
		
		if (_parentNode.transform.childCount > 0) {
			for (int i = 0; i < _parentNode.transform.childCount; i++) {
				Destroy(_parentNode.transform.GetChild(i).gameObject);
			}
		}

		armorMesh = Instantiate(_armorMesh[_meshIndex], _parentNode.transform.position, Quaternion.identity) as GameObject;
		armorMesh.transform.parent = _parentNode.transform;
		armorMesh.transform.rotation = _parentNode.transform.rotation;

	}

	void InstantiateCharacterMesh(int meshIndex, GameObject[] charMesh){
		
		_characterMeshIndex = meshIndex;

		if (_characterMeshIndex > ca.characterMesh.Length - 1) {
			_characterMeshIndex = 0;
		}

		if(spawnPoint.transform.childCount > 0){
			for (int i = 0; i < spawnPoint.transform.childCount; i++) {
				Destroy(spawnPoint.transform.GetChild(i).gameObject);
			}
		}

		GameObject mesh = Instantiate(charMesh[_characterMeshIndex], new Vector3(0,0,0), Quaternion.Euler(0,90,0)) as GameObject;
		mesh.transform.parent = spawnPoint.transform;
		pc = mesh.GetComponent<PlayerCharacter>();

		if(ca.characterMesh.Length > 0){
			if(Enumerable.Range(0, ca.characterMesh.Length).Contains(_characterMeshIndex)){
				_charMeshName = pc.characterName; 
			}
		}
		isUpdated = true;
	}
	#endregion


	#region Change Meshes


	void ChangeHelmetArmorMesh(){
		if (GUI.Button(new Rect(77, 0, 120, 30), "Helmet")) {
			_helmetArmorIndex++;

			if (_helmetArmorIndex > ca.helmetMesh.Length -1) {
				_helmetArmorIndex = 0;
			}

			InstantiateArmorMesh(_helmetArmorIndex, ca.helmetMesh, pc.helmetNode);
		}
	}

	void ChangeChestArmorMesh(){
		// Changes Armor mesh and torso material on character to provide the straps for the armor.
		if(GUI.Button(new Rect(77, 40, 120, 30), "Chest Armor")){
			_chestArmorIndex++;

			if(_chestArmorIndex > ca.chestArmorMesh.Length -1){
				_chestArmorIndex = 0;
			}

			InstantiateArmorMesh(_chestArmorIndex, ca.chestArmorMesh, pc.chestNode);
			_chestMaterialIndex++;
			ChangeMeshMaterial(CharacterMeshMaterial.Chest);
		}
	}

	void ChangeLeftShoulderGuardMesh(){
		if(GUI.Button(new Rect( 5, 80, 120, 30), "L Shoulder Guard")){
			_lShoulderArmorIndex++;

			if(_lShoulderArmorIndex > ca.lShoulderArmorMesh.Length -1){
				_lShoulderArmorIndex = 0;
			}

			InstantiateArmorMesh(_lShoulderArmorIndex, ca.lShoulderArmorMesh, pc.LF_ShoulderGuardNode);
		}
	}

	void ChangeRightShoulderGuardMesh(){
		if(GUI.Button(new Rect(160, 80, 120, 30), "R Shoulder Guard")){
			_rShoulderArmorIndex++;

			if(_rShoulderArmorIndex > ca.rShoulderArmorMesh.Length -1){
				_rShoulderArmorIndex = 0;
			}

			InstantiateArmorMesh(_rShoulderArmorIndex, ca.rShoulderArmorMesh, pc.RT_ShoulderGuardNode);
		}
	}

	void ChangeLeftArmArmorMesh(){
		if(GUI.Button(new Rect( 5, 120, 120, 30), "L Arm Guard")){
			_lArmArmorIndex++;

			if(_lArmArmorIndex > ca.lArmArmorMesh.Length -1){
				_lArmArmorIndex = 0;
			}

			InstantiateArmorMesh(_lArmArmorIndex, ca.lArmArmorMesh, pc.LF_ArmNode);
		}
	}

	void ChangeRightArmArmorMesh(){
		if(GUI.Button(new Rect( 160, 120, 120, 30), "R Arm Guard")){
			_rArmArmorIndex++;

			if(_rArmArmorIndex > ca.rArmArmorMesh.Length -1){
				_rArmArmorIndex = 0;
			}

			InstantiateArmorMesh(_rArmArmorIndex, ca.rArmArmorMesh, pc.RT_ArmNode);
		}
	}

	void ChangeLeftHandWeaponMesh(){
		if(GUI.Button(new Rect( 5, 160, 120, 30), "L Hand Equipt")){
			_lHandWeaponIndex++;

			if (_lHandWeaponIndex > ca.lHandWeaponMesh.Length -1) {
				_lHandWeaponIndex = 0;
			}

			InstantiateArmorMesh(_lHandWeaponIndex, ca.lHandWeaponMesh, pc.LF_HandWeaponNode);
		}
	}

	void ChangeRightHandWeaponMesh(){
		if(GUI.Button(new Rect(160, 160, 120, 30), "R Hand Equipt")){
			_rHandWeaponIndex++;

			if (_rHandWeaponIndex > ca.rHandWeaponMesh.Length -1) {
				_rHandWeaponIndex = 0;
			}

			InstantiateArmorMesh(_rHandWeaponIndex, ca.rHandWeaponMesh, pc.RT_HandWeaponNode);
		}
	}

	void ChangeBeltArmorMesh(){
		if(GUI.Button(new Rect(77, 200, 120, 30), "Belt Armor")){
			_beltArmorIndex++;

			if (_beltArmorIndex > ca.beltArmorMesh.Length -1) {
				_beltArmorIndex = 0;
			}
			InstantiateArmorMesh(_beltArmorIndex, ca.beltArmorMesh, pc.beltNode);
		}
	}

	void ChangeLeftHipArmorMesh(){
		if(GUI.Button(new Rect(5, 240, 120, 30), "L Hip Armor")){
			_lHipArmorIndex++;

			if (_lHipArmorIndex > ca.lHipArmorMesh.Length -1) {
				_lHipArmorIndex = 0;
			}

			InstantiateArmorMesh(_lHipArmorIndex, ca.lHipArmorMesh, pc.LF_HipNode);
		}
	}

	void ChangeRightHipArmorMesh(){
		if(GUI.Button(new Rect(160, 240, 120, 30), "R Hip Armor")){
			_rHipArmorIndex++;

			if (_rHipArmorIndex > ca.rHipArmorMesh.Length -1) {
				_rHipArmorIndex = 0;
			}

			InstantiateArmorMesh(_rHipArmorIndex, ca.rHipArmorMesh, pc.RT_HipNode);
		}
	}

	void ChangeLeftKneeArmorMesh(){
		if(GUI.Button(new Rect( 5, 280, 120, 30), "L Knee Guard")){
			_lKneeArmorIndex++;

			if (_lKneeArmorIndex > ca.lKneeArmorMesh.Length -1) {
				_lKneeArmorIndex = 0;
			}

			InstantiateArmorMesh(_lKneeArmorIndex, ca.lKneeArmorMesh, pc.LF_KneeNode);
		}
	}

	void ChangeRightKneeArmorMesh(){
		if(GUI.Button(new Rect(160, 280, 120, 30), "R Knee Guard")){
			_rKneeArmorIndex++;

			if (_rKneeArmorIndex > ca.rKneeArmorMesh.Length -1) {
				_rKneeArmorIndex = 0;
			}

			InstantiateArmorMesh(_rKneeArmorIndex, ca.rKneeArmorMesh, pc.RT_KneeNode);
		}
	}

	#endregion

	void ChangeHeadMaterial(){

		if (GUI.Button(new Rect(77, 400, 120, 30), _headMaterialName)) {
			_headMaterialIndex++;
			ChangeMeshMaterial(CharacterMeshMaterial.Head);
		}
		switch (_headMaterialIndex) {
			case 1:
				_headMaterialName = "Scared";
				break;
			default:
				_headMaterialName = "Normal";
				break;
		}
	}

	void ChangeMeshMaterial(CharacterMeshMaterial cmm){
		
		int cmmHash = cmm.GetHashCode();

		Material[] mats = pc.characterMaterialMesh.GetComponent<Renderer>().materials;

		for (int i = 0; i < pc.characterMaterialMesh.GetComponent<Renderer>().materials.Length; i++) {
			mats[i] = pc.characterMaterialMesh.GetComponent<Renderer>().materials[i];
		}

		switch(cmm){ 
			case CharacterMeshMaterial.Chest:
				if (_chestMaterialIndex > ca.chestMaterial.Length - 1) {
					_chestMaterialIndex = 0;
				} else if (_chestMaterialIndex < 0) {
					_chestMaterialIndex = ca.chestMaterial.Length - 1;
				}
				mats[cmmHash] = ca.chestMaterial[_chestMaterialIndex];
				break;

			case CharacterMeshMaterial.Head:
				if (_headMaterialIndex > ca.headMaterial.Length - 1) {
					_headMaterialIndex = 0;
				} else if (_headMaterialIndex < 0) {
					_headMaterialIndex = ca.headMaterial.Length - 1;
				}
				mats[cmmHash] = ca.headMaterial[_headMaterialIndex];
				break;
		}


		DestroyImmediate(pc.characterMaterialMesh.GetComponent<Renderer>().materials[cmmHash]);
		pc.characterMaterialMesh.GetComponent<Renderer>().materials = mats;
	}

	void ChangeCharacterMesh(){
		if (GUI.Button(new Rect(Screen.width / 2 - 60, Screen.height - 30, 120, 30), _charMeshName)){
			_characterMeshIndex++;
			InstantiateCharacterMesh(_characterMeshIndex, ca.characterMesh);
			isUpdated = true;
		}
	}

//	void SaveCharacterToPrefab(){
//
//		PrefabUtility
//	}

}
