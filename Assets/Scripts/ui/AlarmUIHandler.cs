using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmUIHandler : GameUIHandler< AlarmUIHandler >
{
    AlarmUIComponent component;

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
        component = uiObject.GetComponent< AlarmUIComponent >();
    }
    public override void onOpen()
    {
    }
    public override void onClose()
    {
    }

    public void alarm( string str )
    {
        Show();

        component.setText( str );
    }

    public void alarmLocal( string str )
    {
        Show();

        component.setText( Localization.Get( str ) );
    }

    public override void onResize()
    {
        if ( component == null )
            return;

        component.resize();
    }

}

