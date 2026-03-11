using UnityEngine;
using UnityEngine.TextCore.Text;

public class PlayerHitted : MonoBehaviour
{
    private float hitDuration = 0.2f;
    private CharacterController cc;
    private float timer = 0f;
    private Vector3 hitVelocity;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    public void ApplyHitVelocity(Vector3 dir, float force)
    {
        Debug.Log("hitted");
        hitVelocity = dir * force;
        timer = hitDuration;        
    }

    // Update is called once per frame
    void Update()
    {
        if(timer > 0f)
        {
            cc.Move(hitVelocity * Time.deltaTime);
            timer -= Time.deltaTime;
        }
    }
}
