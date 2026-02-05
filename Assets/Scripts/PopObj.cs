using System.Collections;
using UnityEngine;

public class PopObj : MonoBehaviour
{
    [SerializeField] private float pushForce = 40f;
    [SerializeField] private float sponeTime = 5f;

    private Collider col;
    private Renderer[] rends;

    private void Awake()
    {
        col = GetComponent<Collider>();
        rends = GetComponentsInChildren<Renderer>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<Player>().differVerticalPower(pushForce);
            StartCoroutine(spone());
        }
    }

    private IEnumerator spone()
    {
        objSetActive(false);
        yield return new WaitForSeconds(sponeTime);
        objSetActive(true);
    }

    private void objSetActive(bool active)
    {
        foreach (var rend in rends) rend.enabled = active;
        col.enabled = active;
    }
}
