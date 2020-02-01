using UnityEngine;
using System.Collections;

public class DragCamera : MonoBehaviour
{
    private Vector3 ResetCamera;
    private Vector3 Origin;
    private Vector3 Diference;
    private Vector3 clampedPos;
    private bool Drag = false;
    private Camera cam;

    public Vector3 llCorner = new Vector3(-17, 10, -20);
    public Vector3 urCorner = new Vector3(17, 10, 20);

    private void Awake() {
        cam = Camera.main;
        ResetCamera = cam.transform.position;
    }

    private void LateUpdate() {
        if (Input.GetMouseButton(0))
        {
            Diference = (cam.ScreenToWorldPoint(Input.mousePosition)) - cam.transform.position;
            if (Drag == false)
            {
                Drag = true;
                Origin = cam.ScreenToWorldPoint(Input.mousePosition);
            }
        }
        else
            Drag = false;

        if (Drag == true)
            cam.transform.position = Origin - Diference;

        if (Input.GetMouseButton(1))
            cam.transform.position = ResetCamera;

        clampedPos = cam.transform.position;
        if (clampedPos.x < llCorner.x)
            clampedPos.x = llCorner.x;

        if (clampedPos.z < llCorner.z)
            clampedPos.z = llCorner.z;

        if (clampedPos.x > urCorner.x)
            clampedPos.x = urCorner.x;

        if (clampedPos.z > urCorner.z)
            clampedPos.z = urCorner.z;

        Camera.main.transform.position = clampedPos;
    }
}
