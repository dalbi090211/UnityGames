using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class GravityChanger : MonoBehaviour
{
    [SerializeField] private float setTime = 5.0f;
    [SerializeField] private float maxSize = 1.5f;
    private GameObject Fill;
    private float timer = 0f;

    private void Start()
    {
        Fill = transform.Find("Fill").transform.gameObject;
        timer = 0f;
    }

    private void Update()
    {
        if(timer >= setTime)
        {
            ColorManager.instance.TransWorldColor();
            timer = 0f;
        }
        timer += Time.deltaTime;
        changeScale(timer/setTime); 
    }

    private void changeScale(float ratio)
    {
        Vector3 scaleVal = new Vector3(maxSize * ratio, maxSize * ratio, 1);
        Fill.transform.localScale = scaleVal;
    }

}
