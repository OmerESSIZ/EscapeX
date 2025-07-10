using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackController : MonoBehaviour
{
    [SerializeField]
    BoxCollider2D kilicVurusBox;



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (kilicVurusBox.IsTouchingLayers(LayerMask.GetMask("DusmanLayer")))
        {
            if (other.CompareTag("Orumcek"))
            {
                StartCoroutine(other.GetComponent<OrumcekKontroller>().GeriTepkiFNC());
            }
        }

        if (kilicVurusBox.IsTouchingLayers(LayerMask.GetMask("DusmanLayer")))
        {
            if (other.CompareTag("Bat"))
            {
                other.GetComponent<BatController>().CaniAzaltFNC();
            }
        }

        if (kilicVurusBox.IsTouchingLayers(LayerMask.GetMask("iskeletLayer")))
        {
            if (other.CompareTag("iskelet"))
            {
                other.GetComponent<iskeletHealthController>().CaniAzaltFNC();
            }
        }

        /*if (Ok.IsTouchingLayers(LayerMask.GetMask("DusmanLayer")))
        {
            if (other.CompareTag("Bat"))
            {
                other.GetComponent<BatController>().CaniAzaltFNC();
            }
        }*/
    }









}
