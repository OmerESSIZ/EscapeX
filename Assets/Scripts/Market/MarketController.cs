using UnityEngine;

public class MarketTrigger : MonoBehaviour
{
    public GameObject marketCanvas;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            marketCanvas.SetActive(true); // Market ekran� a��l�r
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            marketCanvas.SetActive(false); // Market ekran� kapan�r
        }
    }
}
