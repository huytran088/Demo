using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class RopeController : MonoBehaviour
{
    [SerializeField] GameObject ropeShooter;
    private SpringJoint2D rope;
    [SerializeField] private int maxRopeFrameCount;
    private int ropeFrameCount;

    [SerializeField] LineRenderer lineRenderer;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            Fire();
    }

    private void LateUpdate()
    {
        if (rope != null)
        {
            lineRenderer.enabled = true;
            lineRenderer.positionCount = 2;  // A straight line
            lineRenderer.SetPosition(0, ropeShooter.transform.position);
            lineRenderer.SetPosition(0, rope.connectedAnchor);
        }
        else
        {
            lineRenderer.enabled = false;
        }
    }

    private void FixedUpdate()
    {
        if (rope != null)
        {
            ropeFrameCount++;
        }
        if (ropeFrameCount > maxRopeFrameCount)
        {
            GameObject.DestroyImmediate(rope);
            ropeFrameCount = 0;
        }
    }

    private void Fire()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 position = ropeShooter.transform.position;
        Vector3 direction = mousePosition - position;

        RaycastHit2D hit = Physics2D.Raycast(position, direction);

        // if hit, create a new rope attach to hit point
        if (hit.collider != null)
        {

            SpringJoint2D newRope = ropeShooter.AddComponent<SpringJoint2D>();
            newRope.enableCollision = false;
            newRope.frequency = 0.05f;
            newRope.distance = 5f;
            newRope.connectedAnchor = hit.point;
            newRope.enabled = true;

            GameObject.DestroyImmediate(rope);
            rope = newRope;
            ropeFrameCount = 0;

        }

    }
}
