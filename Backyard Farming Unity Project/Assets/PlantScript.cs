using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantScript : MonoBehaviour
{
    public float initialCropTimer; // To enter the values from the editor.
    public float initialWaterTimer;
    public float potentialSellValue;
    public Material wiltedPlant;

    private int plantState; // Using an int to define plantstate so that i can increment it
    private float cropTimer; // The timers themselves
    private float waterTimer;
    private bool isWilted;
    private float sellValue;
    private int seedsDropped;

    void Start() // Initialize our variables
    {
        for (int i = 0; i < 3; i++)
        {
            this.transform.GetChild(i).gameObject.SetActive(false);
        }

        plantState = 0;
        cropTimer = initialCropTimer;
        waterTimer = initialWaterTimer;
        sellValue = potentialSellValue;
        seedsDropped = 3;
        isWilted = false;
    }

    void Update()
    {
        if (!isWilted)
        {
            cropTimer -= Time.deltaTime;
            waterTimer -= Time.deltaTime;
        }

        if ((cropTimer <= initialCropTimer / 2.0f) && (cropTimer > 0.0f)) // To scale the events to any length of time used.
        {
            plantState = 1;
            Debug.Log(plantState);
        }
        else if (cropTimer <= 0.0f)
        {
            plantState = 2;
            Debug.Log(plantState);
        }

        if (!isWilted)
        {
            Grow();
        }
        
        if(waterTimer <= 0)
        {
            Wilt();
        }
    }

    void waterPlant()
    {
        waterTimer = initialWaterTimer; // Resets water timer to prevent plant from wilting.
    }

    void Grow()
    {
        if (plantState == 0)
        {
            this.transform.GetChild(0).gameObject.SetActive(true);
        }
        
        if (plantState == 1)
        {
            this.transform.GetChild(1).gameObject.SetActive(true);
        }
        
        if (plantState == 2)
        {
            this.transform.GetChild(2).gameObject.SetActive(true);
        }
    }

    void Wilt()
    {
        for(int i = 0; i < 3; i++) //Change color and lower rewarded value
        {
            this.transform.GetChild(i).gameObject.GetComponent<Renderer>().material = wiltedPlant;
        }
        sellValue = sellValue * 0.1f;
        seedsDropped = 1;
        isWilted = true;
    }
}
