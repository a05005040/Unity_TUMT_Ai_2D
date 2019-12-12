
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class npc : MonoBehaviour
{
    #region 欄位
    public string say_start = "";
    public string say_complete = "";
    public string complete = "";
    public state _state;
    [Header("道具")]
    public string prop_name = "";
    [Header("對話速度")]
     public float speed = 1.5f;
    [Header("任務相關")]
    public bool pass = false;
    public int Count_player = 0;
    public int Count_finish = 5;
    [Header("介面")]
    public GameObject objCanvas;
    public Text textSay;
    #endregion

    public AudioClip soundSay;
    private AudioSource aud;
    private void Start()
    {
        aud = GetComponent<AudioSource>();
    }

    public enum state
    {
        normal, notComple, comple
    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "狐狸")
        {
            Say();
        }
    
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "狐狸")
            SayClose();
    }
    // <summary>
    /// 對話：打字效果
    /// </summary>
    private void Say()
    {
        // 畫布.顯示
        objCanvas.SetActive(true);
        // 文字介面.文字 = 對話1
        StopAllCoroutines();
        if (Count_player >= Count_finish) _state = state.comple;
        switch (_state)
        {
            case state.normal:
                StartCoroutine(ShowDialog(say_start));           // 開始對話
                _state = state.notComple;
                break;
            case state.notComple:
                StartCoroutine(ShowDialog(say_complete));     // 開始對話未完成
                break;
            case state.comple:
                StartCoroutine(ShowDialog(complete));        // 開始對話完成
                break;          
        }
    }
    private IEnumerator ShowDialog(string say)
    {
        textSay.text = "";                              // 清空文字

        for (int i = 0; i < say.Length; i++)       // 迴圈跑對話.長度
        {
            textSay.text += say[i].ToString();     // 累加每個文字
            aud.PlayOneShot(soundSay, 0.6f);
            yield return new WaitForSeconds(speed);     // 等待
        }
    }

    /// <summary>
    /// 關閉對話
    /// </summary>
    private void SayClose()
    {
        StopAllCoroutines();
        objCanvas.SetActive(false);
    }
    public void PlayerGet()
    {
        Count_player++;
    }
    
}
