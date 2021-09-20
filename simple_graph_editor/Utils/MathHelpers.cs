using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text;

namespace SimpleGraphEditor.Utils
{
    public static class MathHelpers {


        public static (int x, int y) GetProjectionOnLine((int x, int y) projectedVect, (int x, int y) dirVector){

            int projectedVectDotProduct = GetDotProduct(dirVector, projectedVect);
            int dirVectDotProd = GetDotProduct(dirVector, dirVector);

            double projectionCoef = projectedVectDotProduct / (double)dirVectDotProd;

            return ((int) Math.Round(dirVector.x * projectionCoef),(int)Math.Round(dirVector.y * projectionCoef));
        }

        public static int GetVectorsDistance((int x, int y) vec1, (int x, int y) vec2){
            (int x, int y) vecBetween = (vec1.x - vec2.x, vec1.y - vec2.y);
            return GetVectorNorm(vecBetween);
        }

        public static (int x, int y) GetVectorOfGivenLength((int x, int y) vec, int len) {
            var initialVecNorm = GetVectorNorm(vec);

            return ((int)(len * (vec.x / (double)initialVecNorm)), (int)(len * (vec.y / (double)initialVecNorm)));
        }

        public static int GetVectorNorm((int x, int y) vec)
            => (int)Math.Round(Math.Sqrt((double)GetDotProduct(vec, vec)));

        public static int GetDotProduct((int x, int y) vec1, (int x, int y) vec2) =>
            vec1.x * vec2.x + vec1.y * vec2.y;

        /*public static int GetAproximatedPointOnSquareFromCenter(int size) {
            //int position = (1 - Math.Abs(size*))

        }*/


    }
}
