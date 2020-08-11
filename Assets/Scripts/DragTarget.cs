using UnityEngine;

//Modified from: https://github.com/Unity-Technologies/PhysicsExamples2D

/// <summary>
/// Drag a Rigidbody2D by selecting one of its colliders by pressing the mouse down.
/// When the collider is selected, add a TargetJoint2D.
/// While the mouse is moving, continually set the target to the mouse position.
/// When the mouse is released, the TargetJoint2D is deleted.`
/// </summary>
public class DragTarget : MonoBehaviour
{
	public LayerMask m_DragLayers;

	[Range (0.0f, 100.0f)]
	public float m_Damping = 1.0f;

	[Range (0.0f, 100.0f)]
	public float m_Frequency = 5.0f;

	private TargetJoint2D m_TargetJoint;

	private GameObject selectedFumo;
	private Vector2 selectedFumoScale;

	void Update ()
	{
		// Calculate the world position for the mouse.
		Vector2 worldPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);

		if (Input.GetMouseButtonDown (0))
		{
			// Fetch the first collider.
			// NOTE: We could do this for multiple colliders.
			Collider2D collider = Physics2D.OverlapPoint (worldPos, m_DragLayers);
			if (!collider)
				return;

			// Fetch the collider body.
			Rigidbody2D body = collider.attachedRigidbody;
			if (!body)
				return;

			// Add a target joint to the Rigidbody2D GameObject.
			m_TargetJoint = body.gameObject.AddComponent<TargetJoint2D> ();
			m_TargetJoint.dampingRatio = m_Damping;
			m_TargetJoint.frequency = m_Frequency;

			// Attach the anchor to the local-point where we clicked.
			m_TargetJoint.anchor = m_TargetJoint.transform.InverseTransformPoint (worldPos);

			selectedFumo = body.gameObject;
			selectedFumoScale = selectedFumo.transform.localScale;
			selectedFumo.transform.localScale = new Vector2(selectedFumoScale.x * 1.1f, selectedFumoScale.y * 1.1f);
		}
		else if (Input.GetMouseButtonUp (0))
		{
			Destroy (m_TargetJoint);
			m_TargetJoint = null;

			if (selectedFumo != null)
			{
				selectedFumo.transform.localScale = selectedFumoScale;
			}

			return;
		}

		// Update the joint target.
		if (m_TargetJoint)
		{
			m_TargetJoint.target = worldPos;
		}
	}
}
