using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class BossHand : MonoBehaviour
{
    [SerializeField] private bool isActivate = false;
    [SerializeField] private float healthHand = 1000f;

    [Header("HAND SETTINGS")]
    [SerializeField] private GameObject hand;
    [SerializeField] private GameObject handAttack;
    [SerializeField] private GameObject handShadow;
    [SerializeField] private float followPlayerTime;
    [SerializeField] private float attackTime;
    //El tiempo tiene que ser lo suficientemente largo para que la mano vuelva a su origen.
    [SerializeField] private float timeToRestart = 10f;

    private void Start()
    {
        StartCoroutine(HandSequense());
    }

    IEnumerator HandSequense()
    {
        while(isActivate == true)
        {
            handShadow.SetActive(true);
            handShadow.GetComponent<ShadowHandController>().StartFollowingPlayer();
            yield return new WaitForSeconds(followPlayerTime);
            handShadow.GetComponent<ShadowHandController>().stopFollowingPlayer();

            handAttack.SetActive(true);
            yield return new WaitForSeconds(attackTime);

            handAttack.SetActive(false);
            handShadow.SetActive(false);

            //Activar la mano que recibe daño.
            yield return new WaitForSeconds(timeToRestart);
        }
    }

}
