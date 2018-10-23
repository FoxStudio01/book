using UnityEngine;

public class StockUIComponentRow : MonoBehaviour
{
    UIToggle Checkbox;

    static int count = 5;

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

    public void setData( Stock d )
    {
        editor1.enabled = false;
        editor1.transform.GetComponent<BoxCollider>().enabled = false;

        editor2.enabled = false;
        editor2.transform.GetComponent<BoxCollider>().enabled = false;

        editor[ 3 ].enabled = false;
        editor[ 3 ].transform.GetComponent<BoxCollider>().enabled = false;

        Checkbox.value = false;

        editor0.text = d.stIndex.ToString();

        editor1.Clear();
        for ( int i = 0 ; i < BookData.data.Count ; i++ )
        {
            string str = BookData.data[ i ].bID + "(" + BookData.data[ i ].bName + ")";
            editor1.AddItem( str , BookData.data[ i ].bID );
        }
        editor1.value = d.stBookID + "(" + BookData.getName( d.stBookID ) + ")";

        editor2.Clear();
        for ( int i = 0 ; i < StorageData.data.Count ; i++ )
        {
            string str = StorageData.data[ i ].sID + "(" + StorageData.data[ i ].sName + ")";
            editor2.AddItem( str , StorageData.data[ i ].sID );
        }
        editor2.value = d.stStorageID + "(" + StorageData.getName( d.stStorageID ) + ")";

        editor[ 3 ].value = d.stStorageNum.ToString();
        editor[ 4 ].value = d.stNotes;
    }


}
