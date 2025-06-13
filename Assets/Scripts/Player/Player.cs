using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("CRUSHED EFFECT")]
    [SerializeField] private Transform playerTransform;


    private void OnTriggerEnter2D(Collider2D tri)
    {
        string tag = tri.gameObject.tag;
        if (tri.CompareTag("HandAttack"))
        {
            StartCoroutine(CrushedEffectCoroutine());
        }

    }

    IEnumerator CrushedEffectCoroutine()
    {
        playerTransform.localScale = new Vector3(1f, 0.5f, 1f);
        transform.localScale = playerTransform.localScale;
        yield return new WaitForSeconds(3f);
        playerTransform.localScale = new Vector3(1f, 1f, 1f);
        transform.localScale = playerTransform.localScale;
    }

}
