using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Virtual_Btn_Controller : MonoBehaviour
{
    public Alogo Alogo_ref;
    public Text StatusInfo;
 
    static int totalButtonClicked = 0;
    static List<int> ListofClieckedButton = new List<int>();

    public GameObject[] OnBeltItem;

    public GameObject ButtonsArry;

    public static bool IslastCorrect = true;

    public Controller ControllerRef;

    public GameObject[] ItemsOnBelt;

    public AudioSource WinDemo1;

    public AudioSource[] OnBeltItenAudios;

    public AudioSource CorrectSequence_Audio;

    public AudioSource INCorrectSequence_Audio;

    public void Virtual_btnclicked(int i)
    {
        OnBeltItem[i].SetActive(true);
        OnBeltItenAudios[i].Play();
        totalButtonClicked ++;

        ListofClieckedButton.Add(i);

        if (totalButtonClicked == Alogo_ref.SortednumberOfItem.Count)
        {
            totalButtonClicked = 0;

            if(CheckMatch() == true)
            {
                
                ButtonsArry.SetActive(false);
                StatusInfo.text = "Correct sequence";
                ListofClieckedButton = new List<int>();
                StartCoroutine(CorrectSequenceCaller());
               
            }
            else
            {
                ButtonsArry.SetActive(false);
                StatusInfo.text = "InCorrect sequence";
                ListofClieckedButton = new List<int>();
                StartCoroutine(InCorrectSequencecaller());

            }
        }
    }

    IEnumerator CorrectSequenceCaller()
    {
        yield return new WaitForSeconds(0.5f);
        CorrectSequence_Audio.Play();

        StartCoroutine(CorrectSequence());
    }

    IEnumerator CorrectSequence()
    {
        yield return new WaitForSeconds(2f);


        
        if (ControllerRef.threshold == 2 && Controller.indexerForLongrunTest == 1)
        {
            ControllerRef.threshold = 0;
            Controller.indexerForLongrunTest = 0;
            for (int j = 0; j < 6; j++)
            {
                ItemsOnBelt[j].SetActive(false);
            }

            WinDemo1.Play();


            GameObject MainController = GameObject.FindGameObjectWithTag("mainController");

            MainController.GetComponent<SceneControoler>().StartDemo2();

        }
        else if(ControllerRef.threshold == 3 && Controller.indexerForLongrunTest == 9)
        {
            ControllerRef.threshold = 0;
            Controller.indexerForLongrunTest = 0;

            for (int j = 0; j < 6; j++)
            {
                ItemsOnBelt[j].SetActive(false);
            }
            WinDemo1.Play();
            print("Sequecen Done from play 3 to 5");

            GameObject MainController = GameObject.FindGameObjectWithTag("mainController");

            MainController.GetComponent<SceneControoler>().StartActualGamePlay();
        }
        else
        {
            for (int j = 0; j < 6; j++)
            {
                ItemsOnBelt[j].SetActive(false);
            }
            Controller.indexerForLongrunTest++;
            ControllerRef.StartComleteGamePlay();
        }
       
    }

    IEnumerator InCorrectSequencecaller()
    {
        yield return new WaitForSeconds(0.5f);
        INCorrectSequence_Audio.Play();
        StartCoroutine(InCorrectSequence());
    }

    IEnumerator InCorrectSequence()
    {
        yield return new WaitForSeconds(2f);
        for (int k = 0; k < 6; k++)
        {
            ItemsOnBelt[k].SetActive(false);
        }
        Controller.indexerForLongrunTest--;
        ControllerRef.StartComleteGamePlay();
    }

    bool CheckMatch()
    {
        if (ListofClieckedButton.Count != Alogo_ref.SortednumberOfItem.Count)
            return false;
        for (int i = 0; i < ListofClieckedButton.Count; i++)
        {
            if (ListofClieckedButton[i] != Alogo_ref.SortednumberOfItem[i])
                return false;
        }
        return true;
    }

}
