using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loginUIHandler : GameUIHandler< loginUIHandler >
{
    LoginUIComponent component;

    void Awake()
    {
        mInstance = this;
    }

    public override void onRelease()
    {
        component = null;
    }
    public override void onInit()
    {
        component = uiObject.GetComponentInChildren< LoginUIComponent >();
    }
    public override void onOpen()
    {
    }
    public override void onClose()
    {
    }

    public override void onResize()
    {
    }
}

