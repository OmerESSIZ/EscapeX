using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    PlayerHareketController player;

    [SerializeField]
    private Collider2D boundsBox;

    [SerializeField]
    private Transform backgrounds;

    private float halfYukseklik, halfGenislik;
    private Vector2 sonPos;

    private void Awake()
    {
        player = FindObjectOfType<PlayerHareketController>();
    }

    private void Start()
    {
        halfYukseklik = Camera.main.orthographicSize;
        halfGenislik = halfYukseklik * Camera.main.aspect;
        sonPos = transform.position;
    }

    private void Update()
    {
        if (player != null)
        {
            // Kamera pozisyonunu sýnýrlara göre ayarla
            transform.position = new Vector3(
                Mathf.Clamp(player.transform.position.x, boundsBox.bounds.min.x + halfGenislik, boundsBox.bounds.max.x - halfGenislik),
                Mathf.Clamp(player.transform.position.y, boundsBox.bounds.min.y + halfYukseklik, boundsBox.bounds.max.y - halfYukseklik),
                transform.position.z);
            // Arka plan hareketini güncelle
            if (backgrounds != null)
            {
                BackgroundHareketFNC();
            }
                
                
            
        }
    }

    void BackgroundHareketFNC()
    {
        Vector2 aradakiFark = new Vector2(transform.position.x - sonPos.x, transform.position.y - sonPos.y);
        backgrounds.position += new Vector3(aradakiFark.x, aradakiFark.y, 0f);
        sonPos = transform.position;
    }
}
 