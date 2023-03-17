namespace Game
{
    public class Unit
    {
        public string Name { get; init; }
        public Transform Transform { get; init; }
        public Vital Vital { get; init; }

        public Unit(
            string name, 
            Transform transform,
            Vital vital)
        {
            this.Name = name;
            this.Transform = transform;
            this.Vital = vital;
        }

        public void Update(Transform transform)
        {
            Transform.X = transform.X;
            Transform.Y = transform.Y;
            Transform.Z = transform.Z;
        }

        public void Update(Vital vital)
        {
            Vital.MainHealth = vital.MainHealth;
        }
    }
}