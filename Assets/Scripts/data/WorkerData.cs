using System.Collections.Generic;
using UnityEngine;


public struct Worker
{
    public string wID;
    public string wDepartmentID;
    public string wPostType;

    public string wName;

    public int wAge;
    public string wGender;
    public double wPay;

    public string wPhone;
    public string wAddress;
    public string wNotes;
}

public class WorkerData
{
    public static List<Worker> data = new List<Worker>();

    public static void loadData()
    {
        phpSQL.instance.php( "SELECT * FROM .workers" , onLoad );
    }

    public static string getName( string id )
    {
        for ( int i = 0 ; i < data.Count ; i++ )
        {
            if ( data[ i ].wID == id )
            {
                return data[ i ].wName;
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

            Worker p = new Worker();

            p.wID = pa[ 1 ];
            p.wDepartmentID = pa[ 2 ];
            p.wPostType = pa[ 3 ];
            p.wName = pa[ 4 ];

            p.wAge = int.Parse( pa[ 5 ] );
            p.wGender = pa[ 6 ];
            p.wPay = double.Parse( pa[ 7 ] );

            p.wPhone = pa[ 8 ];
            p.wAddress = pa[ 9 ];
            p.wNotes = pa[ 10 ];

            data.Add( p );
        }

        WorkerUIHandler.instance.updateData();
        DepartmentUIHandler.instance.updateData();
        StorageUIHandler.instance.updateData();
    }

}

