
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using VRC.Udon.Common;

public class HANDLE_GRIP : UdonSharpBehaviour
{
	[SerializeField]GameObject CENTER;
	[SerializeField]bool IS_LEFT;
	float DIST_FROM_CENTER;
	public bool IS_HELD=false;
    void Start()
    {
		DIST_FROM_CENTER=Vector3.Distance(transform.position,CENTER.transform.position);
    }
	void LateUpdate(){
		transform.position=CENTER.transform.position;
		transform.localEulerAngles=Vector3.zero;
		Vector3 CUR_HAND_POS;
		if(IS_LEFT){
			CUR_HAND_POS=transform.InverseTransformPoint(Networking.LocalPlayer.GetTrackingData(VRCPlayerApi.TrackingDataType.LeftHand).position);
		}
		else{
			CUR_HAND_POS=transform.InverseTransformPoint(Networking.LocalPlayer.GetTrackingData(VRCPlayerApi.TrackingDataType.RightHand).position);
		}
		CUR_HAND_POS=Vector3.ProjectOnPlane(CUR_HAND_POS,Vector3.forward);
		transform.localPosition=Vector3.Normalize(CUR_HAND_POS)*DIST_FROM_CENTER;
	}

    public void InputGrab(bool value, UdonInputEventArgs args){
		if(value && ((args.handType==HandType.LEFT && IS_LEFT) || (args.handType==HandType.RIGHT && !IS_LEFT))){
			IS_HELD=true;
		}
		else if(!value && ((args.handType==HandType.LEFT && IS_LEFT) || (args.handType==HandType.RIGHT && !IS_LEFT))){
			IS_HELD=false;
		}
	}
}
