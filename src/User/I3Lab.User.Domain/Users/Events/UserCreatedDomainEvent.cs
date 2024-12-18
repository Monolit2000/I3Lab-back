﻿using I3Lab.BuildingBlocks.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Users.Domain.Users.Events
{
    public class UserCreatedDomainEvent : DomainEventBase
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string LastName { get; set; }

        public UserCreatedDomainEvent(
            Guid userId, 
            string name, 
            string email, 
            string lastName)
        {
            UserId = userId;
            Name = name;
            Email = email;
            LastName = lastName;
        }

    }
}
