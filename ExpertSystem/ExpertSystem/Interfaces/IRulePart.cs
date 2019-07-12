using System;

namespace ExpertSystem
{
    interface IRulePart
    {
        // ID For Object
        Guid ID { get; set; }

        // Value to print
        string TextValue { get; set; }

        // Referencve to parent, Parent´s ID
        Guid ParentReference { get; set; }
    }
}