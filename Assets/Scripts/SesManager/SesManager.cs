using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SesManager : MonoBehaviour
{
    public static SesManager instance;
    [SerializeField]
    AudioSource[] sesEfektleri;

    private void Awake()
    {
        instance = this;
    }


    public void SesEfektiCikar(int hangiSes)
    {
        sesEfektleri[hangiSes].Stop();
        sesEfektleri[hangiSes].Play();

    }

}
