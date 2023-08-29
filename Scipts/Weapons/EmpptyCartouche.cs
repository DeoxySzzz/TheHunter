using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmpptyCartouche : MonoBehaviour
{
    [SerializeField] AudioClip shellDrop;

    private void Awake()
    {
        transform.Translate(0.5f, -0.2f, 0);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Finish"))
        {
            AudioSource.PlayClipAtPoint(shellDrop, transform.position);
        }
    }
}
