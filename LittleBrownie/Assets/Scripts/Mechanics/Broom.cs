using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Broom : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer _sprite;

    public float Height { get { return _sprite.size.x; } }
    public float SweepTime { get; set; }

    private void Start()
    {
        Destroy(gameObject, SweepTime);
    }
}
