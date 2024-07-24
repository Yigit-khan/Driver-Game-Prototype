using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteRoad : MonoBehaviour
{
    public GameObject roadSegmentPrefab; // Yol segmenti prefab'ý
    public int numberOfSegments = 3; // Ayný anda aktif olan segment sayýsý
    public float segmentLength = 30f; // Her segmentin uzunluðu
    public float speed = 5f; // Yolun hareket hýzý

    private GameObject[] segments;
    private float offset;

    void Start()
    {
        segments = new GameObject[numberOfSegments];
        offset = segmentLength * (numberOfSegments - 1);

        // Yol segmentlerini oluþtur
        for (int i = 0; i < numberOfSegments; i++)
        {
            segments[i] = Instantiate(roadSegmentPrefab, new Vector3(0, 0, i * segmentLength), Quaternion.identity);
        }
    }

    void Update()
    {
        // Tüm segmentleri hareket ettir
        for (int i = 0; i < segments.Length; i++)
        {
            segments[i].transform.Translate(Vector3.back * speed * Time.deltaTime);

            // Segmentin oyuncunun arkasýna geçtiðinde öne taþýn
            if (segments[i].transform.position.z < -segmentLength)
            {
                float newZ = segments[i].transform.position.z + offset;
                segments[i].transform.position = new Vector3(segments[i].transform.position.x, segments[i].transform.position.y, newZ);
            }
        }
    }
}
