using UnityEngine;

public class PostTypeUIComponentRow : MonoBehaviour
{
    UILabel editor0;
    public UIInput editor1;
    public UIInput editor2;

    UIToggle Checkbox;

    static int count = 3;

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

        Checkbox = transform.Find( "Checkbox" ).GetComponent<UIToggle>();

        editor0 = transform.Find( "editor0" ).GetComponentInChildren<UILabel>();
        editor1 = transform.Find( "editor1" ).GetComponentInChildren<UIInput>();
        editor2 = transform.Find( "editor2" ).GetComponentInChildren<UIInput>();

        sprite[ 0 ] = transform.Find( "editor0" ).GetComponent<UISprite>();
        sprite[ 1 ] = transform.Find( "editor1" ).GetComponent<UISprite>();
        sprite[ 2 ] = transform.Find( "editor2" ).GetComponent<UISprite>();

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
        //        Checkbox.enabled = false;
        editor1.enabled = b;
        editor2.enabled = b;

        Checkbox.transform.GetComponent<BoxCollider>().enabled = b;
        editor1.transform.GetComponent<BoxCollider>().enabled = b;
        editor2.transform.GetComponent<BoxCollider>().enabled = b;
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

    public void setData( PostType d )
    {
        if ( d.ptID == "PT1" )
        {
            enable( false );
        }
        else
        {
            enable( true );
        }

        Checkbox.value = false;

        editor0.text = d.ptID;
        editor1.value = d.ptName;
        editor2.value = d.ptNotes;
    }


}
