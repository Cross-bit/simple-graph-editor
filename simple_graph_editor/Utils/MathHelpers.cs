using System;

namespace SimpleGraphEditor.Utils
{
    public static class MathHelpers {

        /// <summary> Calculates projection of projectedVec to a line with directional vector dirVector. </summary>
        /// <param name="projectedVect"></param>
        /// <param name="dirVector"></param>
        /// <returns></returns>
        public static (int x, int y) GetProjectionOnLine((int x, int y) projectedVect, (int x, int y) dirVector){

            int projectedVectDotProduct = GetDotProduct(dirVector, projectedVect);
            int dirVectDotProd = GetDotProduct(dirVector, dirVector);

            double projectionCoef = projectedVectDotProduct / (double)dirVectDotProd;

            return ((int) Math.Round(dirVector.x * projectionCoef),(int)Math.Round(dirVector.y * projectionCoef));
        }

        /// <summary> Calculates vectors distance. </summary>
        /// <param name="vec1"></param>
        /// <param name="vec2"></param>
        /// <returns></returns>
        public static int GetVectorsDistance((int x, int y) vec1, (int x, int y) vec2){
            (int x, int y) vecBetween = (vec1.x - vec2.x, vec1.y - vec2.y);
            return GetVectorNorm(vecBetween);
        }

        /// <summary> Returns scalar multiple of vec, with givent length – len.</summary>
        /// <param name="vec"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public static (int x, int y) GetVectorOfGivenLength((int x, int y) vec, int len) {
            var initialVecNorm = GetVectorNorm(vec);

            return ((int)(len * (vec.x / (double)initialVecNorm)), (int)(len * (vec.y / (double)initialVecNorm)));
        }
        /// <summary> Calculates vectors norm(size). </summary>
        /// <param name="vec"></param>
        /// <returns></returns>
        public static int GetVectorNorm((int x, int y) vec)
            => (int)Math.Round(Math.Sqrt((double)GetDotProduct(vec, vec)));

        /// <summary> Returns dot product of vec1, vec2. </summary> 
        /// <param name="vec1"></param>
        /// <param name="vec2"></param>
        /// <returns></returns>
        public static int GetDotProduct((int x, int y) vec1, (int x, int y) vec2) =>
            vec1.x * vec2.x + vec1.y * vec2.y;
    }
}
