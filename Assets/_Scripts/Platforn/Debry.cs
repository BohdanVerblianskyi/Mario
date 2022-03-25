using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debry : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;

    public void AddForceDebry(Vector3 pointForce)
    {
        Vector2 forse = transform.position - pointForce;
        _rigidbody2D.AddForce(forse * 7, ForceMode2D.Impulse);
        StartCoroutine(WaitForDestroy());
    }

    private IEnumerator WaitForDestroy()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }

}
