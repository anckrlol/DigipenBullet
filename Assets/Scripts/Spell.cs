using UnityEngine;

/// <summary>
/// Acts as a base to create any spell.
/// </summary>
public class Spell : MonoBehaviour
{
    [SerializeField] private string name;
    /// <summary>
    /// Positive is damage, negative is heal
    /// </summary>
    [SerializeField] private float damage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ApplyDamage(){
        
    }
}
