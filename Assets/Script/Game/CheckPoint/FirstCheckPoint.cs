using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstCheckPoint : MonoBehaviour
{
    public GameObject CheckPoint1;

    void Start()
    {
        CheckPoint1.SetActive(false);
        StartCoroutine("FirstCheckPointSetActive");
    }

    IEnumerator FirstCheckPointSetActive()
    {
        yield return new WaitForSeconds(10);
        CheckPoint1.SetActive(true);
    }

}
