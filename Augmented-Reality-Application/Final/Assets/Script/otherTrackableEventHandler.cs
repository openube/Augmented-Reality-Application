/*==============================================================================
Copyright (c) 2010-2013 Qualcomm Connected Experiences, Inc.
All Rights Reserved.
Confidential and Proprietary - Qualcomm Connected Experiences, Inc.
==============================================================================*/

using UnityEngine;

/// <summary>
/// A custom handler that implements the ITrackableEventHandler interface.
/// </summary>
/// 
/// Workspace
/// 
public class otherTrackableEventHandler : MonoBehaviour,
                                            ITrackableEventHandler
{
    #region PRIVATE_MEMBER_VARIABLES
 
    private TrackableBehaviour mTrackableBehaviour;

	/// <summary>
	/// This is for Coordinate System
//	/// </summary>
//	public static GameObject originCar;
//
//	public static GameObject CloneCar;
//
//	public GameObject Cube;
//	public GameObject Child;
//
//	public  string cloneName = "";
    #endregion // PRIVATE_MEMBER_VARIABLES

    #region UNTIY_MONOBEHAVIOUR_METHODS
    
    void Start()
    {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        
		if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }

    }
	
	void Update()
	{
//		if(Tracking &&  ToolbarBehavior.workspace){
//			if(ToolbarBehavior.SelectedCar != null)
//			{
//				// If car is already selected.
//				// Show the car on the workspace 
//				if(cloneName != ToolbarBehavior.SelectedCar.name || CloneCar == null)
//				{
//					originCar = ToolbarBehavior.SelectedCar;
//					
//					Debug.Log (originCar.name + "clone created");
//					
//					CloneCar = Instantiate(originCar) as GameObject;
//					
//					cloneName = originCar.name;
//					
//					CloneCar.transform.parent = this.transform;
//
//					CloneCar.name = cloneName + "workspace";
//
//					//Rendering the Clone car
//					CloneCar.renderer.enabled = true;
//					CloneCar.SetActive(true);
//					//
//					CloneCar.transform.GetComponent<Selection>().ShowOn();
//
//					//Remove box collider of workspace car
//					Destroy(CloneCar.collider);
//
//					//Place at the center position
//					CloneCar.transform.position = this.transform.position + new Vector3(0,0,0); 
//					//
//					CloneCar.transform.eulerAngles = originCar.transform.eulerAngles;
//					//Scale relative to the parent imagine target 
//					CloneCar.transform.localScale = originCar.transform.localScale*5;
//
//				}
//			}
//			else{
//				if(CloneCar!=null)
//				{
//					Destroy(CloneCar);
//				}
//			}
//		}
//		else{
//			if(CloneCar!=null)
//			{
//				Destroy(CloneCar);
//			}
//		}
	}
	
    #endregion // UNTIY_MONOBEHAVIOUR_METHODS



    #region PUBLIC_METHODS

    /// <summary>
    /// Implementation of the ITrackableEventHandler function called when the
    /// tracking state changes.
    /// </summary>
    public void OnTrackableStateChanged(
                                    TrackableBehaviour.Status previousStatus,
                                    TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            OnTrackingFound();
        }
        else
        {
            OnTrackingLost();
        }

    }

    #endregion // PUBLIC_METHODS



    #region PRIVATE_METHODS


    private void OnTrackingFound()
    {
        Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
        Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);

        // Enable rendering:
        foreach (Renderer component in rendererComponents)
        {
            component.enabled = true;
        }

        // Enable colliders:
        foreach (Collider component in colliderComponents)
        {
            component.enabled = true;
        }

        //Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");
		WorkSpaceManage.Tracking = true;
    }

                       



    private void OnTrackingLost()
    {
        Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
        Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);

        // Disable rendering:
        foreach (Renderer component in rendererComponents)
        {
            component.enabled = false;
        }

        // Disable colliders:
        foreach (Collider component in colliderComponents)
        {
            component.enabled = false;
        }

        //Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost");

		WorkSpaceManage.Tracking = false;


    }

    #endregion // PRIVATE_METHODS
}
