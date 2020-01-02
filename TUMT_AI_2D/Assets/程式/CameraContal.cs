
using UnityEngine;
namespace KID
{
    public class CameraContal : MonoBehaviour
    {

        private Transform target;
        [Header("速度"),Range(0,10)]
        public float speed = 3;
        public void Start()
        {
            target = GameObject.Find("狐狸").transform;
        }
        //延遲更新:Update 之後執行 攝影機追蹤 物件追蹤
        private void LateUpdate()
        {
            Vector3 cam = transform.position;
            Vector3 tar = target.position;
            tar.y = Mathf.Clamp(tar.y, -1, 1);
            tar.z = -10;
            transform.position = Vector3.Lerp(cam, tar, 0.3f * Time.deltaTime * speed);
        }
    }
    
}

