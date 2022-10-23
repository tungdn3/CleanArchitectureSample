﻿using CleanArchitectureSample.Domain.Exceptions;

namespace CleanArchitectureSample.Domain.ValueObjects
{
    public record PackingListName
    {
        public string Value { get; }

        public PackingListName(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new EmptyPackingListNameException();
            }

            Value = value;
        }

        public static implicit operator string(PackingListName name) => name.Value;

        public static implicit operator PackingListName(string value) => new(value);
    }
}
