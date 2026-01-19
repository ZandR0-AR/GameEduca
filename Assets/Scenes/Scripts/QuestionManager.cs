using UnityEngine;

public class QuestionManager : MonoBehaviour
{
    public GruntScript grunt;
    public JohnMovement player;

    
    public void AnswerWrong()
    {
        Time.timeScale = 1f;
        gameObject.SetActive(false);

        grunt.WrongAnswer();
        player.Die();
    }

    public void AnswerCorrect()
    {
        if (grunt == null)
        {
            Debug.LogError("ERROR: El panel no recibió el villano (grunt)");
            return;
        }

        Time.timeScale = 1f;
        gameObject.SetActive(false);
        grunt.CorrectAnswer();
    }


}
