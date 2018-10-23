using UnityEngine;

public class StorageUIComponentRow : MonoBehaviour
{
    UIToggle Checkbox;

    static int count = 7;

    UIPanel Panel;
    UISprite SlicedSprite3;

    UILabel editor0;
    public UIPopupList editor1;
    public UIInput[] editor = new UIInput[ count ];
    UISprite[] sprite = new UISprite[ count ];
    float[] spriteWidth = new float[ count ];

    UITable table;

    float width = 0.0f;

    void Awake()
    {
        SlicedSprite3 = transform.parent.GetComponent<UISprite>();
        if ( SlicedSprite3 == null )
            SlicedSprite3 = transform.parent.parent.parent.GetComponent<UISprite>();

        Checkbox = transform.Find( "Checkbox" ).GetComponent<UIToggle>();

        editor0 = transform.Find( "editor0" ).GetComponentInChildren<UILabel>();
        sprite[ 0 ] = transform.Find( "editor" + 0 ).GetComponent<UISprite>();
        sprite[ 1 ] = transform.Find( "editor" + 1 ).GetComponent<UISprite>();

        editor1 = transform.Find( "editor" + 1 ).GetComponent<UIPopupList>();

        for ( int i = 2 ; i < count ; i++ )
        {
            editor[ i ] = transform.Find( "editor" + i ).GetComponentInChildren<UIInput>();
            sprite[ i ] = transform.Find( "editor" + i ).GetComponent<UISprite>();
        }

        width = 0f;
        for ( int i = 0 ; i < count ; i++ )
        {
            spriteWidth[ i ] = sprite[ i ].width;
            width += spriteWidth[ i ];
        }

        table = GetComponent<UITable>();
    }

    public void enable( bool b )
    {
        Checkbox.transform.GetComponent<UIButton>().state = ( b ? UIButtonColor.State.Normal : UIButtonColor.State.Disabled );
        Checkbox.transform.GetComponent<BoxCollider>().enabled = b;

        for ( int i = 2 ; i < count ; i++ )
        {
            editor[ i ].enabled = b;
            editor[ i ].transform.GetComponent<BoxCollider>().enabled = b;
        }
    }

    public void setCheck( bool b )
    {
        if ( editor[ 2 ].enabled )
        {
            Checkbox.value = b;
        }
    }

    public bool check()
    {
        return Checkbox.value;
    }

    public string id()
    {
        return editor0.text;
    }

    public void resize()
    {
        float scale = ( SlicedSprite3.width - 20 - count * 3 ) / ( width + 44.0f );

        if ( scale > 1.0f )
        {
            for ( int i = 0 ; i < count ; i++ )
            {
                sprite[ i ].width = (int)( spriteWidth[ i ] * scale );
            }
        }

        table.repositionNow = true;
    }

    public void setData( Storage d )
    {
        if ( d.sID == "S1" || d.sID == "L1" )
        {
            enable( false );
        }
        else
        {
            enable( true );
        }

        Checkbox.value = false;

        editor0.text = d.sID;

        editor1.Clear();
        for ( int i = 0 ; i < WorkerData.data.Count ; i++ )
        {
            string str = WorkerData.data[ i ].wID + "(" + WorkerData.data[ i ].wName + ")";
            editor1.AddItem( str , WorkerData.data[ i ].wID );
        }

        editor1.value = d.sManager + "(" + WorkerData.getName( d.sManager ) + ")";

        editor[ 2 ].value = d.sName;
        editor[ 3 ].value = d.sPhone;
        editor[ 4 ].value = d.sAddress;
        editor[ 5 ].value = d.sCost.ToString();
        editor[ 6 ].value = d.sNotes;
    }


}

