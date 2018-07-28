using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

/**
 * \brief 콘솔창 GameObject에 붙어 Log를 출력해 주는 역할을 하는 컴포넌트 스크립트
 */

public class Logger : MonoBehaviour {

    public List<string> LogList;
    public Text logger;

	// Use this for initialization
	void Start () {
        LogList = new List<string>();
	}
	
	// Update is called once per frame
	void AddLog (string _log) {
        string log = logger.text;
        log += string.Format("/n{0}", _log);
	}

    void Update() { }
}
