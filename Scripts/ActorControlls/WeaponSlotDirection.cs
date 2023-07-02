using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSlotDirection : MonoBehaviour
{
    [SerializeField] Transform animator;

    private void Update()
    {
        this.transform.localScale = animator.localScale;
    }
}
