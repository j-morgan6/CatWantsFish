using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anim : MonoBehaviour
{
    public Animator animation;
    // Update is called once per frame
    void Update()
    {
     animation.SetFloat("Vertical", Input.GetAxis("Vertical"));
     animation.SetFloat("horizontal", Input.GetAxis("Horizontal"));   
    }
}
