using UnityEngine;

public class Drawer : MonoBehaviour
{
    private float drawDistance = 0.0f;
    private float drawingSpeed = 0.5f;
    private bool swapColor = false;
    private Material material;
    private Collider meCollider;
    

    private Vector2 clickUVCoords = new Vector2(0.5f, 0.5f);

    private void Start()
    {
        material = GetComponent<MeshRenderer>().material;
        meCollider = GetComponent<Collider>();
        material.SetFloat("Distance", drawDistance);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (meCollider.Raycast(ray, out hit, Mathf.Infinity))
            {
                clickUVCoords = hit.textureCoord;
                swapColor = true;
            }
        }

        if (swapColor)
        {
            drawDistance += drawingSpeed * Time.deltaTime;
        }

        material.SetFloat("_Distance", drawDistance);
        material.SetFloat("_ClickCoordX", clickUVCoords.x);
        material.SetFloat("_ClickCoordY", clickUVCoords.y);
    }
}