
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class CHECK_POINT : UdonSharpBehaviour
{
	[SerializeField]GameObject[] TARGET;
	[SerializeField]public int CHECK_POINT_NUM=0;
	[SerializeField]public bool IS_FINISH_LINE=false;
	[SerializeField]public bool IS_IN_PIT=false;
	public bool IS_CHECKED=false;
	public bool PASSING=false;
	public string PASSED_OBJECT_NAME="";
    /*void Start()
    {
        
    }*/
	void OnTriggerEnter(Collider COLLI){
		if(Networking.IsOwner(Networking.LocalPlayer,COLLI.transform.root.gameObject)){
			for(int cnt=0;cnt<TARGET.Length;cnt+=1){
				if(TARGET[cnt]==COLLI.transform.root.gameObject){
					IS_CHECKED=true;
					PASSING=true;
					PASSED_OBJECT_NAME=COLLI.transform.root.gameObject.name;
					break;
				}
			}
		}
	}

	public void OnPlayerRespawn(VRCPlayerApi PLAYER){
		if(PLAYER==Networking.LocalPlayer)IS_CHECKED=false;
	}

	void LateUpdate(){
		PASSING=false;
	}
}
