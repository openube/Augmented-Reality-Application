using UnityEngine;
using System.Collections;
/// <summary>
/// Attached to the ARcamera
/// </summary>
public class CameraBehavior : MonoBehaviour {

	public bool isON = false;
	public GameObject car;

	public GameObject inner;
	public GameObject outer;

	void Start(){
		inner.SetActive(false);
		outer.SetActive(false);
	}

	void Update(){

	}
	
	void OnGUI()
	{
		// For mobile setting

		GUI.skin.GetStyle ("Button").fontSize = 45;
		GUI.skin.GetStyle ("Label").fontSize = 45;			
		GUI.skin.GetStyle ("TextField").fontSize = 45;
		GUI.skin.GetStyle ("HorizontalSlider").fixedHeight = 45;
		GUI.skin.GetStyle ("HorizontalSlider").fixedWidth = 300;
		GUI.skin.GetStyle("Box").fontSize = 45	;
		
		if(isON)
		{
			//GUILayout.BeginArea( ResizeGUI(new Rect(0,0,200, 800)) );
			GUILayout.BeginArea(new Rect(0,0,400,1000) ); // PC Debug

			GUILayout.BeginVertical("box");

			GUILayout.Label(car.name);

			GUILayout.Label ("Translate");
			GUILayout.BeginHorizontal("box");
				if(GUILayout.Button("On"))
				{
					ToolbarBehavior.EnableTranslate = true;
					ToolbarBehavior.EnableRotate = false;
					ToolbarBehavior.EnableScale = false;
				}
				if(GUILayout.Button("Off"))
				{
					ToolbarBehavior.EnableTranslate = false;
					ToolbarBehavior.EnableRotate = false;
					ToolbarBehavior.EnableScale = false;
				}
			GUILayout.EndHorizontal();

			GUILayout.Label("Rotate");
			GUILayout.BeginHorizontal("box");
				if(GUILayout.Button("On"))
				{
					ToolbarBehavior.EnableRotate = true;
					ToolbarBehavior.EnableScale = false;
					ToolbarBehavior.EnableTranslate = false;
				}
				if(GUILayout.Button("Off"))
				{
					ToolbarBehavior.EnableRotate = false;
					ToolbarBehavior.EnableScale = false;
					ToolbarBehavior.EnableTranslate = false;
				}
			GUILayout.EndHorizontal();

			GUILayout.Label("Scale");
			GUILayout.BeginHorizontal("box");
				if(GUILayout.Button("On"))
				{
					ToolbarBehavior.EnableScale = true;
					ToolbarBehavior.EnableRotate = false;
					ToolbarBehavior.EnableTranslate = false;
				}
				if(GUILayout.Button("Off"))
				{
					ToolbarBehavior.EnableScale = false;
					ToolbarBehavior.EnableRotate = false;
					ToolbarBehavior.EnableTranslate = false;
				}
			GUILayout.EndHorizontal();

			GUILayout.Label("Coordinate System");
			GUILayout.BeginHorizontal("box");
				// If Coordinate System
				if(GUILayout.Button("On"))
				{
					car.transform.GetComponent<Selection>().setCoordinate();
				}
				if(GUILayout.Button("Off"))
				{
					car.transform.GetComponent<Selection>().resetCoordinate();
				}

			GUILayout.EndHorizontal();

		
			GUILayout.Label("Workspace Mode");

			GUILayout.BeginHorizontal("box");
				if(GUILayout.Button("On"))
				{

					ToolbarBehavior.workspace = true;
					
				}
				if(GUILayout.Button("Off"))
				{
					ToolbarBehavior.workspace = false;
				}
			GUILayout.EndHorizontal();


			if(GUILayout.Button("reset"))
			{
				car.transform.GetComponent<Selection>().reset();
				ToolbarBehavior.EnableScale = ToolbarBehavior.EnableRotate = ToolbarBehavior.EnableTranslate = false;;
				ToolbarBehavior.workspace = false;
			}

			GUILayout.EndVertical();
			GUILayout.EndArea();
		}
		
	}
	
	Rect ResizeGUI(Rect _rect)
	{
		float FilScreenWidth = _rect.width / 800;
		float rectWidth = FilScreenWidth * Screen.width;
		float FilScreenHeight = _rect.height / 600;
		float rectHeight = FilScreenHeight * Screen.height;
		float rectX = (_rect.x / 800) * Screen.width;
		float rectY = (_rect.y / 600) * Screen.height;
		
		return new Rect(rectX,rectY,rectWidth,rectHeight);
	}
	
	
	//When a car is selected, this method is called
	public void setObject(GameObject obj)
	{
		Debug.Log("Camera records the " + obj.name + "actions");

		car  = obj;
		isON = true;
	}
	//When a car is deselected
	public void desetObject()
	{
		Debug.Log ("Camera lose the "+car.name);
		isON = false;
		car = null;
	}

	public void playModeSwitch()
	{


	}


}
