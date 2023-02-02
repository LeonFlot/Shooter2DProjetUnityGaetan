using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmosInventaire : MonoBehaviour
{

    [SerializeField] int nbPoints;
    [SerializeField] float radius;
    [SerializeField] GameObject point;
    Vector3 pos;
    Vector3 dir;
    float length;

    private void OnDrawGizmos()
    {
        Gizmos.color = Gizmos.color = Color.white;
        length = 2 * Mathf.PI / nbPoints;
        for (int i = 0; i < nbPoints; i++)
        {
            pos = new Vector3(transform.position.x + Mathf.Cos((length) + length * i), transform.position.y + Mathf.Sin((length) + length * i), transform.position.z);
            dir = (transform.position - pos).normalized;
            pos -= dir * radius;
            Gizmos.DrawSphere(pos, 0.1f);
        }
    }
    private void Update()
    {
        Instantiate(point,pos, Quaternion.identity);
    }
}
