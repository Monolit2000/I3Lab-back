using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.BuildingBlocks.Domain
{
    public abstract class Entity
    {
        private List<IDomainEvent> _domainEvents = [];

        /// <summary>
        /// Domain events occurred.
        /// </summary>
        public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents?.AsReadOnly();

        public void ClearDomainEvents()
            => _domainEvents?.Clear();


        public IReadOnlyCollection<IDomainEvent> GetDomainEvents() => _domainEvents.ToList();

        /// <summary>
        /// Add domain event.
        /// </summary>
        /// <param name="domainEvent">Domain event.</param>
        protected void AddDomainEvent(IDomainEvent domainEvent)
        {
            _domainEvents ??= [];

            this._domainEvents.Add(domainEvent);
        }

        protected Result CheckRule(IBusinessRule rule)
        {
            if (rule.IsBroken())
            {
                return Result.Fail(rule.Message);
            }

            return Result.Ok();
        }

        protected Result CheckRules(params IBusinessRule[] rules)
        {
            foreach (var rule in rules)
                return CheckRule(rule); 

            return Result.Ok();
        }
        //if (rule.IsBroken())
        //{
        //    return Result.Fail(rule.Message);
        //}
    }
}
