namespace SimpleGraphEditor.Models.GraphEditingStates
{
    public interface IMementoCareTaker {
        void AddState(GraphMemento graphMemento);
        GraphMemento GetFutureState(int steps = 1);
        GraphMemento GetPrewiousState(int steps = 1);
    }
}