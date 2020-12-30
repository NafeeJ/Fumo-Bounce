using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Set this to your target aspect ratio, eg. (16, 9) or (4, 3).
    public Vector2 targetAspect;

    private Camera myCamera;
    private EdgeCollider2D cameraCollider;
    private Vector2[] edgePoints;

    void Start()
    {
        targetAspect = new Vector2(Screen.currentResolution.width, Screen.currentResolution.height);
        myCamera = GetComponent<Camera>();
        cameraCollider = GetComponent<EdgeCollider2D>();
        edgePoints = new Vector2[5];
        SetEdgeColliders();
    }

    void Update()
    {
        if (Screen.width != targetAspect.x || Screen.height != targetAspect.y)
        {
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

    public void SetEdgeColliders()
    {
        //Vector2's for the corners of the screen
        Vector2 bottomLeft =  myCamera.ScreenToWorldPoint(new Vector3(0, 0, myCamera.nearClipPlane));
        Vector2 topRight = myCamera.ScreenToWorldPoint(new Vector3(myCamera.pixelWidth, myCamera.pixelHeight, myCamera.nearClipPlane));
        Vector2 topLeft = new Vector2(bottomLeft.x, topRight.y);
        Vector2 bottomRight = new Vector2(topRight.x, bottomLeft.y);

        //Update Vector2 array for edge collider
        edgePoints[0] = bottomLeft;
        edgePoints[1] = topLeft;
        edgePoints[2] = topRight;
        edgePoints[3] = bottomRight;
        edgePoints[4] = bottomLeft;

        cameraCollider.points = edgePoints;
    }
}