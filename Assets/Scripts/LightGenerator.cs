using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LightGenerator : MonoBehaviour {

    public Light myLight;
    public Material skybox;

   /* //Range Variables
    bool changeRange = false;
    public float rangeSpeed = 1.0f;
    public float maxRange = 10.0f;*/

    //Intensity Variables
    public bool changeIntensity = false;
    public float intensitySpeed = 1.0f;
    public float maxIntensity = 3f;
    //public float minIntensity = 0.1f;

    //Color Variables

    //Skybox Variables
    public bool changeSunSize = false;
    public float sizeSpeed = 1.0f;
    public float maxSize = 1f;
    //public bool repeatSize = false;

    public bool changeThickeness = false;
    public float thicknessSpeed = 1f;
    public float maxThickness = 5f;
   // public bool repeatThickness = false;


    float startTime;
  

    // Use this for initialization
    void Start () {
       myLight = GetComponent<Light>();
        startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        if (changeIntensity)
        {
           myLight.intensity = Mathf.PingPong(Time.time * intensitySpeed, maxIntensity);
        }


        if (changeThickeness)
        {
            RenderSettings.skybox.SetFloat("_AtmosphereThickness", Mathf.PingPong(Time.time * thicknessSpeed, maxThickness));
            
        }

       // ChangeSunSize();
        //Invoke("ChangeSunSize", 10f);
    }

   /* private void ChangeSunSize()
    {
       
        //Invoke("changeSunSize", 3f);
     
     
        RenderSettings.skybox.SetFloat("_SunSize", Mathf.PingPong(Time.time * sizeSpeed, maxSize));

    }*/
}
