using System;

namespace Spree.Contracts
{
    public class ContractTypes
    {
        public static Type ResolveFrom(string typeName)
        {
            return Type.GetType(typeName);
        }
    }
}
