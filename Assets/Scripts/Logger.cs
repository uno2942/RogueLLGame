using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

/**
 * \brief 콘솔창 GameObject에 붙어 Log를 출력해 주는 역할을 하는 컴포넌트 스크립트
 */

public class Logger : MonoBehaviour {

    public Text logger;

	// Use this for initialization
	void Start () {
        logger = GameObject.Find("Logger").GetComponent<Text>();
    }
	
	// Update is called once per frame
	public void AddLog (string _log) {
        //string log = logger.text;
        string tmptext = "";
        string[] temp= logger.text.Split( '\n' );
        if( temp[ 0 ] == "" && temp.Length == 2 )
            tmptext += temp[ 1 ];
        else if( temp.Length == 2 ) {
            tmptext += temp[ 0 ];
            tmptext += '\n';
            tmptext += temp[ 1 ];
        }
        else if( temp[0] == "" && temp.Length == 3 ) {
            tmptext += temp[ 1 ];
            tmptext += '\n';
            tmptext += temp[ 2 ];
        } 
        else if(temp[0]== "" && temp.Length == 4 ) {
            tmptext += temp[ 1 ];
            tmptext += '\n';
            tmptext += temp[ 2 ];
            tmptext += '\n';
            tmptext += temp[ 3 ];
        }
        else if( temp.Length == 3 ) {
            tmptext += temp[ 0 ];
            tmptext += '\n';
            tmptext += temp[ 1 ];
            tmptext += '\n';
            tmptext += temp[ 2 ];
        }
        else if( temp.Length == 4 ) {
            tmptext += temp[ 1 ];
            tmptext += '\n';
            tmptext += temp[ 2 ];
            tmptext += '\n';
            tmptext += temp[ 3 ];
        }
        else if(temp.Length == 1 ) {
            
        }
        else {
            tmptext += temp[ 1 ];
            tmptext += '\n';
            tmptext += temp[ 2 ];
        }

        tmptext += "\n";
        tmptext += _log;
        logger.text = tmptext;
    }
    void Update() { }
}
