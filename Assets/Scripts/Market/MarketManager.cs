using UnityEngine;

public class MarketManager : MonoBehaviour
{
    public static MarketManager instance;

    private int maxOk = 10; // Maksimum ok sayýsý
    public GameObject marketCanvas;
    public bool marketAcik = false;

    private void Awake()
    {
        instance = this;
    }


    private void Update()
    {
        if (!marketAcik) return; // Eðer market açýk deðilse hiçbir þey yapma

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
            Debug.Log("Zaten maksimum ok sayýsýna sahipsiniz!");
            return;
        }

        if (GameManager.instance.toplananCoinAdet >= 2)
        {
            GameManager.instance.toplananCoinAdet -= 2;
            GameManager.instance.mevcutOk++;

            UIManager.instance.CoinAdetGuncelle();
            UIManager.instance.GuncelleCanVeOk();

            // Ok havuzundan bir ok daha aktif edilmeye hazýr
            Debug.Log("Ok satýn alýndý!");

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
            Debug.Log("Canýnýz zaten maksimumda!");
            return;
        }

        if (GameManager.instance.toplananCoinAdet >= 5)
        {
            GameManager.instance.toplananCoinAdet -= 5;

            PlayerHealthController.instance.CanMaxla();

            UIManager.instance.CoinAdetGuncelle();
            UIManager.instance.GuncelleCanVeOk();
            Debug.Log("Can satýn alýndý ve maxlandý!");
        }
        else
        {
            Debug.Log("Yeterli coin yok!");
        }
    }

}

