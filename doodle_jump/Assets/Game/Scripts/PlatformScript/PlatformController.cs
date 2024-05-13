using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class PlatformController : MonoBehaviour
{
    protected ObjectPool<PlatformController> _pool;
    private InGameScene _gameScene;

    public virtual void SetPool(ObjectPool<PlatformController> pool)
    {
        _pool = pool;
    }


    protected virtual void Start()
    {
        this.Init();
        _gameScene = Util.FindChildWithPath<InGameScene>("@InGameScene");
    }

    protected virtual void Init()
    {
        this.GetComponent<BoxCollider2D>().isTrigger = true;
    }

    protected virtual void OnEnable()
    {
        this.StartCoroutine(BecomeInvisible());
    }
    protected virtual IEnumerator BecomeInvisible()
    {
        while (true)
        {
            yield return null;
            if (this.transform.position.y + 2 < _gameScene.PlayerController.transform.position.y)
            {//Release �ڷ�ƾ�� ù start �ÿ��� ȣ����� �ʵ��� ����.
                if (_pool != null)
                {
                    _pool.Release(this);
                }
            }
        }
    }

    protected virtual void GoDownPlatform()//�Ʒ��� �������� Platform
    {
        
    }
}