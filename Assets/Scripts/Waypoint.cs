using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] bool isPlaceable;
    [SerializeField] GameObject ballista;


    void OnMouseDown()
    {
        if (isPlaceable)
        {
            Instantiate(ballista, transform.position, Quaternion.identity);
            isPlaceable = false;
        }
    }
}
