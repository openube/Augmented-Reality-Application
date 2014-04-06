using UnityEngine;
using System.Collections;


// This is the toolbar's behavior
public class ToolbarBehavior : MonoBehaviour {

	public bool selected = false;
	public static bool tracked = false;
	public GameObject toolbar;

	public static GameObject SelectedCar = null;
	
	public Vector3 lastPosition;
	public Vector3 lastOrientation;
	
	public Vector3 newPosition;
	public Vector3 newOrientation;
	
	//For scale only 
	public float start;
	public float end;
	
	public int scaleCnt = 0;
	
	public static bool EnableTranslate = false;
	public static bool EnableRotate = false;
	// should set object to enable Scale
	public static bool EnableScale = false;

	public static bool workspace = false;


	void Start () {

		toolbar = this.gameObject;

	}


	// Update is called once per frame
	void Update () {

		if(tracked)
		{
			newPosition =transform.position;
			newOrientation = transform.eulerAngles;
			
			
			Vector3 PosChange = newPosition - lastPosition;
			Vector3 OriChange = newOrientation - lastOrientation;
			
			
			lastPosition = newPosition;
			lastOrientation = newOrientation;
			
			
			
			if(Selection.selectedCar != null)
			{
				if(!workspace)
				{
					//Default mode
					
					if(EnableTranslate)
					{
						SelectedCar.transform.GetComponent<Selection>().translate(PosChange);
						//EnableRotate = EnableScale = false;
					}
					if(EnableRotate)
					{
						SelectedCar.transform.GetComponent<Selection>().rotate(OriChange);
						//EnableTranslate = EnableScale = false;
					}
					if(EnableScale)
					{
						if(scaleCnt == 0)
						{
							start = newPosition.x;
						}
						
						scaleCnt++;
						
						//every 50 frame, update scale
						if(scaleCnt == 50)
						{
							end = newPosition.x;
							bool Zoom_in = (end - start > 0)?true:false;
							
							SelectedCar.transform.GetComponent<Selection>().scale(Zoom_in);
							
							scaleCnt = 0;
						}
						
					}
				}
				else{
					// Work in the workspace mode
					// CloneCar's change in the workspace mode is 10 times smaller than originalCar's change
					
					if(WorkSpaceManage.CloneCar!=null){
						
						GameObject workspaceCar = WorkSpaceManage.CloneCar;
						
						
						if(EnableTranslate)
						{
							SelectedCar.transform.GetComponent<Selection>().translate(PosChange);
							//EnableRotate = EnableScale = false;
							workspaceCar.transform.position += PosChange/5;
						}
						if(EnableRotate)
						{
							SelectedCar.transform.GetComponent<Selection>().rotate(OriChange);
							//EnableTranslate = EnableScale = false;
							workspaceCar.transform.eulerAngles -= OriChange/5;
						}
						
						if(EnableScale)
						{
							if(scaleCnt == 0)
							{
								start = newPosition.x;
							}
							
							scaleCnt++;
							
							//every 50 frame, update scale
							if(scaleCnt == 50)
							{
								
								end = newPosition.x;
								
								bool Zoom_in = (end - start > 0)?true:false;
								
								SelectedCar.transform.GetComponent<Selection>().scale(Zoom_in);
								
								float sign = Zoom_in?0.1f:-0.1f;
								
								workspaceCar.transform.localScale = workspaceCar.transform.localScale * (1.0f+sign);
								
								scaleCnt = 0;
							}
						}
					}
				}
			}
		}

	}

	public void setSelect(GameObject car)
	{

		selected = true;
		SelectedCar = car;

	}
	public void deselect()
	{

		selected = false;
		SelectedCar = null;

	}

	public void setOnseen(Vector3 pos, Vector3 ori)
	{
		lastPosition = pos;
		lastOrientation = ori;
	}
	              


	void OnTriggerExit(Collider other) {

	}
	
	void OnTriggerStay(Collider other) {
			
	}

}
