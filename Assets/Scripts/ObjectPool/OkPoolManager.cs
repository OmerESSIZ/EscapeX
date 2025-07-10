using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OkPoolManager : MonoBehaviour
{
    public static OkPoolManager instance;

    [SerializeField]
    GameObject okPrefab;

    GameObject okObje;

    List<GameObject> okPool = new List<GameObject> ();




    private void Awake()
    {
        instance = this;
        OklariOlusturFNC();
    }

    void OklariOlusturFNC()
    {
        for(int i = 0; i<10; i++)
        {
            okObje= Instantiate(okPrefab);
            okObje.SetActive(false);
            okObje.transform.parent = transform;

            okPool.Add(okObje);


        }
    }

    public void OkuFirlatFNC(Transform okCikisNoktasi, Transform parent)
    {
        // Yeterli ok yoksa hiç fýrlatma
        if (GameManager.instance.mevcutOk <= 0)
        {
            Debug.Log("Okunuz kalmadý!");
            return;
        }

        for (int i = 0; i < okPool.Count; i++)
        {
            if (!okPool[i].gameObject.activeInHierarchy)
            {
                okPool[i].transform.localScale = parent.localScale;
                okPool[i].gameObject.SetActive(true);
                okPool[i].gameObject.transform.position = okCikisNoktasi.position;

                Rigidbody2D rb = okPool[i].GetComponent<Rigidbody2D>();
                rb.velocity = (parent.localScale.x > 0) ?
                    okCikisNoktasi.right * 15f :
                    -okCikisNoktasi.right * 15f;

                // Ok sayýsýný azalt
                GameManager.instance.mevcutOk--;
                UIManager.instance.GuncelleCanVeOk();

                return;
            }
        }

        Debug.Log("Ok havuzunda aktif edilecek ok kalmadý!");
    }






}
