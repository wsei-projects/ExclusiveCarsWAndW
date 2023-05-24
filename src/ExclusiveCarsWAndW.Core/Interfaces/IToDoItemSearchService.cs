using Ardalis.Result;
using ExclusiveCarsWAndW.Core.ProjectAggregate;

namespace ExclusiveCarsWAndW.Core.Interfaces;

public interface IToDoItemSearchService
{
  Task<Result<ToDoItem>> GetNextIncompleteItemAsync(int projectId);
  Task<Result<List<ToDoItem>>> GetAllIncompleteItemsAsync(int projectId, string searchString);
}
