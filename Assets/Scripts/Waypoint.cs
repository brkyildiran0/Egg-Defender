using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] GameObject ballista;

    [SerializeField] bool isPlaceable;
    public bool IsPlaceable { get { return isPlaceable; } }


    void OnMouseDown()
    {
        if (isPlaceable)
        {
            Instantiate(ballista, transform.position, Quaternion.identity);
            isPlaceable = false;
        }
    }
}
