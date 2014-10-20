using UnityEngine;
using System.Collections;

public class aspectFit : MonoBehaviour {

	// Use this for initialization
	void Start () {

        transform.localScale = new Vector3(Camera.main.aspect, 1, 1);
        Debug.Log(Camera.main.aspect);
	}
	
	// Update is called once per frame
	void Update () {


	}
}
