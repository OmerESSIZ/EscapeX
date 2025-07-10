using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class OrumcekKontroller : MonoBehaviour
{
    [SerializeField] Transform[] pozisyonlar;
    public float orumcekHizi;
    public int maxSaglik;
    public float beklemeSuresi;
    public float takipMesafesi = 5f;


    [SerializeField]
    Slider orumcekSlider;


    int gecerliSaglik;
    float beklemeSayac;
    bool atakYapabilirmi;

    Animator anim;
    int kacinciPozisyon;
    BoxCollider2D orumcekCollider;
    Transform hedefPlayer;
    Rigidbody2D rb;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        orumcekCollider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {

        gecerliSaglik = maxSaglik;

        orumcekSlider.maxValue = maxSaglik;
        SliderGuncelle();

        atakYapabilirmi = true;

        GameObject playerGO = GameObject.Find("Player");
        if (playerGO != null)
            hedefPlayer = playerGO.transform;
        else
            Debug.LogError("Player GameObject bulunamadý!");

        foreach (Transform pos in pozisyonlar)
            pos.parent = null;
    }

    private void Update()
    {
        if (!atakYapabilirmi) return;

        if (beklemeSayac > 0)
        {
            beklemeSayac -= Time.deltaTime;
            anim.SetBool("hareketEtsinmi", false);
        }
        else
        {
            if (hedefPlayer != null &&
                hedefPlayer.position.x > pozisyonlar[0].position.x &&
                hedefPlayer.position.x < pozisyonlar[1].position.x)
            {
                Vector3 hedefPozisyon = new Vector3(hedefPlayer.position.x, transform.position.y, transform.position.z);
                transform.position = Vector3.MoveTowards(transform.position, hedefPozisyon, orumcekHizi * Time.deltaTime);

                anim.SetBool("hareketEtsinmi", true);

                float yon = hedefPlayer.position.x - transform.position.x;
                transform.localScale = new Vector3(yon < 0 ? -1 : 1, 1, 1);
            }
            else
            {
                anim.SetBool("hareketEtsinmi", true);

                float yon = pozisyonlar[kacinciPozisyon].position.x - transform.position.x;
                transform.localScale = new Vector3(yon < 0 ? -1 : 1, 1, 1);

                transform.position = Vector3.MoveTowards(transform.position, pozisyonlar[kacinciPozisyon].position, orumcekHizi * Time.deltaTime);
                if (Vector3.Distance(transform.position, pozisyonlar[kacinciPozisyon].position) < 0.1f)
                {
                    beklemeSayac = beklemeSuresi;
                    PozisyonuDegistir();
                }
            }
        }
    }

    void PozisyonuDegistir()
    {
        kacinciPozisyon++;
        if (kacinciPozisyon >= pozisyonlar.Length)
            kacinciPozisyon = 0;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, takipMesafesi);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (orumcekCollider.IsTouchingLayers(LayerMask.GetMask("PlayerLayer")) && atakYapabilirmi)
        {
            atakYapabilirmi = false;
            anim.SetTrigger("atakYapti");

            var hareket = other.GetComponent<PlayerHareketController>();
            var saglik = other.GetComponent<PlayerHealthController>();

            if (hareket != null)
                hareket.GeriTepkiFNC();
            if (saglik != null)
                saglik.CaniAzaltFNC();

            StartCoroutine(YenidenAtakYapsin());
        }
    }

    IEnumerator YenidenAtakYapsin()
    {
        yield return new WaitForSeconds(1f);
        if (gecerliSaglik > 0)
            atakYapabilirmi = true;
    }

    public IEnumerator GeriTepkiFNC()
    {
        atakYapabilirmi = false;
        rb.velocity = Vector2.zero;
        yield return new WaitForSeconds(0.1f);

        gecerliSaglik--;

        SliderGuncelle();

        if (gecerliSaglik <= 0)
        {
            gecerliSaglik = 0;
            anim.SetTrigger("canVerdi");
            orumcekCollider.enabled = false;
            orumcekSlider.gameObject.SetActive(false);
            Destroy(gameObject, 2f);
        }
        else
        {
            for (int i = 0; i < 5; i++)
            {
                rb.velocity = new Vector2(-transform.localScale.x + i, rb.velocity.y);
                yield return new WaitForSeconds(0.05f);
            }
            anim.SetBool("hareketEtsinmi", true);
            yield return new WaitForSeconds(0.25f);
            rb.velocity = Vector2.zero;
            atakYapabilirmi = true;
        }
    }
    void SliderGuncelle()
    {
        orumcekSlider.value = gecerliSaglik;
    }
}
