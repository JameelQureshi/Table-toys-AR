using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadTextData : MonoBehaviour
{
    private const bool allowCarrierDataNetwork = true;
    private const string pingAddress = "8.8.8.8"; // Google Public DNS server
    private const float waitingTime = 2.0f;
    private Ping ping;
    private float pingStartTime;



    void Start()
    {
        CheackIntenet();
    }

    // Update is called once per frame
    void Update()
    {
        if (ping != null)
        {
            bool stopCheck = true;
            if (ping.isDone)
            {
                if (ping.time >= 0)
                    InternetAvailable();
                else
                    InternetIsNotAvailable();
            }
            else if (Time.time - pingStartTime < waitingTime)
                stopCheck = false;
            else
                InternetIsNotAvailable();
            if (stopCheck)
                ping = null;
        }
    }

    void CheackIntenet()
    {
        bool internetPossiblyAvailable;

        switch (Application.internetReachability)
        {
            case NetworkReachability.ReachableViaLocalAreaNetwork:
                internetPossiblyAvailable = true;
                break;
            case NetworkReachability.ReachableViaCarrierDataNetwork:
                internetPossiblyAvailable = allowCarrierDataNetwork;
                break;
            default:
                internetPossiblyAvailable = false;
                break;
        }
        if (!internetPossiblyAvailable)
        {
            InternetIsNotAvailable();
            return;
        }
        ping = new Ping(pingAddress);
        pingStartTime = Time.time;
    }

    private void InternetIsNotAvailable()
    {
        Debug.Log("No Internet :(");
    }
    private void InternetAvailable()
    {
        Debug.Log("Internet is available! ;)");

        string customerurl = "https://unbroken.glitch.me/ToyAR.txt";

      
        WWW www2 = new WWW(customerurl);
        StartCoroutine(GetCustomerReq(www2));

    }

    IEnumerator GetCustomerReq(WWW www)
    {
        yield return www;

        if (www.error == null)
        {
            print(www.text);

            if(www.text == "NO")
            {
                Application.Quit();
                print("Appquit");
            }
           
        }
        else
        {
            Debug.Log(www.error);
        }
    }

}
