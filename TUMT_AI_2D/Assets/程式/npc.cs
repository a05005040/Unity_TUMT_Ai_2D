
using UnityEngine;

public class npc : MonoBehaviour
{
   
    public string say_start = "";
    public string say_complete = "";
    public string complete = "";
    [Header("道具")]
    public string prop_name = "";
    [Header("對話速度")]
    public int speed = 50;
    [Header("任務相關")]
    public bool pass = false;
    public int Count_player = 0;
    public int Count_finish = 10;


}
