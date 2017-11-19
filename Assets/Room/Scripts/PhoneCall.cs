using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneCall : MonoBehaviour {

    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("hl") || other.CompareTag("hr"))
        {
            SoundManager.PlaySound("StartRotaru");
            anim.SetTrigger("start");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("hl") || other.CompareTag("hr"))
        {
            SoundManager.PlaySound("EndRotary");
            anim.SetTrigger("end");
        }
    }
}
