using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class RootController : MonoBehaviour
{
    private TreeBase treeBase;
    public List<GameObject> AllRoots;
    private int currentRootCount;
    Tween removing;
    Tween adding;
    private void Start()
    {
        treeBase = GetComponentInParent<TreeBase>();
        for (int i = 0; i < AllRoots.Count; i++)
        {
            treeBase.Spawners.Add(AllRoots[i].GetComponentInChildren<Spawner>());
        }
    }
    public void AddRoot()
    {
        if (adding != null)
            return;
        AllRoots[currentRootCount].gameObject.transform.localScale = Vector3.zero;
        AllRoots[currentRootCount].SetActive(true);
        adding=AllRoots[currentRootCount].gameObject.transform.DOScale(Vector3.one, 1)
            .OnComplete(()=> treeBase.Spawners.Add(AllRoots[currentRootCount].GetComponentInChildren<Spawner>()));
    }
    public void RemoveRoot()
    {
        if (removing != null)
            return;
        removing=AllRoots[currentRootCount].gameObject.transform.DOScale(Vector3.zero, 1)
        .OnComplete(() => { AllRoots[currentRootCount].SetActive(false);
        treeBase.Spawners.Add(AllRoots[currentRootCount].GetComponentInChildren<Spawner>());
        });
    }
}
