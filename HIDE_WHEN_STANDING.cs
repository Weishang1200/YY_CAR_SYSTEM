
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class HIDE_WHEN_STANDING : UdonSharpBehaviour
{
	[SerializeField]GameObject[] HIDE_OBJECT;
	[UdonSynced]bool IS_ACTIVE=true;
    void Start()
    {
        
    }
 	void OnPlayerTriggerEnter(VRCPlayerApi PLAYER){
		if(PLAYER==Networking.LocalPlayer){
			SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All,"SYNC_DEACTIVATE");
			IS_ACTIVE=false;
		}
	}
 	void OnPlayerTriggerExit(VRCPlayerApi PLAYER){
		if(PLAYER==Networking.LocalPlayer){
			SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All,"SYNC_ACTIVATE");
			IS_ACTIVE=true;
		}
	}

	public override void OnPlayerJoined(VRCPlayerApi PLAYER){
		if(!IS_ACTIVE && Networking.IsOwner(this.gameObject)){
			SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All,"SYNC_DEACTIVATE");
		}
	}

	public void SYNC_ACTIVATE(){
		for(int cnt=0;cnt<HIDE_OBJECT.Length;cnt+=1){
			HIDE_OBJECT[cnt].SetActive(true);
		}
	}

	public void SYNC_DEACTIVATE(){
		for(int cnt=0;cnt<HIDE_OBJECT.Length;cnt+=1){
			HIDE_OBJECT[cnt].SetActive(false);
		}
	}
}
