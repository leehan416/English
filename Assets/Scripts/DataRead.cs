using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
//5과 32
//6과 44
//7과 46
//8과 34
public class DataRead : MonoBehaviour {

    public static DataRead instance;
    public string storyPath = "Assets/Data/Text"; //폴더명 / 파일명 

    public int storyPhase; //파일  선택(Text1, Text2, Text3)
    //public int storyIndex; //줄 위치
    public int Check;
    public int random;
    public bool [] i;
    public int Max;

    public string tmp;


    public ArrayList story = new ArrayList();

    public Text Display; // 출력 Text 
    public Text Button_1; //버튼1 에 띄울 Text 
    public Text Button_2; // 버튼 2에 띄울 Text 
    public GameObject an;
    public Text answer;


    // 값 초기화
    void Start() {
        if (Application.loadedLevelName == "Test5") {
            i = new bool[32];
            Max = 32;
        }
        else if (Application.loadedLevelName == "Test6") {
            i = new bool[42];
            Max = 42;
        }
        else if (Application.loadedLevelName == "Test7") {
            i = new bool[46];
            Max = 46;
        }
        else if (Application.loadedLevelName == "Test8") {
            i = new bool[34];
            Max = 34;
        }
        for (int a = 0; a < i.Length; a++) {
            i[a] = true;
        }
        if (!instance)
            instance = this;
        else
            DestroyImmediate(this);
        if (PlayerPrefs.HasKey("storyPhase")) { //값 초기화
            storyPhase = PlayerPrefs.GetInt("storyPhase");
        } else {
            storyPhase = 0;
            //storyIndex = 0;
            //SetStory();
            SetText();
        }

    }
    public int SceneCheck() {
        if (Application.loadedLevelName == "Test5") {
            return 0;
        }
        else if (Application.loadedLevelName == "Test6") {
            return 1;
        }
        else if (Application.loadedLevelName == "Test7") {
            return 2;
        }
        else if (Application.loadedLevelName == "Test8") {
            return 3;
        } else {
            return 10; // 에러
        }
    }
    //----------------------------------------------------------------------------------------------------
    public void SetText() { // 명령어 설정창
        if (Application.loadedLevelName == "Test5") {
            tmp = Lesson.instance.Data5[Ran()];
        }
        else if (Application.loadedLevelName == "Test6") {
            tmp = Lesson.instance.Data6[Ran()];
        }
        else if (Application.loadedLevelName == "Test7") {
            tmp = Lesson.instance.Data7[Ran()];
        }
        else if (Application.loadedLevelName == "Test8") {
            tmp = Lesson.instance.Data8[Ran()];
        }//읽어오기  영단어 : 버튼1 : 버튼2 : 정답버튼숫자로 표현

        if (tmp.Contains(":")) {//뜻 있으면 
            string[] tmps = tmp.Split(':');
            Display.text = tmps[0].Trim();
            Button_1.text = tmps[1].Trim();
            Button_2.text = tmps[2].Trim();
            Check = Convert.ToInt32(tmps[3].Trim());
            answer.text = tmps[Check];
        } else {
            Display.text = "Error!";
        }
    }
    //-------------------------------------------------------------------------------------------------------------------------
    public int Ran() {
        while(true) {
            random = UnityEngine.Random.Range(0, Max);
            if (i[random]) {
                break;
            }
        }
        i[random] = false;
        return random;
    }
}