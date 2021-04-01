using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Alogo : MonoBehaviour
{
    public Animator TVCanvas;
    string[] Allobject = {"car","truck","plane","duck","sheep","elephant"};

    List<int> Sortedfor6 = new List<int> { 0, 1, 2, 3, 4, 5 };

    List<int> numberOfItem;
    public List<int> SortednumberOfItem;

    int indexer = 0;

    public GameObject ButtonsArry;

    public Text StatusInfo;

    public void GeneratePuzzle(int TotalItemsTobeDisplayedon_TV)
    {
        StatusInfo.text = "Start Scenario :" + TotalItemsTobeDisplayedon_TV;
        numberOfItem = new List<int>();
        SortednumberOfItem = new List<int>();
        ButtonsArry.SetActive(false);

        int availableItemsToShow = 0;
        if(TotalItemsTobeDisplayedon_TV > 3)
        {
            availableItemsToShow = Allobject.Length;
        }
        else
        {
            availableItemsToShow = 3;
        }
        numberOfItem = RandomNumberGenerator(TotalItemsTobeDisplayedon_TV, availableItemsToShow);


        if(availableItemsToShow == 3)
        {
            SortednumberOfItem = new List<int>(numberOfItem);
            SortednumberOfItem.Sort();
        }
        else
        {
            SortednumberOfItem = new List<int>(SortingFor4and5());
        }

        NowPlayAnimationOnTV1();
    }
    
    void NowPlayAnimationOnTV1()
    {
        if (indexer == numberOfItem.Count)
        {
            StatusInfo.text = "Start Guesing";
            ButtonsArry.SetActive(true);
            indexer = 0;
            return;
        }
        else
        { 
            TVCanvas.Play(Allobject[numberOfItem[indexer]]);
            indexer++;
            Invoke("NowPlayAnimationOnTV1", 3.95f);
        }
    }


    List <int>  RandomNumberGenerator(int TotalItemsTobeDisplayedon_TV, int availableItemsToShow)
    {
       List<int> mylist = new List<int>(); 
        while (mylist.Count != TotalItemsTobeDisplayedon_TV)
        {
            var element = Random.Range(0, availableItemsToShow);
            if (!mylist.Contains(element))
            {
                mylist.Add(element);
            }
        }
        return mylist;
    }

    List<int> SortingFor4and5()
    {
        List<int> MinusList = new List<int> { -1, -1, -1, -1, -1, -1 };

        for (int i = 0; i < numberOfItem.Count; i++)
        {
            for (int j = 0; j < Sortedfor6.Count ; j++)
            {
                if(numberOfItem[i] == Sortedfor6[j])
                {
                    MinusList[j] = numberOfItem[i];
                }
            }
        }
        for(int k=0; k<MinusList.Count;k++)
        {
            if(MinusList[k] == -1)
            {
                MinusList.RemoveAt(k);
            }
        }
        return MinusList;
    }
}
