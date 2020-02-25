using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

[GenerateAuthoringComponent]
public struct PlayerInputData : IComponentData
{
    public float moveVert;
    public float moveHor;
}
