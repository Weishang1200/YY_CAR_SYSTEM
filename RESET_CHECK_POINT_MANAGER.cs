
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class RESET_CHECK_POINT_MANAGER : UdonSharpBehaviour
{
	[SerializeField]CHECK_POINT_MANAGER[] CHECK_POINT_MANAGER_OBJECT;

	/*
    void Start(){
    }
	*/

    public void Interact(){
		SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All,"SYNC_RESET");
	}

	public void SYNC_RESET(){
        for(int cnt=0;cnt<CHECK_POINT_MANAGER_OBJECT.Length;cnt+=1){
			CHECK_POINT_MANAGER_OBJECT[cnt].RESET_LAP();
		}
	}
}
