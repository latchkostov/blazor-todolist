using ToDoList.Data.Entities;

namespace ToDoList.Data
{
    public class SeedToDos
    {
        public async Task SeedDatabaseWithContactCountOfAsync(ToDoContext context, int totalCount)
        {
            var count = 0;
            var currentCycle = 0;
            while (count < totalCount)
            {
                var list = new List<ToDo>();
                while (currentCycle++ < 100 && count++ < totalCount)
                {
                    list.Add(new ToDo
                    {
                        Description = $"To Do {count}",
                        IsCompleted = count % 2 == 0
                    });
                }
                if (list.Count > 0)
                {
                    context.ToDos?.AddRange(list);
                    await context.SaveChangesAsync();
                }
                currentCycle = 0;
            }
        }
    }
}
