
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

[UdonBehaviourSyncMode(BehaviourSyncMode.Manual)]
public class PASSANGERS_SEAT : UdonSharpBehaviour
{
    [SerializeField] VRCStation VRCSTATION;
	[SerializeField]float[] SEAT_HEIGHT;
	[UdonSynced]int CUR_SEAT_HEIGHT=0;
	public bool IS_SITTING=false;
	GETKEY GETKEY_OBJECT;
	float EXIT_STATION_TIMER=0.0f;
	Vector3 SEAT_DEFAULT_POSITION;

    void Start()
    {
		GETKEY_OBJECT=GameObject.Find("GETKEY_OBJECT").GetComponent<GETKEY>();
		SEAT_DEFAULT_POSITION=gameObject.transform.localPosition;
    }

	void Update(){
		if(IS_SITTING){
			if(Networking.IsOwner(Networking.LocalPlayer,this.gameObject)){
				int CUR_KEY=GETKEY_OBJECT.getkey();

				if(CUR_KEY==1){
					if(EXIT_STATION_TIMER==0.0f){
						CUR_SEAT_HEIGHT+=1;
						if(CUR_SEAT_HEIGHT>=SEAT_HEIGHT.Length)CUR_SEAT_HEIGHT=0;
						RequestSerialization();
					}
					EXIT_STATION_TIMER+=Time.deltaTime;
					if(EXIT_STATION_TIMER>=1.0f){
						EXIT_STATION_TIMER=0.0f;
						VRCSTATION.ExitStation(Networking.LocalPlayer);
					}
				}
				else {
					EXIT_STATION_TIMER=0.0f;
				}
			}
			transform.localPosition=SEAT_DEFAULT_POSITION+new Vector3(0,SEAT_HEIGHT[CUR_SEAT_HEIGHT],SEAT_HEIGHT[CUR_SEAT_HEIGHT]);
		}
	}

    public void Interact(){
        VRCSTATION.UseStation(Networking.LocalPlayer);
		Networking.SetOwner(Networking.LocalPlayer,this.gameObject);
	}

    public override void OnStationEntered(VRCPlayerApi PLAYER){
		IS_SITTING=true;
	}

    public override void OnStationExited(VRCPlayerApi PLAYER){
		IS_SITTING=false;
		CUR_SEAT_HEIGHT=0;
	}
}
