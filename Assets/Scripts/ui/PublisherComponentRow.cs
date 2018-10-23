using UnityEngine;

public class PublisherComponentRow : MonoBehaviour
{
    UILabel editor0;
    public UIInput editor1;
    public UIInput editor2;
    public UIInput editor3;
    public UIInput editor4;

    UIToggle Checkbox;

    static int count = 5;

    UIPanel Panel;
    UISprite SlicedSprite3;

    UISprite[] sprite = new UISprite[ count ];
    float[] spriteWidth = new float[ count ];

    UITable table;

    float width = 0.0f;

    void Awake()
    {
        SlicedSprite3 = transform.parent.GetComponent<UISprite>();
        if ( SlicedSprite3 == null )
            SlicedSprite3 = transform.parent.parent.parent.GetComponent<UISprite>();

        Checkbox = transform.Find( "Checkbox" ).GetComponent< UIToggle >();

        editor0 = transform.Find( "editor0" ).GetComponentInChildren< UILabel >();
        editor1 = transform.Find( "editor1" ).GetComponentInChildren< UIInput >();
        editor2 = transform.Find( "editor2" ).GetComponentInChildren< UIInput >();
        editor3 = transform.Find( "editor3" ).GetComponentInChildren< UIInput >();
        editor4 = transform.Find( "editor4" ).GetComponentInChildren< UIInput >();

        sprite[ 0 ] = transform.Find( "editor0" ).GetComponent< UISprite >();
        sprite[ 1 ] = transform.Find( "editor1" ).GetComponent< UISprite >();
        sprite[ 2 ] = transform.Find( "editor2" ).GetComponent< UISprite >();
        sprite[ 3 ] = transform.Find( "editor3" ).GetComponent< UISprite >();
        sprite[ 4 ] = transform.Find( "editor4" ).GetComponent< UISprite >();

        width = 0f;
        for ( int i = 0 ; i < count ; i++ )
        {
            spriteWidth[ i ] = sprite[ i ].width;
            width += spriteWidth[ i ];
        }

        table = GetComponent< UITable >();
    }

    public void enable( bool b )
    {
        Checkbox.transform.GetComponent< UIButton >().state = ( b ? UIButtonColor.State.Normal : UIButtonColor.State.Disabled );
//        Checkbox.enabled = false;
        editor1.enabled = b;
        editor2.enabled = b;
        editor3.enabled = b;
        editor4.enabled = b;

        Checkbox.transform.GetComponent< BoxCollider >().enabled = b;
        editor1.transform.GetComponent< BoxCollider >().enabled = b;
        editor2.transform.GetComponent< BoxCollider >().enabled = b;
        editor3.transform.GetComponent< BoxCollider >().enabled = b;
        editor4.transform.GetComponent< BoxCollider >().enabled = b;
    }

    public void setCheck( bool b )
    {
        if ( editor1.enabled )
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

    public void setData( Publisher d )
    {
        if ( d.pID == "P1" )
        {
            enable( false );
        }
        else
        {
            enable( true );
        }

        Checkbox.value = false;

        editor0.text = d.pID;
        editor1.value = d.pName;
        editor2.value = d.pPhone;
        editor3.value = d.pAddress;
        editor4.value = d.pNotes;
    }


}
