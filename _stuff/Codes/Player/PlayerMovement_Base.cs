using Godot;
using static Godot.Mathf;
using static Godot.Input;

namespace Player
{
    public partial class PlayerMovement_Base : CharacterBody3D
    {
        [Export] float speed = 5.0f;
        [Export] float jumpVelocity = 4.5f;

        float deltaTime = 1/(float)ProjectSettings.GetSetting("physics/common/physics_ticks_per_second");
        float gravity = (float)ProjectSettings.GetSetting("physics/3d/default_gravity");
        
        Vector3 velocity;
        Vector2 inputDir;
        Vector3 direction;

        public override void _Ready()
        {
            velocity = direction = new();
            inputDir = new();
        }

        public override void _PhysicsProcess(double delta)
        {
            velocity = Velocity;

            Gravity_Handler(IsOnFloor());

            CheckInput();

            Velocity = SetVelocity();

            MoveAndSlide();
        }

        private void Gravity_Handler(bool grounded)
        {
            if (!grounded)
            {
                velocity.Y -= (IsActionPressed("ui_accept") ? gravity : gravity * 2.5f) * deltaTime;

                velocity.Y -= gravity * deltaTime;
                return;
            }

            if (IsActionJustPressed("ui_accept") && grounded)
            {
                velocity.Y = jumpVelocity;
                return;
            }
            velocity.Y = -2f;
        }

        private void CheckInput()
        {
            inputDir = GetVector("ui_left", "ui_right", "ui_up", "ui_down");
            direction = (Transform.Basis * new Vector3(inputDir.X, 0, inputDir.Y)).Normalized();
        }

        private Vector3 SetVelocity()
        {
            if (direction.Equals(Vector3.Zero))
            {
                velocity.X = MoveToward(Velocity.X, 0, speed);
                velocity.Z = MoveToward(Velocity.Z, 0, speed);
                return velocity;
            }

            velocity.X = direction.X * speed;
            velocity.Z = direction.Z * speed;

            return velocity;
        }
    }
}
