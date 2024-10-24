using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_movement : MonoBehaviour
{
    public float speed = 6.0f;  // Скорость передвижения
    public float mouseSensitivity = 2.0f;  // Чувствительность мыши

    private CharacterController controller;
    private Vector3 velocity;

    private Transform cameraTransform;
    private float xRotation = 0f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        cameraTransform = Camera.main.transform;  // Получаем ссылку на камеру
        Cursor.lockState = CursorLockMode.Locked;  // Захватываем курсор
    }

    void Update()
    {

        // Движение персонажа
        float moveX = Input.GetAxis("Horizontal");  // Передвижение по оси X (A/D)
        float moveZ = Input.GetAxis("Vertical");  // Передвижение по оси Z (W/S)

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        controller.Move(move * speed * Time.deltaTime);

        // Вращение с помощью мыши
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Поворот вокруг оси Y для вращения персонажа
        transform.Rotate(Vector3.up * mouseX);

        // Поворот камеры по оси X (ограничиваем поворот камеры)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);  // Ограничиваем вращение по вертикали
        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }

    void LateUpdate()
    {
        // Привязываем камеру к позиции персонажа
        cameraTransform.position = transform.position + new Vector3(0, 1.6f, 0);
    }
}
