using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ronda : MonoBehaviour
{
    public Transform startPoint; // Ponto inicial
    public Transform endPoint;   // Ponto final
    public float moveSpeed = 2.0f; // Velocidade de movimento

    private Transform targetPoint; // O ponto para o qual estamos atualmente se movendo

    private void Start()
    {
        // Comece movendo em direção ao ponto final
        targetPoint = endPoint;
    }

    private void Update()
    {
        // Mova o personagem em direção ao ponto de destino
        transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, moveSpeed * Time.deltaTime);

        // Verifique se o personagem atingiu o ponto de destino
        if (Vector3.Distance(transform.position, targetPoint.position) < 1.0f)
        {
            // Se o personagem atingiu o ponto de destino, troque o ponto de destino
            if (targetPoint == endPoint)
            {
                targetPoint = startPoint;
            }
            else
            {
                targetPoint = endPoint;
            }
        }
    }
    
}
