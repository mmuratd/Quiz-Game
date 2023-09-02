using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [Header("Questions")]
    QuestionSO currentQuestion;
    [SerializeField] TextMeshProUGUI questionTMP;
    [SerializeField] List<QuestionSO> questionsList = new List<QuestionSO>();


    [Header("Answers")]
    [SerializeField] GameObject[] answerButtonArray;
    int correctAnswerIndex;
    bool hasAnsweredEarly= true;


    [Header("Timer")]
    [SerializeField] Image timerImage;
    Timer timer;


    [Header("Score")]
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scoreKeeper;


    [Header("Progress Bar")]
    [SerializeField] Slider progressBar;

    public bool isComplete;


    void Start()
    {
        
        timer = FindObjectOfType<Timer>();
        // scoreKeeper = new ScoreKeeper();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        progressBar.maxValue = questionsList.Count;
        progressBar.value = 0;
        
    }

    void Update()
    {
        timerImage.fillAmount = timer.fillFraction;
        if (timer.loadNextQuestion)
        {
            
        if (progressBar.value == progressBar.maxValue){

            isComplete = true;
            return;
        }
            hasAnsweredEarly = false;
            SetDefaultButtonColor();
            GetNextQuestion();
            timer.loadNextQuestion = false;
        }
        else if (!hasAnsweredEarly && !timer.isAnsweringQuestion)
        {
            DisplayAnswer(-1);
            SetButtonState(false);
        }
    }
   

    void onClickButton(int buttonIndex)
    {
        hasAnsweredEarly = true;
        DisplayAnswer(buttonIndex);

        SetButtonState(false);
        timer.CancelTimer();

        scoreText.text = "Score: " + scoreKeeper.CalculateScore() + "%";

    }

//.............................................................................................................................................................................................................
//......GGGGGGGGGG....................ttt.....................................................ttt....................................................................ttt...iiiii...............................
//....GGGGGGGGGGGGGG................ttttt...................................................ttttt..................................................................ttttt...iiiii...............................
//...GGGGGGGGGGGGGGG................ttttt...................................................ttttt..................................................................ttttt...iiiii...............................
//..GGGGGGGG.GGGGGGGG...............ttttt...................................................ttttt..................................................................ttttt.......................................
//..GGGGGG.....GGGGG....eeeeeeee...ettttttt........nnnnnnnnnnn.....eeeeeeee...xxxxxx.xxxxxxxttttttt.........qqqqqqqqqqqq.uuuuu...uuuuu....eeeeeeee....sssssssss..stttttttt.iiiii...ooooooooo....nnnnnnnnnnn....
//..GGGGG..............eeeeeeeeeee.ettttttt........nnnnnnnnnnnn...eeeeeeeeee..xxxxxx.xxxxxxxttttttt........qqqqqqqqqqqqq.uuuuu...uuuuu..eeeeeeeeeee..sssssssssss.stttttttt.iiiii..ooooooooooo...nnnnnnnnnnnn...
//.GGGGG...............eeeeeeeeeee.ettttttt........nnnnnnnnnnnn..eeeeeeeeeeee..xxxxxxxxxxx.xttttttt........qqqqqqqqqqqqq.uuuuu...uuuuu..eeeeeeeeeee..sssss.sssss.stttttttt.iiiii..oooooooooooo..nnnnnnnnnnnnn..
//.GGGGG..............eeeeee.eeeeee.ttttt..........nnnnnnnnnnnnn.eeeeeeeeeeee...xxxxxxxxx...ttttt.........qqqqqqqqqqqqqq.uuuuu...uuuuu.ueeeee.eeeeee.sssss..sssss..ttttt...iiiii.ooooooooooooo..nnnnnnnnnnnnn..
//.GGGGG....GGGGGGGGG.eeeee...eeeee.ttttt..........nnnnn...nnnnnneeee...eeeee...xxxxxxxxx...ttttt.........qqqqqq..qqqqqq.uuuuu...uuuuu.ueeee...eeeee.ssssssss......ttttt...iiiii.ooooo...oooooo.nnnnn...nnnnn..
//.GGGGG....GGGGGGGGG.eeeeeeeeeeeee.ttttt..........nnnnn...nnnnnneeeeeeeeeeee....xxxxxxx....ttttt.........qqqqq....qqqqq.uuuuu...uuuuu.ueeeeeeeeeeee.sssssssssss...ttttt...iiiii.ooooo....ooooo.nnnnn...nnnnn..
//.GGGGGG...GGGGGGGGG.eeeeeeeeeeeee.ttttt..........nnnnn...nnnnnneeeeeeeeeeee....xxxxxxx....ttttt.........qqqqq....qqqqq.uuuuu...uuuuu.ueeeeeeeeeeee.ssssssssssss..ttttt...iiiii.oooo.....ooooo.nnnnn...nnnnn..
//..GGGGG.......GGGGG.eeeee.........ttttt..........nnnnn...nnnnnneeee............xxxxxxx....ttttt.........qqqqq....qqqqq.uuuuu...uuuuu.ueeee...........ssssssssss..ttttt...iiiii.ooooo....ooooo.nnnnn...nnnnn..
//..GGGGGG......GGGGG.eeeee.........ttttt..........nnnnn...nnnnnneeeee..........xxxxxxxxx...ttttt.........qqqqq...qqqqqq.uuuuu...uuuuu.ueeee..............sssssss..ttttt...iiiii.ooooo...oooooo.nnnnn...nnnnn..
//..GGGGGGGG.GGGGGGGG.eeeeeeeeeeeee.ttttttt........nnnnn...nnnnn.eeeeeeeeeeee..xxxxxxxxxxx..ttttttt.......qqqqqqqqqqqqqq.uuuuuuuuuuuuu.ueeeeeeeeeeeeessss...sssss..ttttttt.iiiii.ooooooooooooo..nnnnn...nnnnn..
//...GGGGGGGGGGGGGGGG..eeeeeeeeeee..tttttttt.......nnnnn...nnnnn.eeeeeeeeeeee..xxxxxxxxxxx..tttttttt.......qqqqqqqqqqqqq.uuuuuuuuuuuuu..eeeeeeeeeee..ssssssssssss..ttttttt.iiiii.ooooooooooooo..nnnnn...nnnnn..
//....GGGGGGGGGGGGGG...eeeeeeeeeee..tttttttt.......nnnnn...nnnnn..eeeeeeeeee..xxxxxx.xxxxxx.tttttttt.......qqqqqqqqqqqqq..uuuuuuuuuuuu..eeeeeeeeeee..sssssssssss...ttttttt.iiiii..ooooooooooo...nnnnn...nnnnn..
//......GGGGGGGGGG......eeeeeeeee....ttttttt.......nnnnn...nnnnn...eeeeeeee..exxxxx...xxxxxx.ttttttt........qqqqqqqqqqqq...uuuuuuuuuuu....eeeeeeee....sssssssss.....ttttttiiiiii...ooooooooo....nnnnn...nnnnn..
//.................................................................................................................qqqqq.......................................................................................
//.................................................................................................................qqqqq.......................................................................................
//.................................................................................................................qqqqq.......................................................................................
//.................................................................................................................qqqqq.......................................................................................
//.................................................................................................................qqqqq.......................................................................................
//.............................................................................................................................................................................................................

    void GetNextQuestion()
    {
         if (questionsList.Count <= 0)
        {
            questionTMP.text = "Thanks for playing";
            
        } 
        else 
        {
        SetButtonState(true);
        SetDefaultButtonColor();
        GetRandomQuestion();
        DisplayQuestion();
        progressBar.value++;
        scoreKeeper.IncrementQuestionsSeen();
        }

    }
    
    void DisplayAnswer(int buttonIndex)
    {
        if (buttonIndex == currentQuestion.GetCorrectAnswerIndex())
        {
            answerButtonArray[buttonIndex].GetComponent<Image>().color = Color.green;
            questionTMP.text = "That is correct!";
            scoreKeeper.IncrementCorrectAnswers();
        }
        else
        {
            answerButtonArray[buttonIndex].GetComponent<Image>().color = Color.yellow;
            answerButtonArray[currentQuestion.GetCorrectAnswerIndex()].GetComponent<Image>().color =
                Color.green;
            questionTMP.text =
                "False, Correct answer is : "
                + currentQuestion.GetAnswer(currentQuestion.GetCorrectAnswerIndex());
        }
    }



    void GetRandomQuestion()
    {
        
            int index = Random.Range(0, questionsList.Count);
            currentQuestion = questionsList[index];

            //Seçilen soruyu listeden siliyoruz.
            if (questionsList.Contains(currentQuestion))
            {
                questionsList.Remove(currentQuestion);
            }
        
    }

    void DisplayQuestion()
    {
        questionTMP.text = currentQuestion.GetQuestion();

        for (int i = 0; i < answerButtonArray.Length; i++)
        {
            TMPro.TextMeshProUGUI buttonText = answerButtonArray[
                i
            ].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = currentQuestion.GetAnswer(i);
        }
    }

    void SetButtonState(bool state)
    {
        for (int i = 0; i < answerButtonArray.Length; i++)
        {
            Button button = answerButtonArray[i].GetComponent<Button>();
            button.interactable = state;
        }
    }
        void SetDefaultButtonColor()
    {
        for (int i = 0; i < answerButtonArray.Length; i++)
        {
            answerButtonArray[i].GetComponent<Image>().color = Color.white;
        }
    }
}
