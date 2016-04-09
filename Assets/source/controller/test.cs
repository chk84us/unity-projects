using UnityEngine;
using System.Collections;
using utils;

public class test : MonoBehaviour {

	// Use this for initialization
	void Start () {
		JsonIo io = new JsonIo ();
		io.SerializeData ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
