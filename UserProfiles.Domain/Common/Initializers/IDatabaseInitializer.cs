using System;
using System.Collections.Generic;
using System.Text;

namespace UserProfiles.Domain.Common.Initializers
{
    public interface IDatabaseInitializer
    {
        void Initialize();
    }
}
