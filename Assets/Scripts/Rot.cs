using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rot : MonoBehaviour
{
    public float radius = 1;
    public float speed = 1;

    private float t = 0;
    private Vector3 startPos;
    private const float pi2 = Mathf.PI * 2;

    private void Start()
    {
        startPos = transform.position;
    }

    private void Update()
    {
        transform.position = startPos + new Vector3(Mathf.Cos(t), Mathf.Sin(t)) * radius;
        t += Time.deltaTime * speed;
        t %= pi2;
    }


}
