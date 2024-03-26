using System.Collections;
using System.Collections.Generic;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine;
using Unity.VisualScripting;

public class SetPortal : MonoBehaviour
{
    public float UpSpeed;
    Vector3 Base= new Vector3(1.92f,0.1f,0.2f);
    
    public void Start() 
    {
        this.GetComponent<Transform>().localScale=Base;
    }

    void Update() 
    {
        Vector3 CurrentScale= this.GetComponent<Transform>().localScale;

        if(CurrentScale.y<3.74f)
        {
            CurrentScale.y+=UpSpeed*Time.deltaTime;
            this.GetComponent<Transform>().localScale=CurrentScale;
        }

        else
        {
            CurrentScale.y=3.74f;
            this.GetComponent<Transform>().localScale=CurrentScale;
        }
    }
}
