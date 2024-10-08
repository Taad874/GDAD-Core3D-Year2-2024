using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamagable
{
    public int health = 10;
    private Material mat;
    private Color originalColor;
    private void Start()
    {
        mat = GetComponent<Renderer>().material;
        originalColor = mat.color;
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        ShowHitEffect();
        if (health <= 0)
        {
            Die(); // Call Die method when health reaches zero
        }
    }
    public void ShowHitEffect()
    {
        mat.color = Color.red; // Flash red to show a hit effect
        Invoke("ResetMaterial", 0.1f);
    }
    private void ResetMaterial()
    {
        mat.color = originalColor;
    }
    private void Die()
    {
        // Optional: add logic like playing an animation or dropping loot
        Destroy(gameObject); // Destroy enemy object
    }
}
