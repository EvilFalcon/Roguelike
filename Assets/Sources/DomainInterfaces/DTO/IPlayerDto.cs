﻿using UnityEngine;

namespace DomainInterfaces.DTO
{
    public interface IPlayerDto
    {
        int Speed { get; }
        string IdelState { get; }
        string MoveState { get; }
        string DeadState { get; set; }
        Vector3 Position { get; }
        Quaternion Rotation { get; }
    }
}