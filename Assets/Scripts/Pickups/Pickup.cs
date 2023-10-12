using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField]
    float rotationSpeed = 5f;

    public void Update()
    {
        Rotation();
    }

    public virtual void Picked()
    {
        Destroy(this.gameObject);
    }

    public void Rotation()
    {
        transform.Rotate(new Vector3(0f, 0f, rotationSpeed));
    }
}
