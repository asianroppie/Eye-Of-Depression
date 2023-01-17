using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScore : MonoBehaviour
{
    public void PrintScore()
    {
        Debug.Log(Singleton.runtime.sympathyScore);
    }
    public void IncrementAndPrintScore()
    {
        Singleton.runtime.sympathyScore += 1;
        Debug.Log("Sympathy Score has been increased by 1");
        Debug.Log("Sympathy Score has: " + Singleton.runtime.sympathyScore);
    }
}
