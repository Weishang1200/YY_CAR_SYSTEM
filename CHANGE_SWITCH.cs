
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class CHANGE_SWITCH : UdonSharpBehaviour
{
	[SerializeField]GameObject[] OBJECT;

	public void Interact() {
		foreach(GameObject CUR_OBJECT in OBJECT){
			CUR_OBJECT.SetActive(!CUR_OBJECT.activeSelf);
		}
	}
}
