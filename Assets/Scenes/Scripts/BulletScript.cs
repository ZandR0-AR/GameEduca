using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float Speed;
    public AudioClip Sound;

    private Rigidbody2D rb;
    private Vector3 direction;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (Camera.main != null)
        {
            AudioSource audio = Camera.main.GetComponent<AudioSource>();
            if (audio != null && Sound != null)
            {
                audio.PlayOneShot(Sound);
            }
        }
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = direction * Speed;
    }

    public void SetDirection(Vector3 dir)
    {
        direction = dir;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // ✅ SOLO DAÑA AL JUGADOR
        JohnMovement john = other.GetComponent<JohnMovement>();
        if (john != null)
        {
            john.Hit();
            Destroy(gameObject);
        }

        // ✅ Si choca con cualquier otra cosa (suelo, pared, etc.)
        if (!other.isTrigger)
        {
            Destroy(gameObject);
        }
    }
}
