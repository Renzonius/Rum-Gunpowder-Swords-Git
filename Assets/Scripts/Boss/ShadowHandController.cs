using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class ShadowHandController : MonoBehaviour
{
    [SerializeField] private bool isFollowingPlayer = false;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Transform handTransform;

    [SerializeField] private Vector2 maxShadowHandSize = new Vector2(2f, 2f);
    [SerializeField] private Vector2 minShadowHandSize = new Vector2(0.25f, 0.25f);


    private void Update()
    {
        if(isFollowingPlayer == true)
        {
            FollowPlayer();
        }
    }

    public void stopFollowingPlayer()
    {
        isFollowingPlayer = false;
    }

    public void StartFollowingPlayer()
    {
        isFollowingPlayer = true;
    }

    public void FollowPlayer()
    {
        float followTime = 5f; //Persigue al jugador durante 5 segundos.
        while (followTime > 0)
        {
            transform.position = new Vector2(transform.position.x, playerTransform.position.y);
            followTime -= Time.deltaTime;
        }
    }



    public void ChangeSize(Transform handTransform)
    {
        //Distancia inicial de la mano respecto de la sombra
        float distance = Vector2.Distance(handTransform.position, transform.position);

        //Distancia para el cambio de tamaño
        float minDistance = 0.1f;
        float maxDistance = 12f;
        float t = Mathf.InverseLerp(minDistance, maxDistance, distance);

        //Mínimo y el máximo definido
        Vector2 minSize = minShadowHandSize;
        Vector2 newSize = Vector2.Lerp(maxShadowHandSize, minSize, t);

        //Aplicamos la escala
        transform.localScale = new Vector3(newSize.x, newSize.y, transform.localScale.z);
    }
}
