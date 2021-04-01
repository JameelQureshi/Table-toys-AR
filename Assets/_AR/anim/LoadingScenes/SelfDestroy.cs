using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SelfDestroyCOde());

    }

    IEnumerator SelfDestroyCOde()
    {
        yield return new WaitForSeconds(3.3f);
        Destroy(gameObject);
    }
}
