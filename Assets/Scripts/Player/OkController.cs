using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OkController : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (GetComponent<BoxCollider2D>().IsTouchingLayers(LayerMask.GetMask("iskeletLayer")))
        {
            if (other.CompareTag("iskelet"))
            { 


                gameObject.SetActive(false);
                other.GetComponent<iskeletHealthController>().CaniAzaltFNC();

            }
        }
    }



}
