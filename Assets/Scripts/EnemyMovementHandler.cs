using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementHandler : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    [SerializeField] [Range(0f,5f)] float m_speed = 1f;

    void OnEnable()
    {
        FindPath();
        ReturnToStart();
        StartCoroutine(FollowPath());
    }

    void FindPath()
    {
        path.Clear();

        GameObject parentOfAllTiles = GameObject.FindGameObjectWithTag("Path");

        foreach (Transform child in parentOfAllTiles.transform)
        {
            path.Add(child.GetComponent<Waypoint>());
        }
    }

    void ReturnToStart()
    {
        transform.position = path[0].transform.position;
    }

    IEnumerator FollowPath()
    {
        foreach (var waypoint in path)
        {
            Vector3 startPosition = transform.position;
            Vector3 endPosition = waypoint.transform.position;
            float travelPercentage = 0.0f;

            transform.LookAt(endPosition);

            while (travelPercentage < 1f)
            {
                travelPercentage += Time.deltaTime * m_speed;
                transform.position = Vector3.Lerp(startPosition, endPosition, travelPercentage);
                yield return new WaitForEndOfFrame();
            }
        }

        //If code reaches this point, it means that the rim has successfully survived the defense.
        gameObject.SetActive(false);
    }
}
