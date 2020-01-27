namespace Paradigms.Module_1
{
    public class SortContext
    {
        public Sorts ContextStrategy { private get; set; }

        public SortContext(Sorts strategy)
        {
            ContextStrategy = strategy;
        }

        public void ExecuteSort(int[,] array, SortOrder sortOrder)
        {
            ContextStrategy.Sort(array, sortOrder);
        }
    }
}
