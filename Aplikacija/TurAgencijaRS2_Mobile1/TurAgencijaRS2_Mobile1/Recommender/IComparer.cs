using System;
using System.Collections.Generic;
using System.Text;

namespace TurAgencijaRS2_Mobile1
{
 public   interface IComparer
    {
        double CompareVectors(List<int> userFeaturesOne, List<int> userFeaturesTwo);
    }
}
