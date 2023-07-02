using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ADUI : MonoBehaviour
{
    [SerializeField] GameObject topAD;
    [SerializeField] GameObject bottomAD;

    public void ShowAD()
    {
        topAD.SetActive(true);
        bottomAD.SetActive(true);
    }
}
