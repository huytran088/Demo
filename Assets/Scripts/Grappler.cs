using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Grappler : MonoBehaviour
{
    public Camera mainCamera;
    [SerializeField] private PlayerMovement player;
    [SerializeField] private LineRenderer _lineRenderer;
    [SerializeField] private DistanceJoint2D _distanceJoint;

    [SerializeField] private Tilemap tilemap;
    [SerializeField] private TilemapCollider2D collider;

    // Start is called before the first frame update
    void Start()
    {
        _distanceJoint.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Vector2 mousePos = (Vector2)mainCamera.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int cellPos = tilemap.WorldToCell(mousePos);

            // Check if the mouse is over a tile on the layer
            if (tilemap.GetTile(cellPos) != null)
            {
                _lineRenderer.SetPosition(0, mousePos);
                _lineRenderer.SetPosition(1, transform.position);
                _distanceJoint.connectedAnchor = mousePos;
                _distanceJoint.enabled = true;
                _lineRenderer.enabled = true;
            }

        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            _distanceJoint.enabled = false;
            _lineRenderer.enabled = false;
        }
        if (_distanceJoint.enabled) 
        {
            _lineRenderer.SetPosition(1, transform.position);
        }
    }
}
