using UnityEngine;
using System.Collections;


// Attached to every car object

public class Selection : MonoBehaviour {

 	public static GameObject selectedCar = null;
	public GameObject toolbar_front;
	public GameObject toolbar_back;
	
	private bool showFlag = false;
	//private bool coordinateSystem = false;
	
	public GameObject car;

	public GameObject InnerLoop;
	public GameObject OutLoop;

	//Set default 
	public GameObject i;
	public GameObject o;

	public static GameObject ARcamera;

	public GameObject originParent;

	public Vector3 originPosDif; // relative to its parent
	public Vector3 originOri;

	// Use this for initialization
	void Start () {

		i.SetActive(false);
		o.SetActive(false);

		car = this.gameObject;
		ARcamera = GameObject.Find("ARCamera");


		//Copy Loops
		InnerLoop = Instantiate(i) as GameObject;
		OutLoop = Instantiate(o) as GameObject;
			
		InnerLoop.transform.parent = car.transform;
		OutLoop.transform.parent = car.transform;

		InnerLoop.transform.position  = car.transform.position + new Vector3(0,0,0);
		OutLoop.transform.position = car.transform.position + new Vector3(0,0,0);


		//Record original position and orientation
		originParent = GameObject.Find("Ground");

	}

	
	// Update is called once per frame
	void Update () {
		if(car.name.Contains("Clone")){

		}
		else{
			if(showFlag)
			{
				InnerLoop.SetActive(true);
				OutLoop.SetActive(true);
			}
			else{
				InnerLoop.SetActive(false);
				OutLoop.SetActive(false);
			}
		}
			
	}
	public void setCoordinate()
	{
		if(selectedCar == this.car)
		{
			this.car.transform.parent = ARcamera.transform;
		}
	}

	public void resetCoordinate()
	{
		this.car.transform.parent = originParent.transform;
	}


	void OnTriggerEnter(Collider other)
	{
			//Only Toolbar could Trigger
		if(other.name == "Tool")
		{
			//Debug.Log();
			
			if(selectedCar == null)
			{
				Debug.Log (car.name + " is selected");
				selectedCar = this.car;
				
				//set toolbar's selection status to true
				GameObject.Find("Tool").transform.GetComponent<ToolbarBehavior>().setSelect(car);
				//
				GameObject.Find ("ARCamera").transform.GetComponent<CameraBehavior>().setObject(car);
				
				ShowOn();
			}
			else if(selectedCar == this.car) 
			{
				Debug.Log (car.name + " is deselected");
				// Reset selectedCar
				selectedCar = null;
				
				//Deselect toolbar
				GameObject.Find("Tool").transform.GetComponent<ToolbarBehavior>().deselect();
				GameObject.Find ("ARCamera").transform.GetComponent<CameraBehavior>().desetObject();
				
				ShowOff();
			}
			toolbar_front.transform.GetComponent<Stable>().reset();
		}
		else if(other.name == "DeleteTool")
		{
			//Delete this car
			Destroy(this.car);
			toolbar_back.transform.GetComponent<Stable>().reset();
		}

	}

	void OnTriggerExit()
	{

	}
	void OnTriggerStay()
	{

	}
	public void ShowOn()
	{
		showFlag = true;
	}
	public void ShowOff()
	{
		showFlag = false;
	}
	public void reset()
	{

		transform.parent = originParent.transform;
		//Reset to the original status
		transform.position = originParent.transform.position + originPosDif;
		transform.eulerAngles = originOri;
		//////////////////
		
		ShowOff();
		GameObject.Find("Tool").transform.GetComponent<ToolbarBehavior>().deselect();
		GameObject.Find ("ARCamera").transform.GetComponent<CameraBehavior>().desetObject();

	}

	public void translate(Vector3 translation)
	{
		transform.position = translation + transform.position;
	}
	public void rotate(Vector3 angle)
	{
		transform.eulerAngles =  transform.eulerAngles - angle;
	}

	public void scale(bool zoom_in)
	{
		float sign = zoom_in?0.1f:-0.1f;

		transform.localScale = transform.localScale * (1.0f+sign);
	}

	public GameObject getInner()
	{
		return InnerLoop;
	}
	public GameObject getOuter()
	{
		return OutLoop;
	}

	public void initial()
	{
		originPosDif = transform.position - originParent.transform.position;
		originOri = transform.eulerAngles;
		Debug.Log("set inital " + this.car.name);

		InnerLoop.SetActive(false);
		OutLoop.SetActive(false);
		showFlag = false;
	}
}
