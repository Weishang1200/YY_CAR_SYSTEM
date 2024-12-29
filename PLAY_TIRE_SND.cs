
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class PLAY_TIRE_SND : UdonSharpBehaviour
{
	[SerializeField]GameObject AUDIO_SOURCE_PREFAB;
	[SerializeField]GameObject TIRE_OBJECT;
	[SerializeField]ParticleSystem TIRE_SMOKE;
	public bool IS_UNPAUSED=false;
	public float PITCH=1.0f;
	float TIMER=0.0f;
	AudioSource AUDIO_SOURCE;
	bool PREV_UNPAUSED=false;

    void Start()
    {

    }
	void Update(){
		if(IS_UNPAUSED){
			if(!PREV_UNPAUSED){
				PREV_UNPAUSED=true;
				AUDIO_SOURCE=VRCInstantiate(AUDIO_SOURCE_PREFAB).transform.GetComponent<AudioSource>();
				AUDIO_SOURCE.transform.SetParent(TIRE_OBJECT.transform);
				AUDIO_SOURCE.transform.localPosition=Vector3.zero;
			}
			AUDIO_SOURCE.pitch=PITCH;
			AUDIO_SOURCE.volume=PITCH*0.05f;
			if(TIRE_SMOKE!=null){
				if(!TIRE_SMOKE.isPlaying)TIRE_SMOKE.Play();
			}
			TIMER=0.1f;
		}
		else{
			TIMER-=Time.deltaTime;
		}
		if(TIMER<=0){
			if(PREV_UNPAUSED){
				PREV_UNPAUSED=false;
				Destroy(AUDIO_SOURCE.gameObject);
			}
			if(TIRE_SMOKE!=null){
				TIRE_SMOKE.Stop();
			}
		}
	}
}
