using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform target; // Takip edilecek hedef (�rne�in, ara�)
    public Vector3 offset; // Kameran�n hedeften olan ofseti
    public float followSpeed = 5f; // Takip h�z�
    public float rotationSpeed = 5f; // D�n�� h�z�

    private void LateUpdate()
    {
        if (target != null)
        {
            // Hedef pozisyonuna ofset uygulama
            Vector3 desiredPosition = target.position + offset;
            // Kamera pozisyonunu yumu�ak bir �ekilde hedefe yakla�t�rma
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);
            transform.position = smoothedPosition;

            // Kameran�n hedefle ayn� a��da d�nmesini sa�lama
            Quaternion desiredRotation = Quaternion.LookRotation(target.position - transform.position);
            Quaternion smoothedRotation = Quaternion.Slerp(transform.rotation, desiredRotation, rotationSpeed * Time.deltaTime);
            transform.rotation = smoothedRotation;
        }
    }
}
