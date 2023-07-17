using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public static partial class GFunc
{
    // ���� : �̹� �ִ� �Լ��� ����ϱ� ���� �������ϴ� ��
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

    //! Gameobject �޾Ƽ� Text ������Ʈ ã�Ƽ� text �ʵ� �� �����ϴ� �Լ�
    public static void SetText(this GameObject target, string text)
    {
        Text textComponent = target.GetComponent<Text>();
        // GetComponent<������Ʈ ��>() : ������ �ִ� ������Ʈ�� ã�´�
        // AddComponent<������Ʈ ��>() : ������Ʈ�� �߰����ش�
        if (textComponent == null || textComponent == default)
        {
            return;
        }

        textComponent.text = text;
    }

    //! LoadScene �Լ� ����
    public static void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    //! Ʈ�� ������Ʈ�� �ڽ� ������Ʈ�� ��ġ�ؼ� ������Ʈ�� ã���ִ� �Լ�
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

    //! Ư�� ������Ʈ�� �ڽ� ������Ʈ�� ��ġ�ؼ� ã���ִ� �Լ�
    public static GameObject FindChildObj( this GameObject targetObj_, string objName_ )
    {
        GameObject searchResult = default;
        GameObject searchTarget = default;

        for ( int i = 0; i < targetObj_.transform.childCount; i++ )
        {
            searchTarget = targetObj_.transform.GetChild(i).gameObject;

            if ( searchTarget.name.Equals(objName_)) // if : ���� ã�� ���� ������Ʈ�� ã�� ��� 
            {
                searchResult = searchTarget;
                return searchResult;
            }

            else 
            {   // ��� �Լ� : �Լ��ȿ��� �ڱ� �ڽ��� ȣ���Ѵ�
                searchResult = FindChildObj(searchTarget, objName_);

                if ( searchResult == null || searchResult == default )
                {
                    /* Pass */
                }

                else    // else : ���� ã�� ���� ������Ʈ�� ���� ��ã�� ���
                {
                    return searchResult;
                }
            }
        }   // loop : Ž�� Ÿ�� ������Ʈ�� �ڽ� ������Ʈ ������ŭ ��ȭ�ϴ� ����

        return searchResult;

    }   // FindChildObj()

    //! ���� ���� �̸��� �����Ѵ�.
    public static string GetActiveSceneName()
    {
        return SceneManager.GetActiveScene().name;
    }

    //! Ȱ��ȭ �� ���� ���� ��Ʈ ������Ʈ�� ��ġ�ؼ� ã���ִ� �Լ�
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
