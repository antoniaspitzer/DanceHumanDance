using UnityEngine;
using UnityEngine.UI;

public class ImageAnimation : MonoBehaviour {

	public Sprite[] sprites;
	public float speed = 1f; // 1 = normal, <1 = langsamer, >1 = schneller
	public bool loop = true;
	public bool destroyOnEnd = false;

	private int index = 0;
	private Image image;
	private float timer = 0f;
	private float frameDuration;

	void Awake() {
		image = GetComponent<Image>();
		frameDuration = 1f / (speed * 60f); // 60 "logical frames" per second, scaled by speed
	}

	void Update() {
		if (!loop && index == sprites.Length) return;

		timer += Time.deltaTime;
		if (timer < frameDuration) return;

		timer = 0f;
		image.sprite = sprites[index];
		index++;

		if (index >= sprites.Length) {
			if (loop) index = 0;
			if (destroyOnEnd) Destroy(gameObject);
		}
	}
}
