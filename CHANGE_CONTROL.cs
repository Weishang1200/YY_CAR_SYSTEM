
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class CHANGE_CONTROL : UdonSharpBehaviour
{
	public bool IS_ANOTHER_CONTROL=false;
    void Start()
    {
        
    }

    public void Interact(){
		IS_ANOTHER_CONTROL=!IS_ANOTHER_CONTROL;
	}
}
