using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : MonoBehaviour
{
    [SerializeField] private GameObject StartScreen;

    void Start()
    {
        StartCoroutine(Baslangic());
    }

    IEnumerator Baslangic()
    {
        yield return new WaitForSeconds(10f);
        gameObject.SetActive(false);
        StartScreen.SetActive(true);
    }
}
