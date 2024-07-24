using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform target; // Takip edilecek hedef (örneðin, araç)
    public Vector3 offset; // Kameranýn hedeften olan ofseti
    public float followSpeed = 5f; // Takip hýzý
    public float rotationSpeed = 5f; // Dönüþ hýzý

    private void LateUpdate()
    {
        if (target != null)
        {
            // Hedef pozisyonuna ofset uygulama
            Vector3 desiredPosition = target.position + offset;
            // Kamera pozisyonunu yumuþak bir þekilde hedefe yaklaþtýrma
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);
            transform.position = smoothedPosition;

            // Kameranýn hedefle ayný açýda dönmesini saðlama
            Quaternion desiredRotation = Quaternion.LookRotation(target.position - transform.position);
            Quaternion smoothedRotation = Quaternion.Slerp(transform.rotation, desiredRotation, rotationSpeed * Time.deltaTime);
            transform.rotation = smoothedRotation;
        }
    }
}
