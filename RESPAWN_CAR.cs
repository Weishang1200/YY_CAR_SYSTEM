
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class RESPAWN_CAR : UdonSharpBehaviour
{
	[SerializeField]CAR CAR_TO_RESPAWN;
	[SerializeField]Vector3 DEFAULT_POS;
	[SerializeField]Vector3 DEFAULT_ROT;

	void Interact(){
		if(!CAR_TO_RESPAWN.IS_SITTING){
			Networking.SetOwner(Networking.LocalPlayer,CAR_TO_RESPAWN.gameObject);
			CAR_TO_RESPAWN.transform.position=DEFAULT_POS;
			CAR_TO_RESPAWN.transform.eulerAngles=DEFAULT_ROT;
		}
	}
}
