using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Transform camTransform;
    [SerializeField] Transform playerTransform;
    Vector3 offset;
    float movY;
   

    private void Awake() {
        camTransform = GetComponent<Transform>();
        offset = camTransform.position - playerTransform.position;
    }

    void Update()
    {
        camTransform.position = playerTransform.position + offset;
        Rotate();
    }

    private void Rotate(){
        movY -= Input.GetAxis("Mouse Y");
        movY = Mathf.Clamp(movY, -30, 30);
        camTransform.rotation = Quaternion.Euler(movY, playerTransform.eulerAngles.y, playerTransform.rotation.z);
    }

    
}
