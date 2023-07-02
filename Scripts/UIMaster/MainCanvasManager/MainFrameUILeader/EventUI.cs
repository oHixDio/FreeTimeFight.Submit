using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventUI : MonoBehaviour
{
    [SerializeField] GameObject Rightpanel;
    [SerializeField] GameObject Leftpanel;

    

    public void RightPanelDown()
    {
        UIMaster.instance.Actor.IsRight = true;
        if (!UIMaster.instance.Actor.IsMove && UIMaster.instance.Actor.Enemy != null)
        {
            UIMaster.instance.Actor.ShortingAttackDelay(0.01f);
        }
    }
    public void RightPanelUp()
    {
        UIMaster.instance.Actor.IsRight = false;
    }

    public void LeftPanelDown()
    {
        UIMaster.instance.Actor.IsLeft = true;
        if (!UIMaster.instance.Actor.IsMove && UIMaster.instance.Actor.Enemy != null)
        {
            UIMaster.instance.Actor.ShortingAttackDelay(0.01f);
        }
    }
    public void LeftPanelUp()
    {
        UIMaster.instance.Actor.IsLeft = false;
    }
}
