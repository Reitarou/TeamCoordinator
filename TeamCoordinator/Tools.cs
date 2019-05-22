using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace TeamCoordinator
{
    public static class Tools
    {
        public static Guid CreateFromString(string s)
        {
            if (s == string.Empty)
                return Guid.Empty;
            Guid result;
            try
            {
                result = new Guid(s);
            }
            catch
            {
                Debug.Fail("Wrong cast");
                result = Guid.Empty;
            }
            return result;
        }
    }
}
