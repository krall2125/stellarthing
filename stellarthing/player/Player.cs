using System;
using starry;
using static starry.Starry;

namespace stellarthing;

public class Player : IEntity
{
    public EntityInformation setup() => new() {
        type = EntityType.gameWorld,
        tag = "player",
    };

    Sprite spr = load<Sprite>("bob_guy.png");
    //double speed = 400;

    TransformComp tf = new() {
        position = vec3(-500, 0, -500),
    };
    TileComp render = new();

    public Player() {}

    public void update(double delta)
    {
        Camera.target = tf.position.as2d();
        tf.rotation = World.lookAt(tf.position.as2d(), Application.getMousePosition());
        render.update(spr, tf);
    }
}