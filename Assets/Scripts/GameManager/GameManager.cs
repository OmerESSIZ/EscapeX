using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int toplananCoinAdet;

    private void Awake()
    { 
        instance = this;
    }

    private void Start()
    {
        toplananCoinAdet = 0;
    }
  
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            UIManager.instance.PausePanelAcKapat();
        }
    }

}
*/
public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int toplananCoinAdet;
    public int mevcutCan;
    public int mevcutOk;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Sahne geçiþinde yok olmasýn
        }
        else
        {
            Destroy(gameObject); // Aynýsýndan bir tane varsa onu sil
        }
    }

    private void Start()
    {
        toplananCoinAdet = 0;

        mevcutCan = 10;     // Örnek baþlangýç caný
        mevcutOk = 0;      // Örnek baþlangýç oku
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UIManager.instance.PausePanelAcKapat();
        }
    }
}
