using UnityEngine;

public class resetPositioner : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            if(dimensionManager.curDimension == 2) StartCoroutine(other.transform.GetComponent<Player>().changeMove());
        }
    }
}
