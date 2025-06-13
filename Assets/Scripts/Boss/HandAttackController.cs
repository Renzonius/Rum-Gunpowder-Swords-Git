using System.Collections;
using UnityEngine;

public class HandAttackController : MonoBehaviour
{
    [SerializeField] private Transform targetShadowTransform;
    [SerializeField] private bool isAttacking = false;

    private Vector3 initialPosition;
    [SerializeField] private ShadowHandController shadowHandController;

    [SerializeField] private BoxCollider2D boxCollider2D;
    [Header("CAMERA SHAKE")]
    public float amplitude;
    public float frequency;
    public float duration;
    public bool IsAttacking { get => isAttacking; }

    private void Start()
    {
        transform.position = initialPosition;
    }

    private void OnEnable()
    {
        initialPosition = new Vector3(transform.position.x, targetShadowTransform.position.y + 16f, transform.position.z);
        HandAttack();
    }

    public void HandAttack(float moveDuration = 0.5f, float waitTime = 1f)
    {
        StartCoroutine(HandAttackCoroutine(moveDuration, waitTime));
    }

    private IEnumerator HandAttackCoroutine(float moveDuration, float waitTime)
    {
        yield return MoveDownCoroutine(moveDuration);

        yield return new WaitForSeconds(waitTime);

        yield return MoveUpCoroutine(moveDuration);
    }

    public IEnumerator MoveDownCoroutine(float moveDuration)
    {
        isAttacking = true;
        Vector3 start = transform.position;
        Vector3 end = new Vector3(transform.position.x, targetShadowTransform.position.y, transform.position.z);

        float elapsed = 0f;
        while (elapsed < moveDuration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / moveDuration;
            transform.position = Vector3.Lerp(start, end, t);

            shadowHandController.ChangeSize(transform);
            yield return null;
        }
        transform.position = end;
        CameraShake.Instance.Shake(amplitude, frequency, duration); //efecto shake.
        boxCollider2D.enabled = true;
    }

    public IEnumerator MoveUpCoroutine(float moveDuration)
    {
        boxCollider2D.enabled = false;
        Vector3 start = transform.position;
        Vector3 end = initialPosition;

        float elapsed = 0f;
        while (elapsed < moveDuration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / moveDuration;
            transform.position = Vector3.Lerp(start, end, t);

            shadowHandController.ChangeSize(transform);
            yield return null;
        }
        transform.position = end;
        isAttacking = false;
    }
}
