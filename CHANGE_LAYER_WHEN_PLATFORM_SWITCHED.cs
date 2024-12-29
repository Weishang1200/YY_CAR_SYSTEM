#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

[InitializeOnLoad]
public class CHANGE_LAYER_WHEN_PLATFORM_SWITCHED : MonoBehaviour
{
	[SerializeField]string LAYER_WINDOWS;
	[SerializeField]string LAYER_ANDROID;
	CHANGE_LAYER_WHEN_PLATFORM_SWITCHED() {
		EditorUserBuildSettings.activeBuildTargetChanged+=OnChangePlatform;
	}
	void OnChangePlatform() {
		BuildTarget CUR_PLATFORM=EditorUserBuildSettings.activeBuildTarget;
		Debug.Log("プラットフォームが変わったよ！！！！！！！！"+CUR_PLATFORM);
		if(CUR_PLATFORM==BuildTarget.StandaloneWindows64){
			gameObject.layer=LayerMask.NameToLayer(LAYER_WINDOWS);
		}
		if(CUR_PLATFORM==BuildTarget.Android){
			gameObject.layer=LayerMask.NameToLayer(LAYER_ANDROID);
		}
	}
}
#endif
