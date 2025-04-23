using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuizManager : MonoBehaviour
{
    public GameObject quizPanel;
    public GameObject correctAnswer, wrongAnswer;
    public TMP_Text TextQuestion;

    public Button[] optionButtons;

    public bool isPanelStatusClose = true;

    public AudioSource audioSource;
    public AudioClip correctSound;  
    public AudioClip wrongSound;  

    [System.Serializable]
    public class QuizData
    {
        public string questionTextOnly;
        public string[] options;
        public int correctIndex;
    }

    public List<QuizData> quizList = new List<QuizData>();

    private QuizData currentQuiz;

    void Start()
    {
        quizPanel.SetActive(false);
        correctAnswer.SetActive(false);
        wrongAnswer.SetActive(false);

        quizList.Add(new QuizData
        {
            questionTextOnly = "Contoh rantai makanan di hutan hujan tropis yang benar adalah:",
            options = new string[] {"Jamur → Harimau → Belalang", "Daun → Ulat → Burung → Elang", 
                "Rumput → Tikus → Kucing → Serigala", "Pohon → Elang → Monyet"},
            correctIndex = 1,
        });

        quizList.Add(new QuizData
        {
            questionTextOnly = "Adaptasi utama burung hantu untuk bertahan hidup di hutan adalah:",
            options = new string[] {
                "Kulit tebal untuk menyimpan air", "Mata besar untuk melihat di malam hari",
                "Kaki berselaput untuk berenang", "Gigi tajam untuk memotong dahan",
            },
            correctIndex = 1,
        });

        quizList.Add(new QuizData
        {
            questionTextOnly = "Mengapa kaktus mampu bertahan hidup di gurun ?",
            options = new string[] {
                "Karena daunnya lebar dan banyak pori", "Karena memerlukan air dalam jumlah besar", 
                "Karena tumbuh di tanah subur", "Karena batangnya dapat menyimpan air"
            },
            correctIndex = 3,
        });

        quizList.Add(new QuizData
        {
            questionTextOnly = "Rantai makanan sederhana di gurun yang benar adalah:",
            options = new string[] {
                "Kaktus → Kelinci → Ular → Elang", "Rumput → Kucing → Tikus", 
                "Kaktus → Serigala → Ular", "Air → Ikan → Ular"
            },
            correctIndex = 0,
        });

        quizList.Add(new QuizData
        {
            questionTextOnly = "Kebanyakan hewan gurun bersifat nokturnal karena:",
            options = new string[] {
                "Makanan hanya tersedia malam hari", "Musuh mereka hanya muncul di siang hari", 
                "Untuk menghindari panas ekstrem di siang hari", "Cahaya bulan membantu mereka berburu"
            },
            correctIndex = 2,
        });

        quizList.Add(new QuizData
        {
            questionTextOnly = "Rantai makanan yang umum di rawa adalah:",
            options = new string[] {
                "Akar bakau → Kura-kura → Katak", "Daun → Siput → Ular", 
                "Lumpur → Kepiting → Elang", "Tanaman air → Ikan kecil → Burung bangau"
            },
            correctIndex = 3,
        });

        quizList.Add(new QuizData
        {
            questionTextOnly = "Perbedaan utama herbivora di gurun dan hutan adalah:",
            options = new string[] {
                "Hewan hutan lebih besar dari gurun", "Hewan gurun lebih aktif di malam hari untuk menghemat air", 
                "Hewan gurun biasanya hidup berkelompok", "Hewan hutan tidak memiliki predator alami"
            },
            correctIndex = 1,
        });

        quizList.Add(new QuizData
        {
            questionTextOnly = "Hewan yang berperan sebagai konsumen sekunder dalam ekosistem hutan adalah",
            options = new string[] {
                "Daun", "Ulat", 
                "Burung pemakan serangga", "Elang"
            },
            correctIndex = 2,
        });

        quizList.Add(new QuizData
        {
            questionTextOnly = "Contoh hewan herbivora di gurun adalah",
            options = new string[] {
                "Ular derik", "Elang", 
                "Kelinci gurun", "Rubah fennec"
            },
            correctIndex = 2,
        });

        quizList.Add(new QuizData
        {
            questionTextOnly = "Contoh tumbuhan yang sering ditemukan di rawa air tawar adalah",
            options = new string[] {
                "Kaktus", "Teratai", 
                "Pinus", "Paku tanduk rusa"
            },
            correctIndex = 1,
        });
    }

    public void ShowRandomQuiz()
    {
        quizPanel.SetActive(false);
        if (quizList.Count == 0) return;
        
        int randomIndex = Random.Range(0, quizList.Count);
        currentQuiz = quizList[randomIndex];

        string displayText = currentQuiz.questionTextOnly + "\n";
        displayText += "A. " + currentQuiz.options[0] + "\n";
        displayText += "B. " + currentQuiz.options[1] + "\n";
        displayText += "C. " + currentQuiz.options[2] + "\n";
        displayText += "D. " + currentQuiz.options[3];

        TextQuestion.text = displayText;

        for (int i = 0; i < optionButtons.Length; i++)
        {
            int idx = i;
            optionButtons[i].onClick.RemoveAllListeners();
            optionButtons[i].onClick.AddListener(() => CheckAnswer(idx));
        }

        quizPanel.SetActive(true);
    }

    void CheckAnswer(int index)
    {
        quizPanel.SetActive(false);
        isPanelStatusClose = false;
        
        if (index == currentQuiz.correctIndex)
        {
            correctAnswer.SetActive(true);
            if (audioSource && correctSound) {
                audioSource.PlayOneShot(correctSound);
            }
            
        }
        else
        {
            wrongAnswer.SetActive(true);
            if (audioSource && wrongSound) {
                audioSource.PlayOneShot(wrongSound);
            }
        }    
    }

    public void HideQuiz()
    {
        quizPanel.SetActive(false);
    }

    
    public void onClosePanel()
    {
        isPanelStatusClose = true;
    }
}
