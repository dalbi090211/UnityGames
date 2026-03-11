using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class dimensionManager : MonoBehaviour
{
    [SerializeField] private CinemachineCamera Camera3DMove;
    [SerializeField] private CinemachineCamera Camera2DMove;
    [SerializeField] private Player player;
    public static int curDimension = 3;

    public void Awake()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!other.gameObject.CompareTag("Player")) return;
        if(curDimension == 3)
        {
            curDimension = 2;
        }
        else
        {
            curDimension = 3;
        }

        switchCamera();
        player.switchDimension(curDimension);

    }

    private void switchCamera()
    {
        if(curDimension == 2)
        {
            curDimension = 2;
            Camera2DMove.Priority = 10;
            Camera3DMove.Priority = 1;   
        }
        else
        {
            curDimension = 3;
            Camera2DMove.Priority = 1;
            Camera3DMove.Priority = 10; 
        }
    }
}
