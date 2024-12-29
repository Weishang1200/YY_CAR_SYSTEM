
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class LIVE_CAMERA_CHANGE_TARGET : UdonSharpBehaviour
{
	[SerializeField]int TARGET_TO_CHANGE=0;
	LIVE_CAMERA_MANAGER LIVE_CAMERA_MANAGER_OBJECT;
    void Start()
    {
        LIVE_CAMERA_MANAGER_OBJECT=GameObject.Find("LIVE_CAMERA_MANAGER_OBJECT").GetComponent<LIVE_CAMERA_MANAGER>();
    }

	public void Interact(){ 
		Networking.SetOwner(Networking.LocalPlayer,this.gameObject);
		Networking.SetOwner(Networking.LocalPlayer,LIVE_CAMERA_MANAGER_OBJECT.gameObject);
		LIVE_CAMERA_MANAGER_OBJECT.TARGET_OBJECT=TARGET_TO_CHANGE;
	}
}
