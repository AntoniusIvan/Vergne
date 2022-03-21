
using System;

namespace EMQV.Models
{
    public abstract class Module
    {
        public object ViewControl = null;
        public object TabControl = null;

        public abstract string Title { get; }

        public abstract Type ViewType { get; }

        public abstract string Role { get; }
    }
}
