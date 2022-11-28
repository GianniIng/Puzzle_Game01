using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private GameObject selectedGo;
    private Camera mc;
    float lx, ly;
    private Rigidbody rb;
    private bool isColliding = false;

    void Start()
    {
        if (mc == null) mc = Camera.main;
        if (rb == null) rb = GetComponent<Rigidbody>(); 
    }

    void Update()
    {
        stopPlayerMovement();
    }

    private void OnMouseDown()
    {
        RaycastHit hit = findingAnObjectRC();
        if(selectedGo == null)
            if (hit.collider.gameObject.CompareTag("Player") || hit.collider.gameObject.CompareTag("Tile"))
            {
                selectedGo = hit.collider.gameObject;
                Cursor.visible = false;
                
                selectedGo.GetComponent<Renderer>().
                    material.color = Color.red;
            }

        
    }
    private void OnMouseDrag()
    {
        if(!isColliding && selectedGo != null)
        {
            lx = Input.mousePosition.x;
            ly = Input.mousePosition.y;
            Vector3 position = new Vector3(lx, ly, 
                mc.WorldToScreenPoint(selectedGo.transform.position).z);
            Vector3 worldPos = mc.ScreenToWorldPoint(position);
            rb.MovePosition(new Vector3(worldPos.x, 0.27f, worldPos.z));
        }
    }
    private void OnMouseUp()
    {
        Cursor.visible = true;
        Vector3 position = new Vector3(lx, ly, mc.WorldToScreenPoint(selectedGo.transform.position).z);
        Vector3 worldPos = mc.ScreenToWorldPoint(position);
        Vector3 playerPos = rb.position;
        if (isColliding)
        {
            rb.MovePosition(new Vector3(rb.position.x, 
               rb.position.y, rb.position.z - 0.3f));
            selectedGo = null;
            isColliding = false;
        }
        rb.MovePosition(new Vector3(rb.position.x, 
            rb.position.y, Mathf.Round(rb.position.z - 0.3f)));

    }
    private void stopPlayerMovement()
    {
        Vector3 origin = transform.position;
        Vector3 direction = transform.forward;
        float dangerDistance = 2f;
        Ray ray = new Ray(origin, direction);
        Debug.DrawRay(origin, direction * dangerDistance, Color.white);
        if (Physics.Raycast(ray, out RaycastHit h, dangerDistance))
        {
            if (h.collider.gameObject.CompareTag("Wall01") || h.collider.gameObject.CompareTag("EndLevel"))
                isColliding = true;
        }
        Debug.DrawRay(origin, direction * -dangerDistance, Color.blue);
        if (Physics.Raycast(ray, out RaycastHit c, dangerDistance))
        {
            if (h.collider.gameObject.CompareTag("Wall01"))
                isColliding = true;
        }
    }
 /*   private void OnMouseCollider()
    {
        Vector3 o = transform.position;
        Vector3 d = transform.forward;
        float dD = 2f;
        Ray ray = new Ray(o, d);
        Debug.DrawRay(o, d * dD, Color.white);
        if (Physics.Raycast(ray, out RaycastHit h, dD))
        {        
            if (h.transform.tag == "EndLevel")
            {
                EndGoal.gameOver = true;
            }

        }
 
    }*/
    private RaycastHit findingAnObjectRC()
    {
        Vector2 mouseScreenPosition = Input.mousePosition;
        Ray ray = mc.ScreenPointToRay(mouseScreenPosition);
        Physics.Raycast(ray, out RaycastHit h);
        return h;
    }
}
