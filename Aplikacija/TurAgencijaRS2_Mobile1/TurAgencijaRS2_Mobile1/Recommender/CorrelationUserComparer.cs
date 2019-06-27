using System;
using System.Collections.Generic;
using System.Text;

namespace TurAgencijaRS2_Mobile1
{
    public class CorrelationUserComparer : IComparer
    {
        public double CompareVectors(List<int> userFeaturesOne, List<int> userFeaturesTwo)
        {

            if (userFeaturesOne.Count == 0)
                return 0;

          
            double sum=0,d_a=0,d_b = 0;

            for (int i = 0; i < userFeaturesOne.Count; i++)
            {
                sum += userFeaturesOne[i] * userFeaturesTwo[i];
                d_a += userFeaturesOne[i] * userFeaturesOne[i];
                d_b += userFeaturesTwo[i] * userFeaturesTwo[i];
            }

          

            return sum / (Math.Sqrt(d_a))*(Math.Sqrt(d_b));





        }
    }
}
