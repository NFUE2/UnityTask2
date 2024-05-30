using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DoorTrap : MonoBehaviour
{
    Ray ray;

    public string msg;
    public LayerMask targetLayer;
    public float rayRate;
    public float lastRayTime;
    public TextMeshProUGUI prompt;

    bool hit = false;

    private void Start()
    {
        ray = new Ray(transform.position + Vector3.up,Vector3.right);
    }

    private void Update()
    {
        PlayerCheck();
    }

    void PlayerCheck()
    {
        bool raycast = Physics.Raycast(ray, 2.0f, targetLayer);

        if (Time.time - lastRayTime > rayRate && raycast)
        {
            lastRayTime = Time.time;
            prompt.gameObject.SetActive(true);
            prompt.text = msg;
            hit = true;
        }
        else if (hit && !raycast)
            StartCoroutine(ClosePrompt());
    }

    IEnumerator ClosePrompt()
    {
        yield return new WaitForSeconds(2.0f);
        prompt.gameObject.SetActive(false);
    }
}
