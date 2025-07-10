using UnityEngine;

public class MarketManager : MonoBehaviour
{
    public static MarketManager instance;

    private int maxOk = 10; // Maksimum ok say�s�
    public GameObject marketCanvas;
    public bool marketAcik = false;

    private void Awake()
    {
        instance = this;
    }


    private void Update()
    {
        if (!marketAcik) return; // E�er market a��k de�ilse hi�bir �ey yapma

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            BuyArrow();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            BuyHealth();
        }
    }
    public void MarketiAc()
    {
        marketAcik = true;
        marketCanvas.SetActive(true);
    }

    public void MarketiKapat()
    {
        marketAcik = false;
        marketCanvas.SetActive(false);
    }


    public void BuyArrow()
    {
        if (GameManager.instance.mevcutOk >= 10)
        {
            Debug.Log("Zaten maksimum ok say�s�na sahipsiniz!");
            return;
        }

        if (GameManager.instance.toplananCoinAdet >= 2)
        {
            GameManager.instance.toplananCoinAdet -= 2;
            GameManager.instance.mevcutOk++;

            UIManager.instance.CoinAdetGuncelle();
            UIManager.instance.GuncelleCanVeOk();

            // Ok havuzundan bir ok daha aktif edilmeye haz�r
            Debug.Log("Ok sat�n al�nd�!");

        }
        else
        {
            Debug.Log("Yeterli coin yok!");
        }
    }


    public void BuyHealth()
    {
        if (PlayerHealthController.instance.gecerliSaglik >= PlayerHealthController.instance.maxSaglik)
        {
            Debug.Log("Can�n�z zaten maksimumda!");
            return;
        }

        if (GameManager.instance.toplananCoinAdet >= 5)
        {
            GameManager.instance.toplananCoinAdet -= 5;

            PlayerHealthController.instance.CanMaxla();

            UIManager.instance.CoinAdetGuncelle();
            UIManager.instance.GuncelleCanVeOk();
            Debug.Log("Can sat�n al�nd� ve maxland�!");
        }
        else
        {
            Debug.Log("Yeterli coin yok!");
        }
    }

}

