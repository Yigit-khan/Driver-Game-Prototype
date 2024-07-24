using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteRoad : MonoBehaviour
{
    public GameObject roadSegmentPrefab; // Yol segmenti prefab'�
    public int numberOfSegments = 3; // Ayn� anda aktif olan segment say�s�
    public float segmentLength = 30f; // Her segmentin uzunlu�u
    public float speed = 5f; // Yolun hareket h�z�

    private GameObject[] segments;
    private float offset;

    void Start()
    {
        segments = new GameObject[numberOfSegments];
        offset = segmentLength * (numberOfSegments - 1);

        // Yol segmentlerini olu�tur
        for (int i = 0; i < numberOfSegments; i++)
        {
            segments[i] = Instantiate(roadSegmentPrefab, new Vector3(0, 0, i * segmentLength), Quaternion.identity);
        }
    }

    void Update()
    {
        // T�m segmentleri hareket ettir
        for (int i = 0; i < segments.Length; i++)
        {
            segments[i].transform.Translate(Vector3.back * speed * Time.deltaTime);

            // Segmentin oyuncunun arkas�na ge�ti�inde �ne ta��n
            if (segments[i].transform.position.z < -segmentLength)
            {
                float newZ = segments[i].transform.position.z + offset;
                segments[i].transform.position = new Vector3(segments[i].transform.position.x, segments[i].transform.position.y, newZ);
            }
        }
    }
}
