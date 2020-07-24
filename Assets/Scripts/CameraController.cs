/*
Modified from:
https://forum.unity.com/threads/collision-with-sides-of-screen.228865/
https://gamedev.stackexchange.com/questions/144575/how-to-force-keep-the-aspect-ratio-and-specific-resolution-without-stretching-th
*/

using UnityEngine;

namespace UnityLibrary
{
    public class CameraController : MonoBehaviour
    {
        // Set this to your target aspect ratio, eg. (16, 9) or (4, 3).
        public Vector2 targetAspect = new Vector2(16, 9);
        private Camera myCamera;

        void Start()
        {
            myCamera = GetComponent<Camera>();
            UpdateCrop();
            CreateEdgeColliders();
        }

        void Update()
        {
            if (Screen.width != 16 || Screen.height != 9)
            {
                UpdateCrop();

                EdgeCollider2D[] colliders = GetComponents<EdgeCollider2D>();

                foreach (EdgeCollider2D collider in colliders)
                {
                    Destroy(collider);
                }

                CreateEdgeColliders();
            }
        }

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

        public void CreateEdgeColliders()
        {
            Vector2 lDCorner = myCamera.ViewportToWorldPoint(new Vector3(0, 0f, myCamera.nearClipPlane));
            Vector2 rUCorner = myCamera.ViewportToWorldPoint(new Vector3(1f, 1f, myCamera.nearClipPlane));
            Vector2[] colliderpoints;

            EdgeCollider2D upperEdge = myCamera.gameObject.AddComponent<EdgeCollider2D>();
            colliderpoints = upperEdge.points;
            colliderpoints[0] = new Vector2(lDCorner.x, rUCorner.y);
            colliderpoints[1] = new Vector2(rUCorner.x, rUCorner.y);
            upperEdge.points = colliderpoints;

            EdgeCollider2D lowerEdge = myCamera.gameObject.AddComponent<EdgeCollider2D>();
            colliderpoints = lowerEdge.points;
            colliderpoints[0] = new Vector2(lDCorner.x, lDCorner.y);
            colliderpoints[1] = new Vector2(rUCorner.x, lDCorner.y);
            lowerEdge.points = colliderpoints;

            EdgeCollider2D leftEdge = myCamera.gameObject.AddComponent<EdgeCollider2D>();
            colliderpoints = leftEdge.points;
            colliderpoints[0] = new Vector2(lDCorner.x, lDCorner.y);
            colliderpoints[1] = new Vector2(lDCorner.x, rUCorner.y);
            leftEdge.points = colliderpoints;

            EdgeCollider2D rightEdge = myCamera.gameObject.AddComponent<EdgeCollider2D>();

            colliderpoints = rightEdge.points;
            colliderpoints[0] = new Vector2(rUCorner.x, rUCorner.y);
            colliderpoints[1] = new Vector2(rUCorner.x, lDCorner.y);
            rightEdge.points = colliderpoints;
        }
    }
}