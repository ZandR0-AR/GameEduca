using UnityEngine;

public class GruntScript : MonoBehaviour
{
    public Transform John;
    public GameObject BulletPrefab;
    public GameObject explosionPrefab;

    public GameObject questionPanel;   // 👈 PANEL UI
    public QuestionManager questionManager;

    private bool hasAskedQuestion = false;

    void Update()
    {
        if (John == null) return;

        float distance = Mathf.Abs(John.position.x - transform.position.x);

        if (distance < 1.0f && !hasAskedQuestion)
        {
            AskQuestion();
        }
    }

    void AskQuestion()
    {
        hasAskedQuestion = true;
        Time.timeScale = 0f;

        questionPanel.SetActive(true);
        questionManager.grunt = this;
    }


    // ✅ RESPUESTA CORRECTA
    public void CorrectAnswer()
    {
        if (explosionPrefab != null)
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }

    // ❌ RESPUESTA INCORRECTA
    public void WrongAnswer()
    {
        Shoot();
    }

    void Shoot()
    {
        Vector3 direction = new Vector3(transform.localScale.x, 0, 0);
        Instantiate(BulletPrefab, transform.position + direction * 0.1f, Quaternion.identity);
    }
}

