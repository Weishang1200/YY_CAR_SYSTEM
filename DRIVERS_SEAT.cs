
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class DRIVERS_SEAT : UdonSharpBehaviour
{
    [SerializeField] VRCStation VRCSTATION;
	[SerializeField]GameObject PARENT;
	public bool IS_SITTING=false;
    void Start()
    {
        
    }

    public void Interact(){
        VRCSTATION.UseStation(Networking.LocalPlayer);
		Networking.SetOwner(Networking.LocalPlayer,this.gameObject);
		Networking.SetOwner(Networking.LocalPlayer,PARENT);
	}

    public override void OnStationEntered(VRCPlayerApi PLAYER){
		IS_SITTING=true;
	}

    public override void OnStationExited(VRCPlayerApi PLAYER){
		IS_SITTING=false;
	}
}
