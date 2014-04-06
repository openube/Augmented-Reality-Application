/*==============================================================================
Copyright (c) 2012-2013 Qualcomm Connected Experiences, Inc.
All Rights Reserved.
Confidential and Proprietary - Qualcomm Connected Experiences, Inc.
==============================================================================*/

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

/// <summary>
/// This MonoBehaviour manages the usage of a webcam for Play Mode in Windows or Mac.
/// </summary>
[RequireComponent(typeof(Camera))]
public class WebCamBehaviour : WebCamAbstractBehaviour
{
//	public bool isON = false;
//	public GameObject car;
//
//	void Start(){
//
//	}
//	void Update(){
//		//Debug.Log (transform.position);
//	}
//
//	void OnGUI()
//	{
////		GUI.skin.GetStyle ("Button").fontSize = 45;
////		GUI.skin.GetStyle ("Label").fontSize = 45;
////		GUI.skin.GetStyle ("TextField").fontSize = 45;
////		GUI.skin.GetStyle ("HorizontalSlider").fixedHeight = 45;
////		GUI.skin.GetStyle ("HorizontalSlider").fixedWidth = 300;
////		GUI.skin.GetStyle("Box").fontSize = 45;
//
//		if(isON)
//		{
//			GUILayout.BeginArea( ResizeGUI(new Rect(0,0,100, 100)) );
//			GUILayout.BeginVertical("box");
//			GUILayout.Label(car.name);
//			if(GUILayout.Button("Action"))
//			{
//				// Do some action 
//			}
//
//			GUILayout.EndVertical();
//			GUILayout.EndArea();
//		}
//
//	}
//
//	Rect ResizeGUI(Rect _rect)
//	{
//		float FilScreenWidth = _rect.width / 800;
//		float rectWidth = FilScreenWidth * Screen.width;
//		float FilScreenHeight = _rect.height / 600;
//		float rectHeight = FilScreenHeight * Screen.height;
//		float rectX = (_rect.x / 800) * Screen.width;
//		float rectY = (_rect.y / 600) * Screen.height;
//		
//		return new Rect(rectX,rectY,rectWidth,rectHeight);
//	}
//
//
//	//When a car is selected, this method is called
//	public void setObject(GameObject obj)
//	{
//		Debug.Log("Camera records the " + obj.name + "actions");
//		car  = obj;
//		isON = true;
//	}
//	public void desetObject()
//	{
//		Debug.Log ("Camera lose the "+car.name);
//		isON = false;
//		car = null;
//	}
}
