using System.Collections.Generic;
using UnityEngine;


public struct BookType
{
    public string btID;
    public string btName;
    public string btNotes;
}

public class BookTypeData
{
    public static List<BookType> data = new List<BookType>();

    public static void loadData()
    {
        phpSQL.instance.php( "SELECT * FROM .booktype" , onLoad );
    }

    public static void onLoad( string d )
    {
        data.Clear();

        string[] a = d.Split( '{' );

        for ( int i = 1 ; i < a.Length ; i++ )
        {
            string[] pa = a[ i ].Replace( "}" , "" ).Split( ',' );

            BookType p = new BookType();

            p.btID = pa[ 1 ];
            p.btName = pa[ 2 ];
            p.btNotes = pa[ 3 ];

            data.Add( p );
        }

        BookTypeUIHandler.instance.updateData();
        BookUIHandler.instance.updateData();
    }


    public static string getName( string id )
    {
        for ( int i = 0 ; i < data.Count ; i++ )
        {
            if ( data[ i ].btID == id )
            {
                return data[ i ].btName;
            }
        }

        return "";
    }
}

