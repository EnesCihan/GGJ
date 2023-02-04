using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAIBrain
{
    void SelectAI(bool status);
    void Initialize();
    void SetTarget();
    void ArriveTarget();
}
