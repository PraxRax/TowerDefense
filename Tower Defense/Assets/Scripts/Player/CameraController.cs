using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float panSpeed;

    public float scrollSpeed;
    public float minY;
    public float maxY;

    void Update()
    {
        if (GameManager.GameIsOver)
        {
            this.enabled = false;
            return;
        }

        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            // Vector3.forward = new Vector3(0f, 0f, 1f) in other words 
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime * Input.GetAxisRaw("Horizontal"), Space.World);
        }
        if (Input.GetAxisRaw("Vertical") != 0)
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime * Input.GetAxisRaw("Vertical"), Space.World);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 pos = transform.position;

        pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        transform.position = pos;
    }
}
