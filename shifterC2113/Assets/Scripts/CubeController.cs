using System.Collections;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    private Rigidbody _rb;

    private void OnEnable()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.isKinematic = true;

        Invoke("DropCube", 2.5f);
    }


    public void RiceCube()
    {
        StartCoroutine(Rice());
    }

    IEnumerator Rice()
    {
        for (int i = 0; i < 100; i++) 
        {
            transform.position = transform.position + transform.up * 0.005f;
            yield return new WaitForSeconds(0.001f);
        }
    }

    public void DropCube()
    {
        _rb.isKinematic = false;
        Invoke("DestroyCube", 2f);
    }

    public void DestroyCube()
    {
        Destroy(gameObject);
    }
}
