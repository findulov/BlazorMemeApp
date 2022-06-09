namespace MemeApp.Blazor.Common.State
{
    public class StateContainer
    {
        private int memeCount;

        public int MemeCount
        {
            get => memeCount;
            set
            {
                memeCount = value;
                NotifyStateChanged();
            }
        }

        public event Action? OnChange;

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
