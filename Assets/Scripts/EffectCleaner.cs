using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectCleaner : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(ClearEffect());
    }

    IEnumerator ClearEffect()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
