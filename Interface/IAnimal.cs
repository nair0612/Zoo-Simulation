public interface IAnimal
{
    float Health { get; }
    bool IsDead { get; }
    int ConsecutiveFailures {get; }
    void UpdateHealth(float percentage);
}
