using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraResolution : MonoBehaviour
{
    public float width;
    public float height;

    private void Awake()
    {
        Camera cam = GetComponent<Camera>();

        Rect viewportRect = cam.rect;

        float screenAspectRatio = (float)Screen.width / Screen.height;
        float targetAspectRatio = width / height;

        if (screenAspectRatio < targetAspectRatio)
        {
            viewportRect.height = screenAspectRatio / targetAspectRatio;
            viewportRect.y = (1f - viewportRect.height) / 2f;
        }
        else
        {
            viewportRect.width = targetAspectRatio / screenAspectRatio;
            viewportRect.x = (1f - viewportRect.width) / 2f;
        }

        cam.rect = viewportRect;
    }

    private void OnPreCull()
    {
        GL.Clear(true, true, Color.black);
    }
}
