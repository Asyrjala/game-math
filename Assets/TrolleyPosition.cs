using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrolleyPosition : MonoBehaviour
{
    private Transform crane;
    private Transform cable;
    private Transform hook;
    private Slider trolleyslider;
    private Slider cableslider;
    private float trolleydelta;
    private float hookdelta;

    public void Awake()
    {
        crane = GameObject.Find("Tower Crane").transform;
        cable = GameObject.Find("Cable").transform;
        hook = GameObject.Find("Hook").transform;
        trolleyslider = GameObject.Find("Trolley Slider").GetComponent<Slider>();
        cableslider = GameObject.Find("Cable Slider").GetComponent<Slider>();

    }


    void LateUpdate() //my original draft felt like parenting position but with extra steps, so I added even more steps so it's at least vectors originating from 0, 0, 0
    {
        trolleydelta = -22f + (trolleyslider.value) * 12f;
        hookdelta = 35f * cableslider.value+5f;
        transform.position = new Vector3(0, 0, 0);
        transform.rotation = crane.rotation; //these could all be set from the button but it would just be extra copypasting, this is effectively using crane rotation as a global rotation variable
        transform.Translate(trolleydelta, 41f, 0);
        cable.position = new Vector3(0, 0, 0);
        cable.rotation = crane.rotation;
        cable.localScale = new Vector3(cable.localScale.x, 2.4f * (1-cableslider.value), cable.localScale.z);
        cable.Translate(trolleydelta, 41f, 0);
        hook.position = new Vector3(0, 0, 0);
        hook.rotation = crane.rotation; 
        hook.Translate(trolleydelta, hookdelta, 0);
    }
}
