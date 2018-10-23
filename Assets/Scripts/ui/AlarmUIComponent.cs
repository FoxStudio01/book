using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmUIComponent : MonoBehaviour
{

    UILabel label;

    void Awake()
    {
        label = transform.Find( "label" ).GetComponent< UILabel >();
    }

    public void setText( string str )
    {
        label.text = str;
    }

    public void resize()
    {

    }

    public void onTouch()
    {
        AlarmUIHandler.instance.UnShow();
    }

}

