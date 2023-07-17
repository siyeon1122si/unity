using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public static partial class GFunc
{
    // 래핑 : 이미 있는 함수를 사용하기 쉽게 재정의하는 것
    [System.Diagnostics.Conditional("DEBUG_MODE")]
    public static void Log(object message)
    {
#if DEBUG_MODE
        Debug.Log(message);
#endif
    }

    [System.Diagnostics.Conditional("DEBUG_MODE")]
    public static void Assert(bool condition)
    {
#if DEBUG_MODE
        Debug.Assert(condition);
#endif
    }

    //! Gameobject 받아서 Text 컴포넌트 찾아서 text 필드 값 수정하는 함수
    public static void SetText(this GameObject target, string text)
    {
        Text textComponent = target.GetComponent<Text>();
        // GetComponent<컴포넌트 명>() : 가지고 있는 컴포넌트를 찾는다
        // AddComponent<컴포넌트 명>() : 컴포넌트를 추가해준다
        if (textComponent == null || textComponent == default)
        {
            return;
        }

        textComponent.text = text;
    }

    //! LoadScene 함수 래핑
    public static void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    //! 트정 오브젝트의 자식 오브젝트를 서치해서 컴포넌트를 찾아주는 함수
    public static T FindChildComponent<T>( this GameObject targetObj_ , string objName_) where T : Component
    {
        T searchResultComponent = default(T);
        GameObject searchResultObj = default(GameObject);

        searchResultObj = targetObj_.FindChildObj(objName_);

        if ( searchResultObj != null || searchResultObj != default )
        {
            searchResultComponent = searchResultObj.GetComponent<T>();
        }
        
        return searchResultComponent;
    }   // FindChildComponent()

    //! 특정 오브젝트의 자식 오브젝트를 서치해서 찾아주는 함수
    public static GameObject FindChildObj( this GameObject targetObj_, string objName_ )
    {
        GameObject searchResult = default;
        GameObject searchTarget = default;

        for ( int i = 0; i < targetObj_.transform.childCount; i++ )
        {
            searchTarget = targetObj_.transform.GetChild(i).gameObject;

            if ( searchTarget.name.Equals(objName_)) // if : 내가 찾고 싶은 오브젝트를 찾은 경우 
            {
                searchResult = searchTarget;
                return searchResult;
            }

            else 
            {   // 재귀 함수 : 함수안에서 자기 자신을 호출한다
                searchResult = FindChildObj(searchTarget, objName_);

                if ( searchResult == null || searchResult == default )
                {
                    /* Pass */
                }

                else    // else : 내가 찾고 싶은 오브젝트를 아직 못찾은 경우
                {
                    return searchResult;
                }
            }
        }   // loop : 탐색 타겟 오브젝트의 자식 오브젝트 갯수만큼 순화하는 루프

        return searchResult;

    }   // FindChildObj()

    //! 현재 씬의 이름을 리턴한다.
    public static string GetActiveSceneName()
    {
        return SceneManager.GetActiveScene().name;
    }

    //! 활성화 된 현재 씬의 루트 오브젝트를 서치해서 찾아주는 함수
    public static GameObject GetRootObj( string objName_ )
    {
        Scene activeScene_ = SceneManager.GetActiveScene();
        GameObject[] rootObjs_ = activeScene_.GetRootGameObjects();

        GameObject targetObj_ = default;
        foreach ( GameObject rootObj_ in rootObjs_ )
        {
            if (  rootObj_.name.Equals(objName_) )
            {
                targetObj_ = rootObj_;
                return targetObj_;
            }
            else
            {
                continue;
            }
        }

        return targetObj_;
    }   // GetRootObj()
}
