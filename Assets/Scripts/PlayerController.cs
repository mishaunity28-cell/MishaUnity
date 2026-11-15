using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed;
    public int powerupStrenght;
    public float powerupTime;
    public GameObject powerupIndicator;

    private PlayerInputAction playerInputAction;
    private bool hasPowerup;

    private Rigidbody rigidbody;

    public GameObject focalPoint;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        playerInputAction = new PlayerInputAction();
        playerInputAction.Player.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput = playerInputAction.Player.Move.ReadValue<Vector2>();
        float verticalInput = moveInput.y;

        rigidbody.AddForce(focalPoint.transform.forward * verticalInput * playerSpeed * Time.deltaTime);

        powerupIndicator.transform.position = transform.position + new Vector3(0,-0.5f,0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Powerup powerup))
        {
            hasPowerup = true;
            Destroy(powerup.gameObject);
            powerupIndicator.SetActive(true);
            StartCoroutine(PowerupCountdown());
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent(out Enemy enemy) && hasPowerup == true)
        {
            Rigidbody enemyRigidbody = enemy.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = enemy.transform.position - transform.position;
            enemyRigidbody.AddForce(awayFromPlayer * powerupStrenght, ForceMode.Impulse);
        }
    }

    private IEnumerator PowerupCountdown()
    {
        yield return new WaitForSeconds(powerupTime);
        hasPowerup = false;
        powerupIndicator.SetActive(false);
    }


}
