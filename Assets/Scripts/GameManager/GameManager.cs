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
            DontDestroyOnLoad(gameObject); // Sahne ge�i�inde yok olmas�n
        }
        else
        {
            Destroy(gameObject); // Ayn�s�ndan bir tane varsa onu sil
        }
    }

    private void Start()
    {
        toplananCoinAdet = 0;

        mevcutCan = 10;     // �rnek ba�lang�� can�
        mevcutOk = 0;      // �rnek ba�lang�� oku
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UIManager.instance.PausePanelAcKapat();
        }
    }
}
