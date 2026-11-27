using UnityEngine;

public class peremobject : MonoBehaviour
{
    public float speed = 20f;
    private bool drag;
    private Vector3 offset;
    private Camera cam;
    private Collider2D col;

    private void Awake()
    {
        cam = Camera.main;
        col = GetComponent<Collider2D>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Collider2D hit = Physics2D.OverlapPoint(MouseWorld());

            if (hit != null && hit == col)
            {
                drag = true;
                offset = transform.position - MouseWorld();
            }
        }

        if (Input.GetMouseButtonUp(0))
            drag = false;

        if (drag)
            transform.position = Vector3.MoveTowards(
                transform.position,
                MouseWorld() + offset,
                speed * Time.deltaTime);
    }

    private Vector3 MouseWorld()
    {
        Vector3 p = cam.ScreenToWorldPoint(new Vector3(
            Input.mousePosition.x,
            Input.mousePosition.y,
            -cam.transform.position.z));
        p.z = 0.05f;
        return p;
    }
}
