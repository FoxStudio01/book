using UnityEngine;


public class BookUIComponentRow : MonoBehaviour
{
    UIToggle Checkbox;

    static int count = 9;

    UIPanel Panel;
    UISprite SlicedSprite3;

    UILabel editor0;
    public UIPopupList editor1;
    public UIPopupList editor2;
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
        sprite[ 2 ] = transform.Find( "editor" + 2 ).GetComponent<UISprite>();

        editor1 = transform.Find( "editor" + 1 ).GetComponent<UIPopupList>();
        editor2 = transform.Find( "editor" + 2 ).GetComponent<UIPopupList>();

        for ( int i = 3 ; i < count ; i++ )
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

        for ( int i = 3 ; i < count ; i++ )
        {
            editor[ i ].enabled = b;
            editor[ i ].transform.GetComponent<BoxCollider>().enabled = b;
        }
    }

    public void setCheck( bool b )
    {
        Checkbox.value = b;
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

    public void setData( Book d )
    {
        Checkbox.value = false;

        editor0.text = d.bID;

        editor1.Clear();
        for ( int i = 0 ; i < PublisherData.data.Count ; i++ )
        {
            string str = PublisherData.data[ i ].pID + "(" + PublisherData.data[ i ].pName + ")";
            editor1.AddItem( str , PublisherData.data[ i ].pID );
        }
        editor1.value = d.bPublisherID + "(" + PublisherData.getName( d.bPublisherID ) + ")";

        editor2.Clear();
        for ( int i = 0 ; i < BookTypeData.data.Count ; i++ )
        {
            string str = BookTypeData.data[ i ].btID + "(" + BookTypeData.data[ i ].btName + ")";
            editor2.AddItem( str , BookTypeData.data[ i ].btID );
        }
        editor2.value = d.bType + "(" + BookTypeData.getName( d.bType ) + ")";

        editor[ 3 ].value = d.bName;
        editor[ 4 ].value = d.bFormat;
        editor[ 5 ].value = d.bCost.ToString();
        editor[ 6 ].value = d.bRetail.ToString();
        editor[ 7 ].value = d.bWholesale.ToString();
        editor[ 8 ].value = d.bNotes;
    }


}

