using Godot;
using static Godot.Mathf;
using static Godot.Input;

namespace Player
{
    public partial class PlayerMovement_Base : CharacterBody3D
    {
        [Export] float speed = 5.0f;
        [Export] float jumpVelocity = 4.5f;

        float deltaTime = (float)ProjectSettings.GetSetting("physics/common/physics_ticks_per_second");
        float gravity = (float)ProjectSettings.GetSetting("physics/3d/default_gravity");

        Vector3 velocity;
        Vector2 inputDir;
        Vector3 direction;
        bool isGrounded;

        public override void _Ready()
        {
            velocity = direction = new();
            inputDir = new();
        }

        public override void _PhysicsProcess(double delta)
        {
            velocity = Velocity;
            isGrounded = IsOnFloor();

            if (!isGrounded)
                velocity.Y -= gravity * deltaTime;

            if (IsActionJustPressed("ui_accept") && isGrounded)
                velocity.Y = jumpVelocity;

            CheckInput();

            Velocity = SetVelocity();

            MoveAndSlide();
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
