#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
 
[InitializeOnLoad]
public class CHANGE_CAMERA_SETTINGS_WHEN_PLATFORM_SWITCHED : MonoBehaviour
{
	[SerializeField]RenderTexture RENDERING_TEXTURE_WINDOWS;
	[SerializeField]float FAR_CLIP_PLANE_WINDOWS=250.0f;
	[SerializeField]RenderTexture RENDERING_TEXTURE_ANDROID;
	[SerializeField]float FAR_CLIP_PLANE_ANDROID=120.0f;
	CHANGE_CAMERA_SETTINGS_WHEN_PLATFORM_SWITCHED() {
		EditorUserBuildSettings.activeBuildTargetChanged+=OnChangePlatform;
	}
	void OnChangePlatform() {
		BuildTarget CUR_PLATFORM=EditorUserBuildSettings.activeBuildTarget;
		Debug.Log("プラットフォームが変わったよ！！！！！！！！"+CUR_PLATFORM);
		Camera CAMERA=gameObject.GetComponent<Camera>();
		if(CUR_PLATFORM==BuildTarget.StandaloneWindows64){
			CAMERA.targetTexture=RENDERING_TEXTURE_WINDOWS;
			CAMERA.farClipPlane=FAR_CLIP_PLANE_WINDOWS;
		}
		if(CUR_PLATFORM==BuildTarget.Android){
			CAMERA.targetTexture=RENDERING_TEXTURE_ANDROID;
			CAMERA.farClipPlane=FAR_CLIP_PLANE_ANDROID;
		}
	}
}
#endif
