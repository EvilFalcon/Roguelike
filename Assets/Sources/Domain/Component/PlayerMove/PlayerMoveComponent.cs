using DomainInterfaces.Composite.Component;
using DomainInterfaces.DTO;
using UnityEngine;

namespace Domain.Component.PlayerMove
{
    public class PlayerMoveComponent : IComponent
    {
        public PlayerMoveComponent(IPlayerDto playerDto)
        {
            Speed = playerDto.Speed;
            Position = playerDto.Position;
            Rotation = playerDto.Rotation;
        }

        public Quaternion Rotation { get; set; }

        public Vector3 Position { get; set; }

        public int Speed { get; }
    }
}