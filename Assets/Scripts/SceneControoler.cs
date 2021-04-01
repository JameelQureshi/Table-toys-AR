using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControoler : MonoBehaviour
{
    public AudioSource IntroAudio;
    public AudioSource GameDemolevel1and2;
    public AudioSource Demo1Play;


    public AudioSource StartDemo2AUDIO;
    public AudioSource GameDemolevel3to5;


    public AudioSource StartGamePlay;
    // Start is called before the first frame update
    public  void ReStart()
    {
        SceneManager.LoadScene(0);
    }

    // Update is called once per frame
  public void StartExperiecen()
   {
        IntroAudio.Play();
        GameObject Game = GameObject.FindGameObjectWithTag("cart").transform.GetChild(0).gameObject;
        Game.SetActive(true);

        StartCoroutine(intro20Sec());

    }
    IEnumerator intro20Sec()
    {
        yield return new WaitForSeconds(20f);
        GameDemolevel1and2.Play();

        GameObject Game = GameObject.FindGameObjectWithTag("cart").transform.GetChild(0).gameObject;
        Game.SetActive(false);

        GameObject Demo1and2AR = GameObject.FindGameObjectWithTag("cart").transform.GetChild(1).gameObject;
        Demo1and2AR.SetActive(true);

        StartCoroutine(Demolevel35Sec());
    }

    IEnumerator Demolevel35Sec()
    {
        yield return new WaitForSeconds(35f);
        Demo1Play.Play();
        StartCoroutine(PlaydemoWait10sec());
    }

    IEnumerator PlaydemoWait10sec()
    {
        yield return new WaitForSeconds(10f);

        GameObject Demo1and2AR = GameObject.FindGameObjectWithTag("cart").transform.GetChild(1).gameObject;
        Demo1and2AR.SetActive(false);

        GameObject GamePlay = GameObject.FindGameObjectWithTag("cart").transform.GetChild(0).gameObject;
        GamePlay.SetActive(true);

        GameObject AUgmtnedController = GameObject.FindGameObjectWithTag("controller");
        AUgmtnedController.GetComponent<Controller>().threshold = 2;
        AUgmtnedController.GetComponent<Controller>().StartComleteGamePlay();
    }


    /// <summary>
    /// DEMO 2 Play
    /// </summary>
    ///

    public void StartDemo2()
    {
        StartCoroutine(StartDemo2_1());
       
    }
     
    IEnumerator StartDemo2_1()
    {
        yield return new WaitForSeconds(3f);
        StartDemo2AUDIO.Play();

        GameObject GamePlay = GameObject.FindGameObjectWithTag("cart").transform.GetChild(0).gameObject;
        GamePlay.SetActive(false);

        GameObject Demo3to5AR = GameObject.FindGameObjectWithTag("cart").transform.GetChild(2).gameObject;
        Demo3to5AR.SetActive(true);

        StartCoroutine(AudioDelayforDEmo2345());
    }

    IEnumerator AudioDelayforDEmo2345()
    {
        yield return new WaitForSeconds(70f);
        GameDemolevel3to5.Play();
        StartCoroutine(Demo3to5Wait());

    }

    IEnumerator Demo3to5Wait()
    {
        yield return new WaitForSeconds(10f);

        GameObject GamePlay = GameObject.FindGameObjectWithTag("cart").transform.GetChild(2).gameObject;
        GamePlay.SetActive(false);

        GameObject Demo3to5AR = GameObject.FindGameObjectWithTag("cart").transform.GetChild(0).gameObject;
        Demo3to5AR.SetActive(true);

        GameObject AUgmtnedController = GameObject.FindGameObjectWithTag("controller");
        AUgmtnedController.GetComponent<Controller>().threshold = 3;
        Controller.indexerForLongrunTest = 2;
        AUgmtnedController.GetComponent<Controller>().StartComleteGamePlay();
    }


    public void StartActualGamePlay()
    {
        StartGamePlay.Play();

        GameObject Demo3to5AR = GameObject.FindGameObjectWithTag("cart").transform.GetChild(0).gameObject;
        Demo3to5AR.SetActive(false);

        GameObject DemoGaemplay = GameObject.FindGameObjectWithTag("cart").transform.GetChild(3).gameObject;
        DemoGaemplay.SetActive(true);

        StartCoroutine(letswait16Sec());

    }
    IEnumerator letswait16Sec()

    {
        yield return new WaitForSeconds(18f);


        GameObject Demo3to5AR = GameObject.FindGameObjectWithTag("cart").transform.GetChild(3).gameObject;
        Demo3to5AR.SetActive(false);
        GameObject DemoGaemplay = GameObject.FindGameObjectWithTag("cart").transform.GetChild(0).gameObject;
        DemoGaemplay.SetActive(true);


        GameObject AUgmtnedController = GameObject.FindGameObjectWithTag("controller");
        AUgmtnedController.GetComponent<Controller>().threshold = 0;
        Controller.indexerForLongrunTest = 0;
        AUgmtnedController.GetComponent<Controller>().StartComleteGamePlay();

    }

}
