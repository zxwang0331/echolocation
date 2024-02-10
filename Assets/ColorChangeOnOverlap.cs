using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangeOnOverlap : MonoBehaviour
{
    public SpriteRenderer squareSprite;
    public Color intersectColor = Color.red;
    private Color originalColor;
    // Start is called before the first frame update
    void Start()
    {
        originalColor = squareSprite.color;
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("PlayerMask"))
        {
            squareSprite.color = intersectColor;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("PlayerMask"))
        {
            squareSprite.color = originalColor;
        }
    }

}
