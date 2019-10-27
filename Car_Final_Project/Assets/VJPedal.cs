using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class VJPedal : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    public float value;
    public float rampUpSpeed = 0.05f;


    private bool pressed;

    // Start is called before the first frame update
    void Start()
    {
        value = 0f;
    }

    void FixedUpdate()
    {
        if(pressed)
        {
            value += rampUpSpeed;

            if(value > 1f)
            {
                value = 1f;
            }
        }
    }

    public void OnPointerDown(PointerEventData ped){
        pressed = true;
    }
    
    public void OnPointerUp(PointerEventData ped){
        value = 0f;
        pressed = false;
    }
}
