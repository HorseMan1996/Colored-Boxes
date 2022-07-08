using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSound : MonoBehaviour
{
    [SerializeField] Animator playerAnime;
    bool work = true;
    Collider[] coll;
    Rigidbody[] rig;

    private void Awake()
    {
        work = true;
        coll = GetComponentsInChildren<Collider>();
        rig = GetComponentsInChildren<Rigidbody>();
        foreach (Collider col in coll)
        {
            col.enabled = false;
        }
        foreach (Rigidbody rb in rig)
        {
            rb.isKinematic = true;
        }
        foreach (Rigidbody rb in rig)
        {
            rb.angularVelocity = Vector3.zero;
        }
    }

    private void Update()
    {
        if (CharacterMove.dead && work)
        {
            work = false;
            Death();
        }
    }

    public void Death()
    {
        playerAnime.SetBool("dead", true);
        foreach (Collider col in coll)
        {
            col.enabled = true;
        }
        foreach (Rigidbody rb in rig)
        {
            rb.isKinematic = false;
        }

    }

    [SerializeField] AudioSource footStepSound;
    public void FootStepSound()
    {
        footStepSound.Play();
    }
}
