﻿using System;

namespace TodoMvcApp.Models
{
    public class Todo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsCompleted { get; set; }

        public DateTime CreatedAt { get; set; }  // ✅ New field
    }
}
