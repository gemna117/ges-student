﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Checkpoint : MonoBehaviour {

    [SerializeField]
    private float inactivatedrotationSpeed = 100, activatedRotationSpeed = 300;

    [SerializeField]
    private float inactivatedScale = 1, activatedScale = 1.5f;

    [SerializeField]
    private Color inactivatedColor, activatedColor;

    private bool isActivated;
    private SpriteRenderer spriteRenderer;
    private AudioSource audioSource;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
        UpdateColor();
    }

    private void Update()
    {
        UpdateRotation();
    }

    private void UpdateColor()
    {
        Color color = inactivatedColor;
        if (isActivated)
            color = activatedColor;

        spriteRenderer.color = color;
    }

    private void UpdateScale()
    {
        float scale = inactivatedScale;

        if (isActivated)
            scale = activatedScale;

        transform.localScale = Vector3.one * scale;
    }

    private void UpdateRotation()
    {
        float rotationSpeed = inactivatedrotationSpeed;
        if (isActivated)
            rotationSpeed = activatedRotationSpeed;
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }

    public void SetIsActivated(bool value)
    {
        isActivated = value;
        UpdateScale();
        UpdateColor();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player") && isActivated)
        {
            Debug.Log("player entered hazard");
            PlayerCharacter player = collision.GetComponent<PlayerCharacter>();
            player.SetCurrentCheckpoint(this);
            audioSource.Play();
        }
    }
}
