using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_movement : MonoBehaviour
{
    public float speed = 6.0f;  // �������� ������������
    public float mouseSensitivity = 2.0f;  // ���������������� ����

    private CharacterController controller;
    private Vector3 velocity;

    private Transform cameraTransform;
    private float xRotation = 0f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        cameraTransform = Camera.main.transform;  // �������� ������ �� ������
        Cursor.lockState = CursorLockMode.Locked;  // ����������� ������
    }

    void Update()
    {

        // �������� ���������
        float moveX = Input.GetAxis("Horizontal");  // ������������ �� ��� X (A/D)
        float moveZ = Input.GetAxis("Vertical");  // ������������ �� ��� Z (W/S)

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        controller.Move(move * speed * Time.deltaTime);

        // �������� � ������� ����
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // ������� ������ ��� Y ��� �������� ���������
        transform.Rotate(Vector3.up * mouseX);

        // ������� ������ �� ��� X (������������ ������� ������)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);  // ������������ �������� �� ���������
        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }

    void LateUpdate()
    {
        // ����������� ������ � ������� ���������
        cameraTransform.position = transform.position + new Vector3(0, 1.6f, 0);
    }
}
