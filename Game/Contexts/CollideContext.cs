using System;
using Aludra.Game.Entities.Base;

namespace Aludra.Game.Contexts;

public record CollideContext(
    RigidBodyObject Other,
    Action<GameObject> Destroy
);
