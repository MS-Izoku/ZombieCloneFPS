using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public struct PlayerInputData : IComponentData
{
    public float moveVert;
    public float moveHor;
}
