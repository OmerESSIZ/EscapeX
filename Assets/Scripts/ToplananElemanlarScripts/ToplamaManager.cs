using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToplamaManager : MonoBehaviour
{
    [SerializeField]
    bool coinmi;
    bool toplandimi;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")&& !toplandimi)
        {
            toplandimi = true;
            SesManager.instance.SesEfektiCikar(6);
            GameManager.instance.toplananCoinAdet++;

            UIManager.instance.CoinAdetGuncelle();



            Destroy(gameObject);
            //Instatiante(coinEfekt, transform.position, Quaternion.identity);
        }
    }

}
