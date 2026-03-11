using UnityEngine;

public class ColorManager : MonoBehaviour
{
    public static ColorManager instance { get; private set; }

    private Color32 white = new Color32(255, 255, 255, 255);
    private Color32 black = new Color32(0, 0, 0, 255);

    [SerializeField] private Material platform1Mat; //조작 가능한 플랫폼
    [SerializeField] private Material platform2Mat; //불가한 플랫폼
    [SerializeField] private PlayerMovement playerMove;

    private Color32 currentColor;

    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this;
            Debug.Assert(playerMove != null, "PlayerMovement is not assigned");
            setColor(white);
        }
    }

    public void TransWorldColor()
    {
        if (currentColor.Equals(white))
        {
            setColor(black);
        }
        else if (currentColor.Equals(black))
        {
            setColor(white);
        }
        else
        {
            Debug.Log("잘못된 값으로 초기화되어있습니다. 하얀색으로 초기화 합니다.");
            setColor(white);
        }
        
        if(playerMove == null)
        {
            var go = GameObject.FindGameObjectWithTag("Player");
            if (go != null) playerMove = go.transform.GetComponent<PlayerMovement>();
        }
        playerMove.chgGravity();
    }

    private void setColor(Color32 color)
    {
        if (color.Equals(white))
        {
            currentColor = white;
            platform1Mat.color = white;
            platform2Mat.color = black;
        }
        else
        {
            currentColor = black;
            platform1Mat.color = black;
            platform2Mat.color = white;
        }
    }
}
