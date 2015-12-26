# SoftWx.Numerics
##### C# library of math extensions to .Net numeric types
NuGet package at (coming soon)

Currently contains bit fiddling, and base 2 math methods for the 8 integer types (byte, sbyte, ushort, short, uint, int, ulong, and long).
Soon will add in prime number related functions (deterministic Miller Rabin) described in series of blog posts starting with (http://blog.softwx.net/2013/05/miller-rabin-primality-test-in-c.html).
This github library is meant to replace the code that went with those blog posts.

Classes:
* BitMath - optimized bit fiddling methods for integer types
  * LowBit - Returns the least significant set bit
  * HighBit - Returns the most significant set bit
  * LowBitPosition - Returns the least significant set bit position
  * HighBitPosition - Returns the most significant set bit position
  * TrailingZeroBits - Returns the count of trailing zero bits
  * LeadingZeroBits - Returns the count of leading zero bits
  * SignificantBits - Returns the number of bit positions up to and including the most significant set bit
  * BitCount - Returns the count of set bits
  * ReverseBits - Returns the specified value with all bits reversed
* Base2Math - optimized log and power of 2 methods for integer types 
  * Log2 - Returns the integer logarithm base 2 (Floor(Log2(value)))
  * IsPowerOf2 - Determines if the specified value is a power of 2
  * PowerOf2Floor - Returns the nearest power of 2 that's equal or less than the specified value
  * PowerOf2Ceiling - Returns the nearest power of 2 that's equal or greater than the specified value
* Math - optimized general math methods, similar to those in .Net's Math class
  * AbsU - Returns the absolute value of the specified signed value as a corresponding unsigned type
  * MulMod - Returns the product of two values, modulus a third value
  * ModPow - Returns a value raised to a specified value, modulus a third value
* PrimeMath - optimized methods related to prime numbers
  * Gcd - Computes the greatest common divisor of two values
  * IsCoprime - Determines if the specified values are coprime to each other
  * NearestCoprimeFloor - Computes the nearest number less than or equal to the specified start value that is coprime to another specified value
  * NearestCoprimeCeiling - Computes the nearest number greater than or equal to the specified start value that is coprime to another specified value