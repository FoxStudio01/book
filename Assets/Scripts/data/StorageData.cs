using System.Collections.Generic;
using UnityEngine;


public struct Storage
{
    public string sID;
    public string sManager;
    public string sName;
    public string sPhone;
    public string sAddress;
    public double sCost;
    public string sNotes;
}

public class StorageData
{
    public static List< Storage > data = new List<Storage>();

    public static void loadData()
    {
        phpSQL.instance.php( "SELECT * FROM .storages" , onLoad );
    }

    public static string getName( string id )
    {
        for ( int i = 0 ; i < data.Count ; i++ )
        {
            if ( data[ i ].sID == id )
            {
                return data[ i ].sName;
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

            Storage p = new Storage();

            p.sID = pa[ 1 ];
            p.sManager = pa[ 2 ];
            p.sName = pa[ 3 ];
            p.sPhone = pa[ 4 ];
            p.sAddress = pa[ 5 ];
            p.sCost = double.Parse( pa[ 6 ] );
            p.sNotes = pa[ 7 ];

            data.Add( p );
        }

        StorageUIHandler.instance.updateData();
        StockUIHandler.instance.updateData();
        SaleUIHandler.instance.updateData();
    }

}

