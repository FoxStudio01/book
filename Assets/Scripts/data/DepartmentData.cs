using System.Collections.Generic;
using UnityEngine;


public struct Department
{
    public string dID;
    public string dManager;
    public string dName;
    public string dSellType;
    public string dPhone;
    public string dAddress;
    public double dCost;
    public string dNotes;
}

public class DepartmentData
{
    public static List< Department > data = new List< Department >();

    public static void loadData()
    {
        phpSQL.instance.php( "SELECT * FROM .department" , onLoad );
    }

    public static string getName( string id )
    {
        for ( int i = 0 ; i < data.Count ; i++ )
        {
            if ( data[ i ].dID == id )
            {
                return data[ i ].dName;
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

            Department p = new Department();

            p.dID = pa[ 1 ];
            p.dManager = pa[ 2 ];
            p.dName = pa[ 3 ];
            p.dSellType = pa[ 4 ];
            p.dPhone = pa[ 5 ];
            p.dAddress = pa[ 6 ];
            p.dCost = double.Parse( pa[ 7 ] );
            p.dNotes = pa[ 8 ];

            data.Add( p );
        }

        DepartmentUIHandler.instance.updateData();
        WorkerUIHandler.instance.updateData();
    }

}
