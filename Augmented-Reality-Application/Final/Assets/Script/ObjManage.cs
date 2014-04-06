using UnityEngine;
using System.Collections;

public class ObjManage : MonoBehaviour {

	public GameObject modelCar;
	public GameObject CreateCar;

	public GameObject Ground;
	public GameObject workspace;

	public int ID = 0;
	public static bool coordinate = false;
	public float height = 0.0f;

	// Use this for initialization
	void Start () {
		Ground = GameObject.Find("Ground");
		workspace = GameObject.Find ("OtherSys");
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = workspace.transform.position + new Vector3(0,0,0);
	}

	void OnTriggerEnter(Collider other)
	{
		if(WorkSpaceManage.showFlag)
		{
			if(other.name == "Tool")
			{
					modelCar = ToolbarBehavior.SelectedCar;
					
					height = modelCar.transform.localScale.y * 1.5f + height;

					//modelCar = GameObject.Find("ClassicCar");
					CreateCar = Instantiate(modelCar) as GameObject;

					CreateCar.transform.parent = Ground.transform;

					//For easy separate those cars
					// Put above the original car
					CreateCar.transform.position = Ground.transform.position + new Vector3(ID, 0, 0);

					CreateCar.transform.eulerAngles = modelCar.transform.eulerAngles;
					
					CreateCar.transform.localScale = modelCar.transform.localScale;

					CreateCar.name = "new " + CreateCar.name + ID.ToString();

					//Add script selection to the new car
					//CreateCar.AddComponent("Selection");
					
					//Don't render the circle

					CreateCar.transform.GetComponent<Selection>().initial();

					ID++;

					Debug.Log ("new "+ CreateCar.name + "created");


			}
			else if(other.name == "DeleteTool") // back side of the car as the trigger for coordinate system
			{
				if(!coordinate){
					Debug.Log ("Coordinate System");
					//If the back side of card trigger the workspace object
					// Then set in coordinatesystem
					ToolbarBehavior.SelectedCar.transform.GetComponent<Selection>().setCoordinate();
					coordinate = true;
				}
				else{
					Debug.Log ("Original System");
					ToolbarBehavior.SelectedCar.transform.GetComponent<Selection>().resetCoordinate();
					coordinate = false;
				}
			}
		}

	}
}
