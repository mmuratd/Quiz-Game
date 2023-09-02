using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NewQuestion", menuName = "QuizMMD/NewQuestion", order = 0)]
public class QuestionSO : ScriptableObject {
    
    [SerializeField] string question;
    [SerializeField] string[] answerArray = new string[4];
    [SerializeField] int correctAnswerIndex;

    public string GetQuestion() {
        return question;
    }
    public string GetAnswer(int index) {
        return answerArray[index];
    }
    public int GetCorrectAnswerIndex() {
        return correctAnswerIndex;
    }
}

