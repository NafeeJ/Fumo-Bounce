//Modified from https://forum.unity.com/threads/collision-with-sides-of-screen.228865/

using UnityEngine;
using System.Collections;

namespace UnityLibrary
{
    public class CameraEdgeColliders : MonoBehaviour
    {
        void Awake()
        {
            Camera myCamera = Camera.main;

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