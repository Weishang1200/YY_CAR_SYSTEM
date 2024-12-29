
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using VRC.Udon.Common;

public class GETKEY : UdonSharpBehaviour
{
	bool CUR_JUMP=false;
	bool CUR_USE=false;
	bool CUR_GRAB=false;
	bool CUR_DROP=false;
	float CUR_LX=0;
	float CUR_LY=0;
	float CUR_RX=0;
	float CUR_RY=0;

	public int getkey(){
		int RET=0;
		if(CUR_JUMP)RET+=1;
		if(CUR_USE)RET+=2;
		if(CUR_GRAB)RET+=4;
		if(CUR_DROP)RET+=8;
		return RET;
	}
	public float LX(){	//これただ単なるゲッタなんじゃないか？
		return CUR_LX;
	}
	public float LY(){
		return CUR_LY;
	}
	public float RX(){
		return CUR_RX;
	}
	public float RY(){
		return CUR_RY;
	}

	public void InputJump(bool value, UdonInputEventArgs args){
		CUR_JUMP=value;
	}
    public void InputUse(bool value, UdonInputEventArgs args){
		CUR_USE=value;
	}
    public void InputGrab(bool value, UdonInputEventArgs args){
		CUR_GRAB=value;
	}
    public void InputDrop(bool value, UdonInputEventArgs args){
		CUR_DROP=value;
	}
    public void InputMoveHorizontal(float value, UdonInputEventArgs args){
		CUR_LX=value;
	}
    public void InputMoveVertical(float value, UdonInputEventArgs args){
		CUR_LY=value;
	}
    public void InputLookHorizontal(float value, UdonInputEventArgs args){
		CUR_RX=value;
	}
    public void InputLookVertical(float value, UdonInputEventArgs args){
		CUR_RY=value;
	}

	/*
    void Start()
    {
        
    }
	*/
}

