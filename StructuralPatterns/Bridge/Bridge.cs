using System;
using System.Collections.Generic;
using System.Text;

namespace StructuralPatterns.Bridge
{
    public interface IDevice
    {
        string GetName();
    }

    public class Television : IDevice
    {
        public string GetName()
        {
            return nameof(Television);
        }
    }

    public class Radio : IDevice
    {
        public string GetName()
        {
            return nameof(Radio);
        }
    }

    public class Remote
    {
        protected IDevice _device;
        public Remote(IDevice device)
        {
            _device = device;
        }

        public virtual string GetDeviceName()
        {
            return _device.GetName();
        }
    }

    public class AdvancedRemote : Remote
    {
        public AdvancedRemote(IDevice device) : base(device)
        {
        }

        public override string GetDeviceName()
        {
            return $"Extended functionality to {_device.GetName()}";
        }
    }
}
