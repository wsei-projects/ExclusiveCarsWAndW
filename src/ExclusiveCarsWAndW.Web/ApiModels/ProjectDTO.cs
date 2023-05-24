﻿namespace ExclusiveCarsWAndW.Web.ApiModels;

// ApiModel DTOs are used by ApiController classes and are typically kept in a side-by-side folder
public class ProjectDTO : CreateProjectDTO
{
  public ProjectDTO(int id, string name, List<ToDoItemDTO>? items = null) : base(name)
  {
    Id = id;
    Items = items ?? new List<ToDoItemDTO>();
  }
  public int Id { get; set; }
  public List<ToDoItemDTO> Items { get; set; }
}

// Creation DTOs should not include an ID if the ID will be generated by the back end
public abstract class CreateProjectDTO
{
  protected CreateProjectDTO(string name)
  {
    Name = name;
  }
  public string Name { get; set; }
}
