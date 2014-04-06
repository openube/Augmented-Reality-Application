using UnityEngine;
using System.Collections;

public class Stable : MonoBehaviour {

	public Transform parent;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}

	public void reset()
	{
		this.gameObject.transform.position = parent.transform.position + new Vector3(0,0,0);
		this.gameObject.transform.eulerAngles = parent.transform.eulerAngles + new Vector3(0,0,0);
	}
	
}
