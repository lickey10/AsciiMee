﻿using UnityEngine;
using System.Collections;

public class SwitchScenes : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SwitchSceneToTakePicture()
    {
        Application.LoadLevel("camera");
    }
}
