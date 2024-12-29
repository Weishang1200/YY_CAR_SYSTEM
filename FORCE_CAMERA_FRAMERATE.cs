
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class FORCE_CAMERA_FRAMERATE : UdonSharpBehaviour
{
	[SerializeField]float WINDOWS_FPS=60.0f;
	[SerializeField]float ANDROID_FPS=15.0f;
	float FREQ;
	Camera CAMERA;
	float TIMER=0.0f;
    void Start()
    {
        CAMERA=GetComponent<Camera>();
#if !UNITY_ANDROID
	FREQ=1.0f/WINDOWS_FPS;
#else
	FREQ=1.0f/ANDROID_FPS;
#endif
    }
	void Update(){
		TIMER+=Time.deltaTime;
		if(TIMER>=FREQ){
			TIMER-=FREQ;
			CAMERA.enabled=true;
		}
		else{
			CAMERA.enabled=false;
		}
	}
}
