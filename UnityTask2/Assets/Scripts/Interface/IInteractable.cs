public interface IInteractable
{
    string message { get; }

    void Interaction(Player player);
}