using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public float zoomSpeed = 5f;
    public float minZoom = 1f;
    public float maxZoom = 12f;

    public float panSpeed = 50;
    public float mouseX;
    public float mouseY;
    public float maxPan = 10;
    public float minPan = -10;


    private Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;

    }

    // Update is called once per frame
    void Update()
    {
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");

        float zoomAmount = scrollInput * zoomSpeed;

        float currentZoom = mainCamera.orthographicSize;

        if (zoomAmount > 0f)
        {
            currentZoom -= Mathf.Abs(zoomAmount);
        }
        else if (scrollInput < 0f)
        {
            currentZoom += Mathf.Abs(zoomAmount);
        }

        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);

        mainCamera.orthographicSize = currentZoom;



        if (Input.GetMouseButton(1))
        {
            float currentPanSpeed = panSpeed + (mainCamera.orthographicSize / 4) * panSpeed;


            mouseX = currentPanSpeed * Input.GetAxis("Mouse X");
            mouseY = currentPanSpeed * Input.GetAxis("Mouse Y");

            float currentX = transform.position.x;
            float currentY = transform.position.y;

            currentX += mouseX * Time.deltaTime;
            currentY += mouseY * Time.deltaTime;

            currentX = Mathf.Clamp(currentX, minPan, maxPan);
            currentY = Mathf.Clamp(currentY, minPan, maxPan);

            transform.position = new Vector3(currentX, currentY, -10);
        }

    }
}
