using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

/**
 * \brief 콘솔창 GameObject에 붙어 Log를 출력해 주는 역할을 하는 컴포넌트 스크립트
 */

public class Logger : MonoBehaviour {

    public Text logger;
    private int maxLine = 3;

	// Use this for initialization
	void Start () {
        logger = GameObject.Find("Logger").GetComponent<Text>();
    }
	
	// Update is called once per frame
	public void AddLog (string _log) {
        //string log = logger.text;
        string tmptext;
        tmptext = logger.text;
        tmptext = tmptext.Substring(tmptext.IndexOf("\n")+1);
        tmptext += "\n";
        tmptext += _log;
        logger.text = tmptext;
    }
    void Update() { }
}
