﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public class TVector
    {
        public double[] Vector;

        // Индексирование
        public double this[int i]
        {
            get { return Vector[i]; }
            set { Vector[i] = value; }
        }

      
        public TVector()
        {
        }

        // Конструктор класса по массиву
        public TVector(double[] vector)
        {
            Vector = vector;
        }

        // Умножение на число
        public TVector Mult(double a)
        {
            double[] result = new double[Vector.Length];
            for (int i = 0; i < Vector.Length; i++)
            {
                result[i] = a * Vector[i];

            }
            TVector ResultVector = new TVector(result);
            return ResultVector;
        }

        // Сумма векторов
        public TVector Sum(TVector Vector2)
        {
            TVector ResultVector;
            double[] result = new double[Vector.Length];
            if (result.Length == Vector2.Length())
            {
                for (int i = 0; i < result.Length; i++)
                {
                    result[i] = Vector[i] + Vector2.Vector[i];
                }
            }
            ResultVector = new TVector(result);
            return ResultVector;
        }

        // Скалярное произведение
        public double MultScalar(TVector Vector2)
        {
            double result = 0;
            if (Vector.Length == Vector2.Vector.Length)
            {
                for (int i = 0; i < Vector.Length; i++)
                {
                    result = result + Vector[i] * Vector2.Vector[i];

                }
            }
            return result;
        }

        // Длина (размерность)
        public int Length()
        {
            return Vector.Length;
        }

        // Длина (модуль)
        public double Norm()
        {
            double result = 0;
            for (int i = 0; i < Vector.Length; i++)
            {
                result = result + Vector[i] * Vector[i];
            }
            return Math.Sqrt(result);
        }

        // Умножение на вектор (Векторное произв.)
        public TVector Mult(TVector Vector2)
        {
            double[] result = new double[Vector.Length];
            if (Vector.Length == 3 & Vector2.Vector.Length == 3)
            {
                result[0] = Vector[1] * Vector2.Vector[2] - Vector[2] * Vector2.Vector[1];
                result[1] = Vector[2] * Vector2.Vector[0] - Vector[0] * Vector2.Vector[2];
                result[2] = Vector[0] * Vector2.Vector[1] - Vector[1] * Vector2.Vector[0];
            }
            TVector ResultVector = new TVector(result);
            return ResultVector;
        }

        #region    // Поворот на угол вокруг оси (через кватернионы)
        /*  public TVector RotateByAngleOnAxis(double phi, TVector V)
          {
              TQuaternion Q = new TQuaternion(phi, V);
              Q = Q.Normalization();
              TQuaternion ThisVecQ = new TQuaternion(0, Vector[0], Vector[1], Vector[2]);
              TQuaternion ResultQ = Q.Mult(ThisVecQ);
              ResultQ = ResultQ.Mult(Q.Conjugate());
              TVector Result = new TVector(Vector);
              for (int i = 1; i < 4; i++)
              {
                  Result.Vector[i - 1] = ResultQ.Vec[i];
              }
              return Result;
          }*/

        // Поворот с помощью кватерниона
        /*/  public TVector RotateByQuaternion(TQuaternion Q)
          {
              TVector Result = new TVector(Vector);
              TQuaternion ResultQ;
              TQuaternion vector = new TQuaternion(0, this);
              ResultQ = Q.Mult(vector);
              ResultQ = ResultQ.Mult(Q.Conjugate());
              for (int i = 1; i < 4; i++)
              {
                  Result.Vector[i - 1] = ResultQ.Vec[i];
              }
              return Result;
          }*/
        #endregion

        // Перегрузки операторов

        // + вектор
        public static TVector operator +(TVector a, TVector b)
        {
            return a.Sum(b);
        }
        public static TVector operator -(TVector a, TVector b)
        {
            return a.Sum((-1)*b);
        }

        // * на число
        public static TVector operator *(TVector a, double value)
        {
            return a.Mult(value);
        }
        public static TVector operator *(double value, TVector a)
        {
            return a.Mult(value);
        }

        // * на вектор (векторное произведение)
        public static TVector operator *(TVector a, TVector b)
        {
            return a.Mult(b);
        }
        
 
        // * на вектор (скалярное произведение)
        public static double operator %(TVector a, TVector b)
        {
            return a.MultScalar(b);
        }
     
        public TVector Take(int count)
        {
            return new TVector(this.Vector.Take(count).ToArray());
        }
        public TVector Concat(TVector B)
        {
            return new TVector(this.Vector.Concat(B.Vector).ToArray());
        }


    }
}
 