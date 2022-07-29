using System;
using Aludra.Game.Entities;

namespace Aludra.Game.Contexts;

public record CollideContext(
    GameObject Other,
    Action<GameObject> Destroy
);
