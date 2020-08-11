using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Set this to your target aspect ratio, eg. (16, 9) or (4, 3).
    public Vector2 targetAspect = new Vector2(16, 9);

    private Camera myCamera;
    private EdgeCollider2D cameraColliders;
    private Vector2[] colliderPoints;

    void Start()
    {
        myCamera = GetComponent<Camera>();
        cameraColliders = GetComponent<EdgeCollider2D>();
        colliderPoints = new Vector2[5];
        UpdateCrop();
        SetEdgeColliders();
    }

    void Update()
    {
        if (Screen.width != targetAspect.x || Screen.height != targetAspect.y)
        {
            UpdateCrop();
            SetEdgeColliders();
        }
    }

    //Adapted from: https://gamedev.stackexchange.com/questions/144575/how-to-force-keep-the-aspect-ratio-and-specific-resolution-without-stretching-th
    // Call this method if your window size or target aspect change.
    public void UpdateCrop()
    {
        // Determine ratios of screen/window & target, respectively.
        float screenRatio = Screen.width / (float)Screen.height;
        float targetRatio = targetAspect.x / targetAspect.y;

        if (Mathf.Approximately(screenRatio, targetRatio))
        {
            // Screen or window is the target aspect ratio: use the whole area.
            myCamera.rect = new Rect(0, 0, 1, 1);
        }
        else if (screenRatio > targetRatio)
        {
            // Screen or window is wider than the target: pillarbox.
            float normalizedWidth = targetRatio / screenRatio;
            float barThickness = (1f - normalizedWidth) / 2f;
            myCamera.rect = new Rect(barThickness, 0, normalizedWidth, 1);
        }
        else
        {
            // Screen or window is narrower than the target: letterbox.
            float normalizedHeight = screenRatio / targetRatio;
            float barThickness = (1f - normalizedHeight) / 2f;
            myCamera.rect = new Rect(0, barThickness, 1, normalizedHeight);
        }
    }

    //Modified and Adapted from: https://forum.unity.com/threads/collision-with-sides-of-screen.228865/
    public void SetEdgeColliders()
    {
        Vector2 lDCorner = myCamera.ViewportToWorldPoint(new Vector3(0, 0f, myCamera.nearClipPlane));
        Vector2 rUCorner = myCamera.ViewportToWorldPoint(new Vector3(1f, 1f, myCamera.nearClipPlane)); 

        colliderPoints[0] = new Vector2(lDCorner.x, lDCorner.y);
        colliderPoints[1] = new Vector2(lDCorner.x, rUCorner.y);
        colliderPoints[2] = new Vector2(rUCorner.x, rUCorner.y);
        colliderPoints[3] = new Vector2(rUCorner.x, lDCorner.y);
        colliderPoints[4] = colliderPoints[0];

        cameraColliders.points = colliderPoints;
    }
}