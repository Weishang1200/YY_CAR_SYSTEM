
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class LIVE_CAMERA_ON_HELI : UdonSharpBehaviour
{
	LIVE_CAMERA_MANAGER LIVE_CAMERA_MANAGER_OBJECT;
    void Start()
    {
        LIVE_CAMERA_MANAGER_OBJECT=GameObject.Find("LIVE_CAMERA_MANAGER_OBJECT").GetComponent<LIVE_CAMERA_MANAGER>();
    }
	public void Interact(){ 
		Networking.SetOwner(Networking.LocalPlayer,this.gameObject);
		Networking.SetOwner(Networking.LocalPlayer,LIVE_CAMERA_MANAGER_OBJECT.gameObject);
		LIVE_CAMERA_MANAGER_OBJECT.IS_ON_HELI=!LIVE_CAMERA_MANAGER_OBJECT.IS_ON_HELI;
	}

}
