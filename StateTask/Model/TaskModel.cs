﻿namespace StateTask.Model
{
    public class TasksModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public TaskState State { get; set; }
    }
}
