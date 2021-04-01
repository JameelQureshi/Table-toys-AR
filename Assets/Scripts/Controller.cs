using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public Alogo AlogoREF;

    int[] LongtestRUN = { 2, 2, 3, 3, 4, 4, 4, 5, 5, 5, 6, 6, 6, 6 };

    int[] DemoPlay1and2 = { 2, 2 };

    public int threshold = 0;

    public static int indexerForLongrunTest = 0;


    public void StartComleteGamePlay()
    {
        if (indexerForLongrunTest < 0)
        {
            indexerForLongrunTest = 0;
        }
        
        AlogoREF.GeneratePuzzle(LongtestRUN[indexerForLongrunTest]);
    }
}
