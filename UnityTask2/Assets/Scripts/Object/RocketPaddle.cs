using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RocketPaddle : MonoBehaviour
{
    Rigidbody player, paddle;
    public TextMeshProUGUI countDownText;

    string[] countDownMessage = { "3", "2" ,"1", "น฿ป็!" };

    bool interaction;

    public float power;

    private void Start()
    {
        paddle = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out player) && !interaction)
        {
            interaction = true;
            StartCoroutine(Launch());
        }
    }

    IEnumerator Launch()
    {
        countDownText.gameObject.SetActive(true);
        for(int i = 0; i < countDownMessage.Length; i++)
        {
            countDownText.text = countDownMessage[i];
            yield return new WaitForSeconds(1.0f);
        }

        paddle.constraints = (RigidbodyConstraints)116;
        paddle.AddForce(transform.forward * power ,ForceMode.VelocityChange);

        yield return new WaitForSeconds(0.5f);

        countDownText.gameObject.SetActive(false);
    }
}
