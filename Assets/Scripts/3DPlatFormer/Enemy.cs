using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float force = 10f;
    [SerializeField] float hitForce = 10f;
    [SerializeField] float life = 8f;
    
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.right * force);
        StartCoroutine(dispone());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Vector3 pushDir = (other.transform.position - transform.position).normalized;
            other.GetComponent<PlayerHitted>().ApplyHitVelocity(pushDir, hitForce);
        }
    }

    private IEnumerator dispone()
    {
        yield return new WaitForSeconds(life);
        Destroy(gameObject);
    }
}
