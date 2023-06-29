using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reward : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    [SerializeField]
    private Image _icon;

    private IEnumerator MoveAnimation(Vector3 start, Vector3 end)
    {
        transform.localPosition = start;
        while (Vector3.Distance(transform.localPosition, end) > 0.001f)
        {
            var step = _speed * Time.deltaTime;
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, end, step);

            yield return new WaitForEndOfFrame();
        }

        Destroy(gameObject);
    }

    public void StartMoveAnimation(Sprite iconSprite, Vector3 start, Vector3 end)
    {
        _icon.sprite = iconSprite;
        StartCoroutine(MoveAnimation(start, end));
    }

    private void OnDisable()
    {
        //Удалить объект, если он стал невидимым  (например, когда зашли в другой экран)
        Destroy(gameObject);
    }
}
