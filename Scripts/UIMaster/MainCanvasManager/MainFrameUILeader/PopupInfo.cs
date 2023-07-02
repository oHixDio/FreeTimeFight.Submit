using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupInfo : MonoBehaviour
{
    Animation anim;

    void Awake()
    {
        anim = GetComponent<Animation>();
    }

    void OnEnable()
    {
        anim.Play();
    }
}
