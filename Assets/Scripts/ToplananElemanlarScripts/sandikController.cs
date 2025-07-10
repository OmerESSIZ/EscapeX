using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sandikController : MonoBehaviour
{
    Animator anim;
    int kacinciVurus;

    [SerializeField]
    GameObject coinPrefab;

    Vector2 patlamaMiktari = new Vector2(1, 4);



    private void Awake()
    {
        anim= GetComponent<Animator>();
    }

  
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("kilicVurusBox"))
        {
            if (kacinciVurus == 0)
            {
                anim.SetTrigger("sallanma");
            }else if(kacinciVurus==1)
            {
                anim.SetTrigger("sallanma");
            }
            else
            {
                //sandýk bugu kapmama bu satýr 
                GetComponent<BoxCollider2D>().enabled = false;
                //
                anim.SetTrigger("parcalanma");
                for (int i = 0; i < 3; i++) 
                {
                    Vector3 rastgeleVecor = new Vector3(transform.position.x + (i - 1), transform.position.y, transform.position.z);

                    GameObject coin = Instantiate(coinPrefab,rastgeleVecor,transform.rotation);

                    coin.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

                    coin.GetComponent<Rigidbody2D>().velocity = patlamaMiktari * new Vector2(Random.Range(1, 2), transform.localScale.y + Random.Range(0, 2));


                }  


            }
            kacinciVurus++;
        }
    }

}
