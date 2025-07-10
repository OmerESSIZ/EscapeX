using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField]
    Slider playerSlider;

    [SerializeField]
    TMP_Text coinTxt;

    [SerializeField]
    GameObject pausePanel;

    [SerializeField] TMP_Text canTxt;
    [SerializeField] TMP_Text okTxt;

    [SerializeField]
    Transform butonlarPanel;


    private void Start()
    {
        pausePanel.SetActive(false);
        //
        if (Time.timeScale == 0f)
            Time.timeScale = 1f;

    }
    private void Awake()
    {
        instance = this;

    }

    public void SlideriGuncelle(int gecerliDeger, int maxDeger)
    {
        playerSlider.maxValue = maxDeger;
        playerSlider.value = gecerliDeger;

    }


    public void CoinAdetGuncelle()
    {
        coinTxt.text = GameManager.instance.toplananCoinAdet.ToString();
    }

    public void PausePanelAcKapat()
    {
        if (!pausePanel.activeInHierarchy)
        {
            pausePanel.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            pausePanel.SetActive(false);
            Time.timeScale = 1f;
        }



    }
    public void AnaMenuyeDon()
    {
        SceneManager.LoadScene("AnaMenu");
    }

    public void GuncelleCanVeOk()
    {
        // Can slider'ý güncelle
        // SlideriGuncelle(GameManager.instance.mevcutCan, 10); // maxCan deðeri sabit ya da baþka bir yerden alýnabilir

        // Ok yazýsýný güncelle
        okTxt.text = GameManager.instance.mevcutOk.ToString();
    }

    void TumButonlarinAlphasiniDusur()
    {
        foreach (Transform btn in butonlarPanel)
        {
            var canvasGroup = btn.GetComponent<CanvasGroup>();
            if (canvasGroup != null)
            {
                canvasGroup.alpha = 0.25f;
            }

            var button = btn.GetComponent<Button>();
            if (button != null)
            {
                button.interactable = true;
            }
        }
    }



    public void NormalButonaBasildi()
    {
        TumButonlarinAlphasiniDusur();

        UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.transform.GetComponent<CanvasGroup>().alpha = 1f;

        PlayerHareketController.instance.HerseyiKapatNormaliAc();
        UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.GetComponent<Button>().interactable = false;


    }
    public void KilicButonaBasildi()
    {
        TumButonlarinAlphasiniDusur();

        UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.transform.GetComponent<CanvasGroup>().alpha = 1f;
        PlayerHareketController.instance.NormaliKapatKiliciAc();
        UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.GetComponent<Button>().interactable = false;

    }

    public void OkButonaBasildi()
    {
        TumButonlarinAlphasiniDusur();

        UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.transform.GetComponent<CanvasGroup>().alpha = 1f;
        PlayerHareketController.instance.HerseyiKapatOkuAc();
        UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.GetComponent<Button>().interactable = false;

    }

    public void MizrakButonaBasildi()
    {
        TumButonlarinAlphasiniDusur();

        UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.transform.GetComponent<CanvasGroup>().alpha = 1f;
        PlayerHareketController.instance.HerseyiKapatMizrakAc();
        UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.GetComponent<Button>().interactable = false;

    }

    public void SadeceOkButonAktif()
    {
        foreach (Transform btn in butonlarPanel)
        {
            Button button = btn.GetComponent<Button>();
            CanvasGroup canvasGroup = btn.GetComponent<CanvasGroup>();

            if (btn.name == "OkButon") // Bu ismin sahnedeki buton adýyla birebir ayný olmasý gerek
            {
                button.interactable = false;
                canvasGroup.alpha = 1f;
            }
            else
            {
                button.interactable = false;
                canvasGroup.alpha = 1f;
            }
        }
    }

    public void TumButonlariAktifEt()
    {
        foreach (Transform btn in butonlarPanel)
        {
            btn.GetComponent<Button>().interactable = true;
            btn.GetComponent<CanvasGroup>().alpha = 1f;
        }
    }


}
