using System.Collections.Generic;
using UnityEngine;


public struct Publisher
{
    public string pID;
    public string pName;
    public string pPhone;
    public string pAddress;
    public string pNotes;
}

public class PublisherData
{
    public static List< Publisher > data = new List< Publisher >();

    public static void loadData()
    {
        phpSQL.instance.php( "SELECT * FROM .publisher" , onLoad );
    }

    public static void onLoad( string d )
    {
        data.Clear();

        string[] a = d.Split( '{' );

        for ( int i = 1 ; i < a.Length ; i++ )
        {
            string[] pa = a[ i ].Replace( "}" , "" ).Split( ',' );

            Publisher p = new Publisher();

            p.pID = pa[ 1 ];
            p.pName = pa[ 2 ];
            p.pPhone = pa[ 3 ];
            p.pAddress = pa[ 4 ];
            p.pNotes = pa[ 5 ];

            data.Add( p );
        }

        PublisherUIHandler.instance.updateData();
        BookUIHandler.instance.updateData();

    }


    public static string getName( string id )
    {
        for ( int i = 0 ; i < data.Count ; i++ )
        {
            if ( data[ i ].pID == id )
            {
                return data[ i ].pName;
            }
        }

        return "";
    }

}
