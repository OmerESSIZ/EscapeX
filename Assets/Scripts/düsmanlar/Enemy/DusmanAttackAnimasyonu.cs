using UnityEngine;
using DG.Tweening;

public class DusmanAttackAnimasyonu : MonoBehaviour
{
    private SpriteRenderer sr;
    private Vector3 orijinalPozisyon;
    private Vector3 orijinalScale;

    public Transform hedef; // Ýsteðe baðlý: hedefe doðru gitme efekti
    public float saldiriMesafesi = 0.5f;
    public float saldiriSuresi = 0.2f;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        orijinalPozisyon = transform.position;
        orijinalScale = transform.localScale;
    }

    public void SaldiriAnimasyonuYap()
    {
        Vector3 hedefYon = hedef != null ? (hedef.position - transform.position).normalized : Vector3.right;

        Sequence s = DOTween.Sequence();

        s.Append(transform.DOScale(orijinalScale * 1.2f, 0.1f)); // büyüme
        s.Join(sr.DOColor(Color.red, 0.1f)); // kýrmýzý

        if (hedef != null)
        {
            Vector3 hedefNokta = transform.position + hedefYon * saldiriMesafesi;
            s.Append(transform.DOMove(hedefNokta, saldiriSuresi).SetEase(Ease.OutQuad));
        }

        s.AppendInterval(0.1f);

        s.Append(transform.DOScale(orijinalScale, 0.1f)); // eski scale
        s.Join(sr.DOColor(Color.white, 0.1f)); // eski renk

        if (hedef != null)
        {
            s.Append(transform.DOMove(orijinalPozisyon, 0.1f)); // geri dön
        }

        s.Play();
    }

}
