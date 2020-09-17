using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Wrj;

public class NanaJumpscare : MonoBehaviour
{
    public Transform spriteObject;
    public Vector3 initScale;
    public Vector3 targetScale;
    [Range(.5f, 2f)]
    public float duration = 1f;
    public AudioClip audio;
    public Utils.MapToCurve manip;
    public AudioSource audioSource;

    private void Start()
    {
        FishControl.instance.OnGameOver += JumpScare;
        FishControl.instance.OnRestart += ResetJumpScare;
    }
    public void JumpScare()
    {
        spriteObject.localScale = initScale;
        spriteObject.gameObject.SetActive(true);
        manip.Scale(spriteObject, targetScale, duration);
        audioSource.PlayOneShot(audio);
    }
    public void ResetJumpScare()
    {
        spriteObject.gameObject.SetActive(false);
    }
}
