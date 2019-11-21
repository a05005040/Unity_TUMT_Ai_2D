
using UnityEngine;
using UnityEngine.UI;

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
    public int Count_finish = 10;
    [Header("介面")]
    public GameObject objCanvas;
    public Text textSay;
    #endregion
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
        textSay.text = say_start;
        switch (_state)
        {
            case state.normal:
                textSay.text = say_start;
                break;
            case state.notComple:
                textSay.text = say_complete;
                break;
            case state.comple:
                textSay.text = complete;
                break;          
        }
    }

    /// <summary>
    /// 關閉對話
    /// </summary>
    private void SayClose()
    {
        objCanvas.SetActive(false);
    }
    
}
