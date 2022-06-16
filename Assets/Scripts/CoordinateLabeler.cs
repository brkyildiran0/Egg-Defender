using UnityEngine;
using TMPro;
using System;

[ExecuteAlways]
[RequireComponent(typeof(TextMeshPro))]
public class CoordinateLabeler : MonoBehaviour
{
    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color blockedColor = Color.gray;

    TextMeshPro label;
    Waypoint waypoint;
    Vector2Int coordinates = new Vector2Int();

    void Awake()
    {
        label = GetComponent<TextMeshPro>();
        label.enabled = false;

        waypoint = GetComponentInParent<Waypoint>();

        DisplayCoordinates();
    }

    void Update()
    {
        if (!Application.isPlaying)
        {
            DisplayCoordinates();
            UpdateObjectName();
        }

        AlterCoordinateColors();
        ToggleLabels();
    }

    void UpdateObjectName()
    {
        transform.parent.name = coordinates.ToString();
    }

    void DisplayCoordinates()
    {
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x); //REMOVE BEFORE BUILD or MOVE TO Build FOLDER
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z); //REMOVE BEFORE BUILD or MOVE TO Build FOLDER
        label.text = coordinates.x + "," + coordinates.y;
    }

    void ToggleLabels()
    {
        if (Input.GetKeyDown(KeyCode.AltGr))
        {
            label.enabled = !label.enabled;
        }
    }

    void AlterCoordinateColors()
    {
        if (waypoint.IsPlaceable) { label.color = defaultColor; }
        else { label.color = blockedColor; }
    }
}
