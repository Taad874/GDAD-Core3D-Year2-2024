using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class ExplodingCrate : MonoBehaviour, IDamagable
{
    public int health = 10;
    public GameObject explosionEffectPrefab;
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
            Explode(); // Call explosion effect when health reaches 0
            Destroy(gameObject); // Destroy the object
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
    private void Explode()
    {
        // Instantiate explosion effect
        if (explosionEffectPrefab != null)
        {
            Instantiate(explosionEffectPrefab, transform.position, Quaternion.identity);
        }
    }
}

