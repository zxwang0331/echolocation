using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mask_move : MonoBehaviour
{
    public Transform player;
    public SpriteMask mask;
    public KeyCode toggleKey = KeyCode.Space;
    private bool isActive = false;
    public float duration = 5f; // duration time
    public Vector3 targetScale = new Vector3(5, 5, 5);
    public CircleCollider2D maskCollider;
    public float targetRadius = 5f;

    void Start()
    {
        mask.enabled = false;
        maskCollider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(toggleKey) && !isActive)
        {
            StartCoroutine(ActivateMask());
        }
        if (!isActive)
        {
            transform.position = player.position;
            transform.rotation = player.rotation;
        }
    }
    IEnumerator ActivateMask()
    {
        isActive = true; // Mark the mask as active
        mask.enabled = true; // Enable the Sprite Mask
        maskCollider.enabled = true;
        Vector3 originalScale = mask.transform.localScale;
        float currentTime = 0;
        float originalRadius = maskCollider.radius;

        while (currentTime < duration)
        {
            mask.transform.localScale = Vector3.Lerp(originalScale, targetScale, currentTime / duration);
            maskCollider.radius = Mathf.Lerp(originalRadius, targetRadius, currentTime / duration);
            currentTime += Time.deltaTime;
            yield return null;
        }
        yield return new WaitForSeconds(5); // Wait for 5 seconds
        mask.enabled = false; // Disable the Sprite Mask after waiting
        maskCollider.enabled = false;
        isActive = false; // Mark the mask as inactive
        mask.transform.localScale = originalScale;
        maskCollider.radius = originalRadius;
    }
}
