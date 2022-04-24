using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.IO;
using System.Xml.Serialization;



namespace ClickMe {

    public class BestPlayer {

        public string name;
        public int bestScore;

        public BestPlayer() {
            bestScore = 0;
            name = "NONE";
        }

    }



    public class GameplayController : MonoBehaviour
    {

        const string BEST_PLAYER_DATA_FILE_NAME = @"BestPlayer.xml";
        const string BEST_PLAYER_DATA_PATH = "SaveFile";
        [SerializeField] TMP_InputField nameInput;
        [SerializeField] Button startBtn;
        [SerializeField] Button ClickBtn;
        [SerializeField] TMP_Text clickBtnText;
        [SerializeField] TMP_Text currentScore;
        [SerializeField] TMP_Text bestPlayerNameText;
        [SerializeField] TMP_Text bestPlayerScoreText;



        private float prepareGametime = 3;
        private float timeStamp = 0;
        private bool allowClick = false;
        private int clickCounter = 0;

        private BestPlayer bestPlayer;

        // Start is called before the first frame update
        void Start()
        {
            bestPlayer = new BestPlayer();
            LoadData();
            ResetBestPlayer(bestPlayer);
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape)) {
                Application.Quit();
            }
        }

        IEnumerator CountThreeSecond() {
            clickCounter = 0;
            currentScore.text = (clickCounter).ToString();
            DisableStartBtn();
            Debug.Log("3");
            clickBtnText.text = "3";
            yield return new WaitForSeconds(1);
            Debug.Log("2");
            clickBtnText.text = "2";
            yield return new WaitForSeconds(1);
            Debug.Log("1");
            clickBtnText.text = "1";
            yield return new WaitForSeconds(1);
            Debug.Log("Start");
            clickBtnText.text = "CLICK";
            allowClick = true;
            yield return new WaitForSeconds(10);
            Debug.Log("finish");
            allowClick = false;
            clickBtnText.text = "Time Out";



            yield return new WaitForSeconds(2);
            clickBtnText.text = "Hello";
            EnableStartBtn();
            EnableInputText();

            if (bestPlayer.bestScore < clickCounter)
            {
                bestPlayer.bestScore = clickCounter;
                bestPlayer.name = nameInput.text;
                SaveData(bestPlayer);
                ResetBestPlayer(bestPlayer);
            }
        }

        public void NameInputDeselect() {

            Debug.Log("Deselect the name input text");

        }

        public void EndEditNameInput() {
            Debug.Log("End Edit name input");
        }

        public void ChangeValueNameInput(string value) {
            Debug.Log("I change the value ---- " + value);

            if (value != "")
            {
                Debug.Log("I will enable start btn");
                startBtn.interactable = true;
            }
            else {
                Debug.Log("I will disable the start btn");
                startBtn.interactable = false;
            }
        }

        public void StartBtnOnClick() {

            //TODO: disable the name input text
            DisableInputText();

            //TODO: Start Game
            StartCoroutine("CountThreeSecond");
        }

        private void DisableInputText() {
            nameInput.interactable = false;
        }

        private void EnableInputText()
        {
            nameInput.interactable = true;
        }

        private void DisableStartBtn()
        {
            startBtn.interactable = false;
        }

        private void EnableStartBtn()
        {
            startBtn.interactable = true;
        }

        public void ClickBtn_OnClick() {
            if (allowClick)
            {
                currentScore.text = (++clickCounter).ToString();
                currentScore.color = new Color(1, 1 - (clickCounter / 100f), 1 - (clickCounter / 100f));
            }
        }

        public void LoadData() {

            if (!Directory.Exists(BEST_PLAYER_DATA_PATH)) {
                Directory.CreateDirectory(BEST_PLAYER_DATA_PATH);
            }
            Stream stream = File.Open(Path.Combine(BEST_PLAYER_DATA_PATH, BEST_PLAYER_DATA_FILE_NAME), FileMode.OpenOrCreate);
            if (stream.Length == 0)
            {
                XmlSerializer serializerInput = new XmlSerializer(typeof(BestPlayer));
                serializerInput.Serialize(stream, bestPlayer);
            }
            else
            {
                XmlSerializer serializer = new XmlSerializer(typeof(BestPlayer));
                bestPlayer = (BestPlayer)serializer.Deserialize(stream);
                ResetBestPlayer(bestPlayer);
            }
            stream.Close();
        }

        public void SaveData(BestPlayer bp) {
            if (!Directory.Exists(BEST_PLAYER_DATA_PATH))
            {
                Directory.CreateDirectory(BEST_PLAYER_DATA_PATH);
            }
            Stream stream = File.Open(Path.Combine(BEST_PLAYER_DATA_PATH, BEST_PLAYER_DATA_FILE_NAME), FileMode.Create);
            XmlSerializer serializer = new XmlSerializer(typeof(BestPlayer));
            serializer.Serialize(stream, bp);
            stream.Close();
        }

        private void ResetBestPlayer(BestPlayer bp)
        {
            if (bp.name == "")
            {
                bestPlayerNameText.text = "";
                bestPlayerScoreText.text = "";
            }
            else
            {
                bestPlayerNameText.text = bp.name;
                bestPlayerScoreText.text = bp.bestScore.ToString();
            }
        }

    }
}