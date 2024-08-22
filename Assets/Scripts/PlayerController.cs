using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private float speed = 20;
    public TextMeshProUGUI countText;
    public GameObject loseTextObject;
    private int count;
    private Rigidbody rb;
    private float movementX;
    // private float movementY;
    private bool alive;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        alive = true;

        SetCountText();
        loseTextObject.SetActive(false);
    }

    private void Update()
    {
        if (transform.position.y < -5)
        {
            Die();
        }
    }
    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
    }

    void SetLoseText()
    {
        loseTextObject.SetActive(true);
    }

    // 2. FixedUpdate: called before performing physics calculations
    void FixedUpdate()
    {
        if (!alive) return;

        Vector3 movement = new Vector3(movementX, 0.0f, 0.0f);
        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
    }

    public void Die()
    {
        alive = false;
        SetLoseText();
        // Restart the game after 2 seconds
        Invoke("Restart", 2);
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
