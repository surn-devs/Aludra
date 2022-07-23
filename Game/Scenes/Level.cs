using System;
using System.Collections.Generic;
using Aludra.Game.Contexts;
using Aludra.Game.Entities;
using Aludra.Game.Entities.Base;
using Aludra.Game.Entities.Enemies;
using Aludra.Game.Timers;
using Microsoft.Xna.Framework;

namespace Aludra.Game.Scenes;

public class Level : Scene
{
    private readonly Queue<GameObject> _destroyQueue = new();
    private readonly ThrottleTimer _enemySpawnTimer = new(5);
    private readonly List<GameObject> _gameObjects = new() { new Player() };
    private readonly Queue<GameObject> _spawnQueue = new();

    private void Spawn(GameObject gameObject)
    {
        _spawnQueue.Enqueue(gameObject);
    }

    private void Destroy(GameObject gameObject)
    {
        _destroyQueue.Enqueue(gameObject);
    }

    public override void Update(UpdateContext context)
    {
        if (_enemySpawnTimer.UpdateAndAct(context)) Spawn(new BasicEnemy());

        while (_destroyQueue.Count > 0) _gameObjects.Remove(_destroyQueue.Dequeue());
        while (_spawnQueue.Count > 0) _gameObjects.Add(_spawnQueue.Dequeue());

        var levelContext = new LevelUpdateContext(context.GameTime, context.InputHandler, Spawn, Destroy);
        foreach (var gameObject in _gameObjects) gameObject.Update(levelContext);

        for (var i = 0; i < _gameObjects.Count; i++)
        for (var j = i + 1; j < _gameObjects.Count; j++)
            if (_gameObjects[i] is RigidBodyObject first && _gameObjects[j] is RigidBodyObject second &&
                (first.Position - second.Position).LengthSquared() < Math.Pow(first.Radius + second.Radius, 2))
            {
                first.CollideWith(new CollideContext(second, Destroy));
                second.CollideWith(new CollideContext(first, Destroy));
            }
    }

    public override void Draw(DrawContext context)
    {
        context.SpriteBatch.Draw(context.TextureManager.Get("Background"), Vector2.Zero, Color.White);

        foreach (var gameObject in _gameObjects) gameObject.Draw(context);
    }
}
