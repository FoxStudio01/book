using System.Collections.Generic;
using UnityEngine;


public struct PostType
{
    public string ptID;
    public string ptName;
    public string ptNotes;
}

public class PostTypeData
{
    public static List< PostType > data = new List< PostType >();

    public static void loadData()
    {
        phpSQL.instance.php( "SELECT * FROM .posttype" , onLoad );
    }

    public static string getName( string id )
    {
        for ( int i = 0 ; i < data.Count ; i++ )
        {
            if ( data[ i ].ptID == id )
            {
                return data[ i ].ptName;
            }
        }

        return "";
    }

    public static void onLoad( string d )
    {
        data.Clear();

        string[] a = d.Split( '{' );

        for ( int i = 1 ; i < a.Length ; i++ )
        {
            string[] pa = a[ i ].Replace( "}" , "" ).Split( ',' );

            PostType p = new PostType();

            p.ptID = pa[ 1 ];
            p.ptName = pa[ 2 ];
            p.ptNotes = pa[ 3 ];

            data.Add( p );
        }

        PostTypeUIHandler.instance.updateData();
    }

}
