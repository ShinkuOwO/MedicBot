using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class CheckPoint : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                //Llamaremos al metodo ReachedCheckPoint() definido por nosotros en el script "PlayerRespawn.cs"
                collision.GetComponent<PlayerRespawn>().ReachedCheckPoint(transform.position.x, transform.position.y);
            }
        }
    }

