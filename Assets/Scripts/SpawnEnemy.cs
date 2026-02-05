using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private float sponeTimer;
    [SerializeField] private GameObject enemyObj;
    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= sponeTimer)
        {
            timer = 0f;
            Instantiate(enemyObj, transform.position + Vector3.right * 0.5f, Quaternion.identity);
        }
    }
}
