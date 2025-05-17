using UnityEngine;
using UnityEngine.Serialization;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private float sensitivity;
    [SerializeField] private Transform cameraHolder;

    private float _xRotation, _yRotation;
    private float _xMouse, _yMouse;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        //Cursor.visible = false;
    }
    
    private void Update()
    {
        if (DialogueSpeaker.DialogueActive) return;
        
        if (Input.GetMouseButton(1))
        {
            (_xMouse, _yMouse) = GetMouseInputs();
            
            _xRotation -= _yMouse;
            _yRotation += _xMouse;
            _xRotation = Mathf.Clamp(_xRotation, -45f, 90f);
            
            cameraHolder.localRotation = Quaternion.Euler(_xRotation, _yRotation, 0f);
        }
    }

    private (float mouseX, float mouseY) GetMouseInputs()
    {
        var mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        var mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        
        return (mouseX, mouseY);
    }
}
