
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class SHOW_WHEN_STANDING : UdonSharpBehaviour
{
	[SerializeField]GameObject[] SHOW_OBJECT;
    void Start()
    {
//#if !UNITY_ANDROID
        //gameObject.SetActive(false);
//#endif
    }
 	void OnPlayerTriggerEnter(VRCPlayerApi PLAYER){
		if(PLAYER==Networking.LocalPlayer){
			for(int cnt=0;cnt<SHOW_OBJECT.Length;cnt+=1){
				SHOW_OBJECT[cnt].SetActive(true);
			}
		}
	}
 	void OnPlayerTriggerExit(VRCPlayerApi PLAYER){
		Debug.Log("!");
		if(PLAYER==Networking.LocalPlayer){
			for(int cnt=0;cnt<SHOW_OBJECT.Length;cnt+=1){
				SHOW_OBJECT[cnt].SetActive(false);
			}
		}
	}
}
