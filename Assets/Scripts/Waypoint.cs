using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] bool isPlaceable;


    void OnMouseDown()
    {
        if (isPlaceable)
        {
            print(transform.name);
        }
    }
}
