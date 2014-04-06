using UnityEngine;
using System.Collections;

public class WorkSpaceManage : MonoBehaviour {
	
	public static bool Tracking = false;
	public static GameObject originCar;
	
	public static GameObject CloneCar;
	
	public GameObject workspace;
	
	public string cloneName = "";
	//Show mirrored car on the workspace
	public static bool showFlag = false;
	
	// Use this for initialization
	void Start () {
		workspace = GameObject.Find("OtherSys");
	}
	
	// Update is called once per frame
	void Update () {
		
		if(ToolbarBehavior.SelectedCar != null && (cloneName != ToolbarBehavior.SelectedCar.name || CloneCar == null) )
		{
			if(cloneName!=null && cloneName != ToolbarBehavior.SelectedCar.name)
			{
				Destroy(CloneCar);
			}

			originCar = ToolbarBehavior.SelectedCar;
			
			Debug.Log (originCar.name + "clone created");
			
			CloneCar = Instantiate(originCar) as GameObject;
			
			cloneName = originCar.name;
			
			CloneCar.transform.parent = workspace.transform;
			
			CloneCar.name = "workspace "+ cloneName;
			
			//Rendering the Clone car
			CloneCar.SetActive(false);
			showFlag = false;
			
			CloneCar.transform.GetComponent<Selection>().initial();
			
			//Remove box collider of workspace car and rigidbody
			//					CloneCar.collider.isTrigger = false;
			//					CloneCar.transform.GetComponent<Rigidbody>
			Destroy(CloneCar.collider);
			Destroy(CloneCar.rigidbody);
			//			Destroy(CloneCar.transform.GetComponent<Selection>().getInner);
			//			Destroy(CloneCar.transform.GetComponent<Selection>().getOuter);
			Component.Destroy(CloneCar.GetComponent<Selection>()); // disable selection for workspace car
			
			//Place at the center position
			CloneCar.transform.position = workspace.transform.position + new Vector3(0,0,0); 
			//
			CloneCar.transform.eulerAngles = originCar.transform.eulerAngles;
			//Scale relative to the parent imagine target 
			CloneCar.transform.localScale = originCar.transform.localScale*5;
		}
		
		if(Tracking &&  ToolbarBehavior.workspace)
		{
			if(ToolbarBehavior.SelectedCar!=null && CloneCar != null && ToolbarBehavior.SelectedCar.name == cloneName){
				CloneCar.SetActive(true);
				showFlag = true;
			}
			else{
				CloneCar.SetActive(false);
				showFlag = false;
			}
		}
		
	}
}
