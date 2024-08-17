using Godot;
using System;

namespace stellarthing;

public partial class Player : CharacterBody3D {
	[Export]
	public int Speed { get; set; } = 50;
	[Export]
	public double RunningThingy { get; set; } = 1.25;
	/// <summary>
	/// multiplied by the gravity
	/// </summary>
	[Export]
	public double JumpStrength { get; set; } = 2;
	[Export]
	public Node3D Model { get; set; }
	[Export]
	public Camera3D Camêra { get; set; }
	[Export]
	public Node3D ThingFafferyFuckery { get; set; }
	[Export]
	public RayCast3D RaycastThing { get; set; }

	public static Camera3D Camera { get; private set; }
	public static Vector3 ThingFafferyFuckeryThingy { get; private set; }
	public static Vector3 ThingFafferyFuckeryThingyHehehehe { get; private set; }
	public static bool CommenceOnslaughter { get; set; }
	AnimationPlayer modelAnimator;
	public static Vector3 OffsetThingy = new(0, -1.5f, -2);
	double gravity = (double)ProjectSettings.GetSetting("physics/3d/default_gravity");
	Label instruction;
	Vector3 snapVector;

    public override void _Ready()
    {
		Camera = Camêra;
        modelAnimator = Model.GetNode<AnimationPlayer>("animation_player");
    }

    public override void _PhysicsProcess(double delta)
	{
		// pausing :D
		if (Input.IsActionJustPressed("pause")) {
			GetNode<Control>("/root/hud/pause/pause").Visible = true;
			GetTree().Paused = true;
		}

		// GRAVITY !!
		Vector3 fall;
		if (!IsOnFloor()) {
			fall = new Vector3(0, (float)(gravity * delta), 0);
		}
		else {
			fall = Vector3.Zero;
		}

		// movement
		float run = Input.IsActionPressed("run") ? (float)RunningThingy : 1.0f;
		
		Vector3 dir = Vector3.Zero;
		if (Input.IsActionPressed("move_left")) dir.X -= 1;
		if (Input.IsActionPressed("move_right")) dir.X += 1;
		if (Input.IsActionPressed("move_forwards")) dir.Z -= 1;
		if (Input.IsActionPressed("move_backwards")) dir.Z += 1;

		dir = dir.Normalized().Rotated(Camera.Rotation.Normalized(), -180).Normalized();
        Velocity = (dir * Speed * new Vector3(run, 0, run)) - (fall * 100);

		// jump
		bool justLanded = IsOnFloor() && snapVector == Vector3.Zero;
		bool isJumping = IsOnFloor() && Input.IsActionJustPressed("jump");
		if (isJumping) {
			Velocity = new Vector3(Velocity.X, (float)JumpStrength, Velocity.Z);
			snapVector = Vector3.Zero;
		}
		else if (justLanded) {
			snapVector = Vector3.Down;
		}

		ApplyFloorSnap();
		MoveAndSlide();

		if (!dir.IsZeroApprox()) {
			Basis targetRot = Basis.LookingAt(dir);
			Model.Basis = Model.Basis.Slerp(targetRot, 0.1f);
		}

		// animate
		if (!dir.IsZeroApprox() && run < 1.1f) {
			modelAnimator.Play("walk");
		}
		else if (!dir.IsZeroApprox() && run > 1.1f) {
			modelAnimator.Play("walk", customSpeed: (float)RunningThingy * 1.3f);
		}
		else {
			modelAnimator.Play("idle");
		}

		// funni editor stuff
		ThingFafferyFuckery.Position = OffsetThingy;
		ThingFafferyFuckeryThingy = ThingFafferyFuckery.GlobalPosition;
		ThingFafferyFuckeryThingyHehehehe = Model.Rotation;

		// // thy onslaughter (removing items)
		// instruction ??= GetNode<Label>("/root/hud/instruction_notcraft");
		
		// instruction.Visible = CommenceOnslaughter;
		// if (CommenceOnslaughter) {
		// 	if (Input.IsMouseButtonPressed(MouseButton.Left)) {
		// 		Onslaughter.OnslaughterShallCommence(RaycastThing.GetCollider());
		// 	}

		// 	if (Input.IsMouseButtonPressed(MouseButton.Right)) {
		// 		CommenceOnslaughter = false;
		// 	}
		// }
	}
}
