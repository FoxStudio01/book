using UnityEngine;

public class WorkerUIComponentRow : MonoBehaviour
{
    UIToggle Checkbox;

    static int count = 10;

    UIPanel Panel;
    UISprite SlicedSprite3;

    UILabel editor0;
    public UIPopupList editor1;
    public UIPopupList editor2;
    public UIPopupList editor3;
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
        sprite[ 3 ] = transform.Find( "editor" + 3 ).GetComponent<UISprite>();

        editor1 = transform.Find( "editor" + 1 ).GetComponent<UIPopupList>();
        editor2 = transform.Find( "editor" + 2 ).GetComponent<UIPopupList>();
        editor3 = transform.Find( "editor" + 3 ).GetComponent<UIPopupList>();

        for ( int i = 4 ; i < count ; i++ )
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

        for ( int i = 4 ; i < count ; i++ )
        {
            editor[ i ].enabled = b;
            editor[ i ].transform.GetComponent<BoxCollider>().enabled = b;
        }
    }

    public void setCheck( bool b )
    {
        if ( editor[ 4 ].enabled )
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

    public void setData( Worker d )
    {
        if ( d.wID == "W1" )
        {
            enable( false );
        }
        else
        {
            enable( true );
        }

        Checkbox.value = false;

        editor0.text = d.wID;

        editor1.Clear();
        for ( int i = 0 ; i < DepartmentData.data.Count ; i++ )
        {
            string str = DepartmentData.data[ i ].dID + "(" + DepartmentData.data[ i ].dName + ")";
            editor1.AddItem( str , DepartmentData.data[ i ].dID );
        }
        editor1.value = d.wDepartmentID + "(" + DepartmentData.getName( d.wDepartmentID ) + ")";

        editor2.Clear();
        for ( int i = 0 ; i < PostTypeData.data.Count ; i++ )
        {
            string str = PostTypeData.data[ i ].ptID + "(" + PostTypeData.data[ i ].ptName + ")";
            editor2.AddItem( str , PostTypeData.data[ i ].ptID );
        }
        editor2.value = d.wPostType + "(" + PostTypeData.getName( d.wPostType ) + ")";

        editor3.Clear();
        editor3.AddItem( Localization.Get( "gender1" ) , Localization.Get( "gender1" )  );
        editor3.AddItem( Localization.Get( "gender0" ) , Localization.Get( "gender0" ) );
        editor3.value = d.wGender;

        editor[ 4 ].value = d.wName;
        editor[ 5 ].value = d.wAge.ToString();
        editor[ 6 ].value = d.wPay.ToString();
        editor[ 7 ].value = d.wPhone;
        editor[ 8 ].value = d.wAddress;
        editor[ 9 ].value = d.wNotes;
    }


}
