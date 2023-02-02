using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float bulletMoveSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.right * -bulletMoveSpeed, Space.World);
    }

    /// <summary>
    /// Use Sprite Renderer component for activate this function
    /// </summary>
    private void OnBecameInvisible()
    {
        // Destroy item but use lot of ressources 
        Destroy(gameObject);
    }
}
