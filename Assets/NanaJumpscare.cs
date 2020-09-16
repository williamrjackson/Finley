using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Wrj;

public class NanaJumpscare : MonoBehaviour
{
    public Transform spriteObject;
    public Vector3 initScale;
    public Vector3 targetScale;
    public AudioClip audio;
    public Utils.MapToCurve manip;
    public AudioSource audioSource;
    
    public void JumpScare()
    {
        spriteObject.localScale = initScale;
        spriteObject.gameObject.SetActive(true);
        manip.Scale(spriteObject, targetScale, .5f);
        audioSource.PlayOneShot(audio);
    }
    public void ResetJumpScare()
    {
        spriteObject.gameObject.SetActive(false);
    }
}
