using Microsoft.AspNetCore.Components;
using System;

namespace Runic_Magic
{
    public class DisposableComponent : ComponentBase, IDisposable
    {
        public virtual void Dispose()
        {

        }
    }
}
