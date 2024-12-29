#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
 
[InitializeOnLoad]
public class SWITCH_MATERIAL_WHEN_PLATFORM_SWITCHED : MonoBehaviour
{
	[SerializeField]Material[] MATERIAL_WINDOWS;
	[SerializeField]Material[] MATERIAL_ANDROIDf;
	SWITCH_MATERIAL_WHEN_PLATFORM_SWITCHED() {
		EditorUserBuildSettings.activeBuildTargetChanged+=OnChangePlatform;
	}
	void OnChangePlatform() {
		BuildTarget CUR_PLATFORM=EditorUserBuildSettings.activeBuildTarget;
		Debug.Log("プラットフォームが変わったよ！！！！！！！！"+CUR_PLATFORM);
		MeshRenderer MESH_RENDERER=gameObject.GetComponent<MeshRenderer>();
		if(CUR_PLATFORM==BuildTarget.StandaloneWindows64){
			MESH_RENDERER.materials=MATERIAL_WINDOWS;
		}
		if(CUR_PLATFORM==BuildTarget.Android){
			MESH_RENDERER.materials=MATERIAL_ANDROIDf;
		}
	}
}
#endif
