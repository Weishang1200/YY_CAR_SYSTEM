
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using VRC.Udon.Common;

public class GETOFF : UdonSharpBehaviour
{
    [SerializeField] VRCStation vrcStation;
    public void Interact(){ 
		vrcStation.ExitStation(Networking.LocalPlayer);
	}
    void Start(){
        
    }
}
