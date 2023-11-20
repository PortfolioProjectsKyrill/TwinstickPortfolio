using UnityEngine.Events;
using UnityEngine;

public class PickUpItems : MonoBehaviour
{
    public Transform pickupDestination;
    public UnityEvent _pickup;

    void OnMouseDown()
    {
        transform.position = pickupDestination.position;
        transform.rotation = pickupDestination.rotation;
        _pickup.Invoke();
    }
    

}
