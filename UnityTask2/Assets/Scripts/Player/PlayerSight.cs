using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

enum SightType
{
    first,
    third,
}

public class PlayerSight : MonoBehaviour,IChangeStat
{
    Player player;

    [Header("Look")]
    private SightType sightType = SightType.first;
    private Vector2 mouseDirection;
    public float rotIntesity;
    private float minAngle = -85f, maxAngle = 85f, rotX;
    public Transform camera;

    [Header("Display")]
    public float maxDistance;
    public TextMeshProUGUI prompt;
    public LayerMask infoLayer;
    private float lastRayTime;
    public float rayRate = 0.5f;


    Item selectItem;

    private void Awake()
    {
        player = GetComponent<Player>();
        player.OnChangeStatEvent += ChangeStat;
    }

    private void Start()
    {
        rotIntesity = player.data.rotIntesity;
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
            Ray ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));

            RaycastHit hit;

            if(Physics.Raycast(ray,out hit,maxDistance,infoLayer) && hit.collider.TryGetComponent(out IPrompt target))
            {
                prompt.gameObject.SetActive(true);
                prompt.text = $"{target.promptName}";

                hit.collider.TryGetComponent(out selectItem);
            }
            else
            {
                prompt.gameObject.SetActive(false);
                selectItem = null;
            }
        }
    }

    public void OnInteraction(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started && selectItem != null && selectItem.TryGetComponent(out IUseItem item)) 
        {
            if (item != null) item.UseItem();

        }
    }

    public void OnChangeSightType()
    {
        bool sightCheck = sightType == SightType.first;

        Camera.main.transform.localPosition += sightCheck ? new Vector3(0, 1, -5) : -new Vector3(0, 1, -5);
        sightType = sightCheck ? SightType.third : SightType.first;
    }

    public void ChangeStat()
    {
        rotIntesity = player.data.rotIntesity;
    }
}
