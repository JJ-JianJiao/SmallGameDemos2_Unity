using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using System.IO;
using System.Xml;
using System.Xml.Serialization;
public class Spawner : MonoBehaviour
{
    public SaveContainer myContainer;

    public Material[] myColors;
    public GameObject[] myShapes;

    // Use this for initialization
    void Start()
    {
        LoadData();

        gameObject.GetComponent<MeshFilter>().sharedMesh = myShapes[myContainer.players[myContainer.currentIndex].GetShape()].GetComponent<MeshFilter>().sharedMesh;
        gameObject.GetComponent<Renderer>().material = myColors[myContainer.players[myContainer.currentIndex].GetColor()];
    }

    public void LoadData()
    {
        // If the XML file exists then load the data.
        if (File.Exists("SaveFiles/Profiles.xml"))
        {
            Stream stream = File.Open("SaveFiles/Profiles.xml", FileMode.Open);
            XmlSerializer serializer = new XmlSerializer(typeof(SaveContainer));
            myContainer = serializer.Deserialize(stream) as SaveContainer;
            stream.Close();
        }
    }

    public void SaveScore(int changeScore)
    {
        if (changeScore > myContainer.players[myContainer.currentIndex].GetScore())
        {
            myContainer.players[myContainer.currentIndex].SetScore(changeScore);
        }

        CheckTopScores(changeScore, myContainer.players[myContainer.currentIndex].GetName());

        //Stream stream = File.Open("Profiles.xml", FileMode.Create);
        Stream stream = File.Open("SaveFiles/Profiles.xml", FileMode.Create); //modify by JJ -- the file path is different
        XmlSerializer serializer = new XmlSerializer(typeof(SaveContainer));
        serializer.Serialize(stream, myContainer);
        stream.Close();

        SceneManager.LoadScene(0);
    }

    void CheckTopScores(int checkScore, string checkName)
    {
        int tempScore;
        string tempName;

        for (int i = 0; i < myContainer.leaders.Length; i++)
        {
            //if (myContainer.leaders[i].GetScore() > checkScore)
            if (myContainer.leaders[i].GetScore() < checkScore) // the > should be < -- modify by JJ
            {
                tempScore = myContainer.leaders[i].GetScore();
                tempName = myContainer.leaders[i].GetName();

                myContainer.leaders[i].SetScore(checkScore);
                myContainer.leaders[i].SetName(checkName);

                checkScore = tempScore;
                checkName = tempName;
            }
        }
    }
}
