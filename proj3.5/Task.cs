﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace TaskApplication
{
    public class Task : Item, INotifyPropertyChanged
    {
        public override Visibility IsCompleteable => Visibility.Visible;
        private bool isCompleted;
        public bool IsCompleted {
            get
            {
                return isCompleted;
            }
            set
            {
                isCompleted = value;
                NotifyPropertyChanged();
                NotifyPropertyChanged("Completed");
            }
        }

        public override bool Completed { get => IsCompleted; set => IsCompleted = value; }
        public DateTime Deadline { get; set; }
        public override string PrimaryText => $"Task: {Name} - {Description}";
        public override string SecondaryText => $"{Priority} {IsCompleted}";
        public override string ToString()
        {
            return $"{IsCompleted} [{Priority}] {Name} - {Description}";
        }

        public void SetId()
        {
            if(Id > 0)
            {
                return;
            }
            FakeDatabase.LastTaskId++;
            Id = FakeDatabase.LastTaskId;
        }

        public Task()
        {
            Priority = 1;
        }
    }
}
