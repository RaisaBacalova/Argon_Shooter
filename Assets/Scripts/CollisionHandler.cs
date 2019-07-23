using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour {

    [SerializeField] float levelLoadDelay = 1f;
    [SerializeField] GameObject deathFX;

   // bool setActive = false;
	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}


    private void OnTriggerEnter(Collider other)
    {
        
        deathFX.SetActive(true);
        StartDeathSequence();
        Invoke("ReloadLevel", levelLoadDelay);
    }

    private void StartDeathSequence()
    {
        
        SendMessage("OnPlayerDeath");

    }

    private void ReloadLevel()
    {
        SceneManager.LoadScene(1);
    }
}
