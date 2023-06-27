using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PointMovement : MonoBehaviour
{
    [SerializeField] List<Transform> points = new List<Transform>();

    private void Start()
    {
        Patrolling();
    }

    public void Patrolling()
    {
        var sequence = DOTween.Sequence().SetLoops(-1);

        foreach (Transform point in points)
        {
            sequence.Append(transform.DOMove(point.position, 2f).SetEase(Ease.Linear).OnComplete(() =>
            {
                GetComponent<SpriteRenderer>().flipX = !(GetComponent<SpriteRenderer>().flipX); 
            }));
        }
    }

}
