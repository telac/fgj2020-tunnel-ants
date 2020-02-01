using UnityEngine;
using System.Collections;

public class DragCamera : MonoBehaviour
{
    private Vector3 resetCamera;
    private Vector3 origin;
    private Vector3 difference;
    private Vector3 clampedPos;
    private bool drag = false;
    private Camera cam;

    public Vector3 llCorner = new Vector3(-17, 10, -20);
    public Vector3 urCorner = new Vector3(17, 10, 20);

    private void Awake() {
        cam = Camera.main;
        resetCamera = cam.transform.position;
    }

    private void LateUpdate() {
        if (Input.GetMouseButton(0))
        {
            difference = (cam.ScreenToWorldPoint(Input.mousePosition)) - cam.transform.position;
            if (drag == false)
            {
                drag = true;
                origin = cam.ScreenToWorldPoint(Input.mousePosition);
            }
        }
        else
            drag = false;

        if (drag == true)
            cam.transform.position = origin - difference;

        if (Input.GetMouseButton(1))
            cam.transform.position = resetCamera;

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
