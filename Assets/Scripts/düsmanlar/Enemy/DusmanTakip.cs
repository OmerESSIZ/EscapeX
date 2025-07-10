/*using UnityEngine;

public class DusmanTakip : MonoBehaviour
{
    public Transform hedef;
    public float hiz = 2f;
    public float ziplamaGucu = 10f;
    public LayerMask zeminMaske;
    public Transform zeminKontrolNoktasi;
    public Transform duvarKontrolNoktasi;
    public float kontrolYaricapi = 0.2f;

    private Rigidbody2D rb;
    private bool zemindeMi;
    private float orijinalScaleX;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        orijinalScaleX = transform.localScale.x;
    }

    void Update()
    {
        if (hedef == null) return;

        Kontroller();
        YonuGuncelle();
        TakipEt();

        if (zemindeMi && DuvarVarMi())
        {
            Zipla();
        }
    }

    void YonuGuncelle()
    {
        float hareketYon = hedef.position.x > transform.position.x ? -1f : 1f;
        transform.localScale = new Vector3(orijinalScaleX * hareketYon, transform.localScale.y, transform.localScale.z);
    }

    void TakipEt()
    {
        if (zemindeMi)
        {
            float hareketYon = hedef.position.x > transform.position.x ? 1f : -1f;
            rb.velocity = new Vector2(hareketYon * hiz, rb.velocity.y);
        }
    }

    void Kontroller()
    {
        zemindeMi = Physics2D.OverlapCircle(zeminKontrolNoktasi.position, kontrolYaricapi, zeminMaske);
    }

    bool DuvarVarMi()
    {
        return Physics2D.OverlapCircle(duvarKontrolNoktasi.position, kontrolYaricapi, zeminMaske);
    }

    void Zipla()
    {
        rb.velocity = new Vector2(rb.velocity.x, ziplamaGucu);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (PlayerHealthController.instance != null)
                PlayerHealthController.instance.CaniAzaltFNC();
            else
                Debug.LogWarning("PlayerHealthController.instance bulunamadı!");
        }
    }
}
*/
using UnityEngine;
using DG.Tweening;

public class DusmanGolgeAI : MonoBehaviour
{
    public Transform hedef;
    public float hiz = 2f;
    public float dalgalanmaYuku = 0.5f;
    public float dalgaHizi = 2f;

    public float atakMesafe = 1f;    // Dash mesafesi
    public float atakSure = 0.2f;    // Dash süresi
    public float ziplamaGucu = 0.5f; // Jump animasyon süresi

    private Vector3 baslangicOffset;
    private Vector3 hedefPozisyonu;
    private float zaman;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
            rb.gravityScale = 0;

        Collider2D col = GetComponent<Collider2D>();
        if (col != null)
            col.isTrigger = true;

        spriteRenderer = GetComponent<SpriteRenderer>();

        baslangicOffset = transform.position;
    }

    void Update()
    {
        if (hedef == null)
            return;

        zaman += Time.deltaTime;

        float yukseklikDalga = Mathf.Sin(zaman * dalgaHizi) * dalgalanmaYuku;
        hedefPozisyonu = new Vector3(hedef.position.x, hedef.position.y + yukseklikDalga, hedef.position.z);

        transform.position = Vector2.MoveTowards(transform.position, hedefPozisyonu, hiz * Time.deltaTime);

        // Yön güncelleme (sol-sağ)
        if (hedef.position.x > transform.position.x)
            transform.localScale = new Vector3(-1 * Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        else
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
    }

    // Atak fonksiyonu (çağırmak senin kontrolünde)
    public void Attack()
    {
        Sequence seq = DOTween.Sequence();

        Vector3 orijinalPozisyon = transform.position;
        Vector3 hedefYon = (hedef.position - transform.position).normalized;

        // 1. Hafif yukarı zıplama
        //seq.Append(transform.DOMoveY(transform.position.y + ziplamaGucu, 0.15f).SetEase(Ease.OutQuad));
        //seq.Append(transform.DOMoveY(orijinalPozisyon.y, 0.15f).SetEase(Ease.InQuad));

        // 2. Hedefe hızlı atak (dash)
        seq.Append(transform.DOMove(transform.position + hedefYon * atakMesafe, atakSure).SetEase(Ease.OutFlash));
        seq.Append(transform.DOMove(orijinalPozisyon, atakSure));

        // 3. Renk değiştirerek vurma efekti
        if (spriteRenderer != null)
        {
            seq.Join(spriteRenderer.DOColor(Color.red, 0.1f));
            seq.Append(spriteRenderer.DOColor(Color.white, 0.1f));
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && PlayerHealthController.instance != null)
        {
            PlayerHealthController.instance.CaniAzaltFNC();

            // Atak animasyonunu tetikle
            Attack();
        }
    }
}

