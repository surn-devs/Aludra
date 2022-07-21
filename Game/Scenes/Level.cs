using System.Collections.Generic;
using Aludra.Game.Contexts;
using Aludra.Game.Entities;
using Aludra.Game.Entities.Base;
using Aludra.Game.Entities.Enemies;
using Microsoft.Xna.Framework;

namespace Aludra.Game.Scenes;

public class Level : Scene
{
    private const double EnemySpawnCooldown = 10;
    private readonly Queue<GameObject> _destroyQueue = new();
    private readonly List<GameObject> _gameObjects = new() { new Player() };
    private readonly Queue<GameObject> _spawnQueue = new();
    private double _enemySpawnCooldown;

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
        _enemySpawnCooldown -= context.GameTime.ElapsedGameTime.TotalSeconds;
        if (_enemySpawnCooldown <= 0)
        {
            _enemySpawnCooldown = EnemySpawnCooldown;
            Spawn(new BasicEnemy());
        }

        while (_destroyQueue.Count > 0) _gameObjects.Remove(_destroyQueue.Dequeue());
        while (_spawnQueue.Count > 0) _gameObjects.Add(_spawnQueue.Dequeue());

        var levelContext = new LevelUpdateContext(context.GameTime, context.InputHandler, Spawn, Destroy);
        foreach (var gameObject in _gameObjects) gameObject.Update(levelContext);
    }

    public override void Draw(DrawContext context)
    {
        context.SpriteBatch.Draw(context.TextureManager.Get("Background"), Vector2.Zero, Color.White);

        foreach (var gameObject in _gameObjects) gameObject.Draw(context);
    }
}
