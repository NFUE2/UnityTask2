using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class PlayerSight : MonoBehaviour
{
    [Header("Look")]
    private Vector2 mouseDirection;
    public float rotIntesity = 1.0f;
    private float minAngle = -85f, maxAngle = 85f, rotX;
    private Camera camera;

    public float maxDistance;
    public TextMeshProUGUI prompt;
    public LayerMask infoLayer;
    private float lastRayTime;
    public float rayRate = 0.5f;

    private void Awake()
    {
        camera = Camera.main;
    }

    private void Update()
    {
        DisplayPrompt();
    }

    private void LateUpdate()
    {
        Look();
    }
    public void OnLook(InputAction.CallbackContext context)
    {
        mouseDirection = context.ReadValue<Vector2>();
    }

    private void Look()
    {
        rotX += mouseDirection.y * rotIntesity;
        rotX = Mathf.Clamp(rotX, minAngle, maxAngle);
        camera.transform.localEulerAngles = new Vector3(-rotX, 0, 0);

        transform.localEulerAngles += new Vector3(0, mouseDirection.x, 0);
    }

    private void DisplayPrompt()
    {
        if (Time.time - lastRayTime > rayRate)
        {
            lastRayTime = Time.time;
            Ray ray = camera.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));

            RaycastHit hit;

            if(Physics.Raycast(ray,out hit,maxDistance,infoLayer) && hit.collider.TryGetComponent(out IPrompt target))
            {
                prompt.gameObject.SetActive(true);
                prompt.text = target.promptName;
            }
            else
                prompt.gameObject.SetActive(false);
        }
    }
}
