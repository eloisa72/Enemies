using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class perseguidor : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float velocidade = 1f;
    Vector3 destino;
    float proximo;
    bool nulo = false;
    bool andando;

    void FixedUpdate()
    {
        destino = new Vector3(player.transform.position.x, this.transform.position.y, player.transform.position.z);
        if(destino == null)
        {
            nulo = true;

        } else{ nulo = false; }

        float passo = velocidade * Time.deltaTime;

        if(nulo == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, destino, passo);
        } else{ transform.position = transform.position;}
    }
}
