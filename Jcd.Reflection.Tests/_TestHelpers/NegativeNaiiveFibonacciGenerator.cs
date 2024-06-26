﻿#region

using System.Numerics;

// ReSharper disable HeapView.ObjectAllocation.Evident
// ReSharper disable HeapView.ClosureAllocation
// ReSharper disable HeapView.DelegateAllocation

#endregion

namespace Jcd.Reflection.Tests._TestHelpers;

/// <summary>
/// Generates all Fibonacci numbers equal to or greater than the minValue
/// </summary>
public class NegativeNaiiveFibonacciGenerator
   : CaptureAndTransitionGenerator<NegativeNaiiveFibonacciGenerator.State, BigInteger>
{
   public NegativeNaiiveFibonacciGenerator(BigInteger minValue)
      : base(new State { N0 = 0, N1 = -1, Nth = 0 }
           , (State state, out bool @continue) =>
             {
                var t = state.N0;
                state.N0 =  state.N1;
                state.N1 += t;
                state.Nth++;
                @continue = state.N0 >= minValue;

                return state.N1 - state.N0;
             }
            )
   {
      CurrentState.Nth = 0;
   }

   public class State
   {
      public BigInteger N0;
      public BigInteger N1;

      // ReSharper disable once NotAccessedField.Global
      public int Nth;
   }
}