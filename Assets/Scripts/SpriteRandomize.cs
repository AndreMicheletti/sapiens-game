using System.Collections.Generic;
using UnityEngine;

public class SpriteRandomize : MonoBehaviour
{
    public List<Sprite> sprites;
    void Awake() {
        SpriteRenderer renderer = this.GetComponent<SpriteRenderer>();
        if (renderer && sprites.Count > 0) {
            int randIdx = Random.Range(0, sprites.Count);
            renderer.sprite = sprites[randIdx];
        }
    }
}
