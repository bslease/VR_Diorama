using System.Collections;
using UnityEngine;

public class LookMoveTo : MonoBehaviour
{
    private Transform camera;
    public GameObject ground;

    private void Start()
    {
        camera = Camera.main.transform;
    }

    private void Update()
    {
        Ray ray;
        RaycastHit[] hits;
        GameObject hitObject;

        Debug.DrawRay(camera.position, camera.rotation * Vector3.forward * 100.0f);
        // Vector3.forward is just shorthand for (0,0,1)
        // we just need to shoot a ray straight into the scene in the direction we're looking
        ray = new Ray(camera.position, camera.rotation * Vector3.forward);
        hits = Physics.RaycastAll(ray);
        for (int i=0; i < hits.Length; i++)
        {
            RaycastHit hit = hits[i];
            hitObject = hit.collider.gameObject;
            if (hitObject == ground)
            {
                Debug.Log("Hit (x,y,z): " + hit.point.ToString("F2"));
                transform.position = hit.point;
            }
        }
    }
}

