using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeDay : MonoBehaviour
{
    public void Freeze()
    {
        Singleton.runtime.Freeze();
    }
    public void Unfreeze()
    {
        Singleton.runtime.UnFreeze();
    }
}
