using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PortalRaycast: MonoBehaviour
{
    [SerializeField]
    public ARRaycastManager aRRaycastManager;
    private List<ARRaycastHit> hits =new List<ARRaycastHit>();
    public AudioSource audioSource;
    public AudioClip audioClip;
  


    GameObject space;
    GameObject CheckObj;   

    public void set(GameObject gameObject)
    {
        this.space=gameObject;
        CheckObj=null;
    } 

    void NotCount()
    {
        return;
    }

    void touch()
    {
            Vector2 TouchPoint= Input.GetTouch(0).position;
            
            if(IsPointOverUIObject(TouchPoint))
            {
                return;
            }

            if(aRRaycastManager.Raycast(TouchPoint,hits,TrackableType.PlaneWithinPolygon))
            {
                Pose hitPose= hits[0].pose;
                if(CheckObj==null)
                {
                    Transform SetPosition=space.transform.Find("SetPoint").transform;          
                    Quaternion SetRotation= Quaternion.Euler(0,180f,0);
                    CheckObj=Instantiate(space,hitPose.position+SetPosition.position,SetRotation);
                    audioSource.volume=0.7f;
                    audioSource.Play();
                }
            }
    }

    bool IsPointOverUIObject(Vector2 pos)
    {
        PointerEventData eventDataCurPosition =new PointerEventData(EventSystem.current);
        eventDataCurPosition.position=pos;
        List<RaycastResult> results= new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurPosition,results);
        return results.Count>1;
    }

    
    void Update()
    {
        
        if(Input.touchCount==0) NotCount();
        if(Input.touchCount==1) 
        {
            touch();
        }
    }
}
