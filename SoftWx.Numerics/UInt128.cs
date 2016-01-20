﻿// Copyright ©2015-2016 SoftWx, Inc.
// Released under the MIT License the text of which appears at the end of this file.
// <authors> Steve Hatchett

//#define StandaloneUInt128 // if StandaloneUInt128 is defined UInt128 can operate standalone, without needing other classes in SoftWx.Numerics
// comment the #define if UInt128 is used as part of the SoftWx.Numerics library
using System;

namespace SoftWx.Numerics {
    /// <summary>Represents a 128-bit unsigned integer.</summary>
    /// <remarks>The UInt128 struct is immutable.</remarks>
    public struct UInt128 : IEquatable<UInt128> {
        private readonly ulong hi;
        private readonly ulong lo;

        /// <summary>Gets a value that represents the number 0 (zero).</summary>
        public readonly static UInt128 Zero = new UInt128(0, 0);

        /// <summary>Gets a value that represents the number 1 (one).</summary>
        public readonly static UInt128 One = new UInt128(0, 1);

        /// <summary>Represents the largest possible value of UInt128.</summary>
        public readonly static UInt128 MaxValue = new UInt128(ulong.MaxValue, ulong.MaxValue);

        /// <summary>Represents the smallest possible value of UInt128.</summary>
        public readonly static UInt128 MinValue = UInt128.Zero;

        /// <summary>Computes the 128 bit product of two 64 bit unsigned integers.</summary>
        /// <param name="left">The value to be multiplied by right.</param>
        /// <param name="right">The value to be multiplied by left.</param>
        /// <returns>The UInt128 product of multiplying left and right.</returns>
        public static UInt128 Multiply(ulong left, ulong right) {
            unchecked {
                ulong lhi = left >> 32;
                ulong rhi = right >> 32;
                if ((lhi | rhi) == 0) return left * right;
                ulong hi = lhi * rhi;
                ulong llo = (uint)left;
                ulong mid = llo * rhi;
                ulong rlo = (uint)right;
                ulong lo = llo * rlo;
                ulong mid2 = rlo * lhi;
                mid += mid2;
                hi += mid >> 32;
                if (mid < mid2) hi += 1ul << 32;
                mid <<= 32;
                lo += mid;
                if (lo < mid) hi++;
                return new UInt128(hi, lo);
            }
        }
        /// <summary>Computes the 128 bit product of squaring a 64 bit unsigned integer.</summary>
        /// <param name="value">The value to be squared (multiplied by itself).</param>
        /// <returns>The UInt128 product of squaring the specified value.</returns>
        public static UInt128 Square(ulong value) {
            if (value == (uint)value) return value * value;
            unchecked {
                ulong hi = value >> 32;
                ulong lo = (uint)value;
                ulong mid = lo * hi;
                hi *= hi;
                lo *= lo;
                // mid is 2*lo*hi, but we skipped multiplying by 2 and account for it in the 
                // off by one shifts below so we wouldn't lose data by shifting off a bit doing *2
                hi += mid >> 31;
                mid <<= 33;
                lo += mid;
                if (lo < mid) hi++;
                return new UInt128(hi, lo);
            }
        }
        /// <summary>Creates an instance of UInt128.</summary>
        /// <param name="high">The most significant 64 bits.</param>
        /// <param name="low">The least significant 64 bits.</param>
        public UInt128(ulong high, ulong low) {
            this.hi = high;
            this.lo = low;
        }

        /// <summary>Determines if the UInt128 value is less than or equal to UInt64.MaxValue.</summary>
        public bool IsULong { get { return this.hi == 0; } }

        /// <summary>Returns the lower 64 bits of the UInt128 value.</summary>
        public ulong Low { get { return this.lo; } }

        /// <summary>Returns the upper 64 bits of the UInt128 value.</summary>
        public ulong High { get { return this.hi; } }

        /// <summary>Returns a value indicating whether this instance is equal to a specified value.</summary>
        /// <param name="other">The value to compare to this instance.</param>
        /// <returns>True if value equals the this instance; otherwise, false.</returns>
        public bool Equals(UInt128 other) {
            return this == other;
        }

        /// <summary>Returns a value indicating whether this instance is equal to a specified ulong value.</summary>
        /// <param name="other">The value to compare to this instance.</param>
        /// <returns>True if value equals the this instance; otherwise, false.</returns>
        public bool Equals(ulong other) {
            return this == other;
        }

        /// <summary>Returns a value indicating whether this instance is equal to a specified object.</summary>
        /// <param name="obj">An object to compare to this instance.</param>
        /// <returns>True if obj is an instance of UInt128 and equals the value of this instance; otherwise, false.</returns>
        public override bool Equals(object obj) {
            if (!(obj is UInt128)) {
                return false;
            }
            return this == (UInt128)obj;
        }

        /// <summary>Returns the hash code for this instance.</summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode() {
            return this.hi.GetHashCode() ^ this.lo.GetHashCode();
        }

        /// <summary>Returns the string representation of this instance.</summary>
        /// <returns>The string representation of this instance.</returns>
        public override string ToString() {
            string loStr = this.lo.ToString("X");
            if (this.hi == 0) return loStr;
            loStr = new string('0', (64/4) - loStr.Length) + loStr;
            return this.hi.ToString("X") + ' ' + loStr;
        }

        /// <summary>Defines an explicit conversion of a UInt128 value to an unsigned long value.</summary>
        /// <remarks>Only the lower 64 bits is returned, which may result in loss of data.</remarks>
        /// <param name="value"></param>
        public static explicit operator ulong(UInt128 value) {
            return value.lo;
        }

        /// <summary>Defines an implicit conversion of an unsigned long value to a UInt128 value.</summary>
        public static implicit operator UInt128(ulong value) {
            return new UInt128(0, value);
        }

        /// <summary>Returns a value that indicates whether the two UInt128 are equal.</summary>
        /// <param name="left">The first value to compare.</param>
        /// <param name="right">The second value to compare.</param>
        /// <returns>True if the values are equal, otherwise, false.</returns>
        public static bool operator ==(UInt128 left, UInt128 right) {
            return ((left.hi == right.hi) && (left.lo == right.lo));
        }

        /// <summary>Returns a value that indicates whether the UInt128 is equal to a ulong value.</summary>
        /// <param name="left">The first value to compare.</param>
        /// <param name="right">The second value to compare.</param>
        /// <returns>True if the values are equal, otherwise, false.</returns>
        public static bool operator ==(UInt128 left, ulong right) {
            return ((left.hi == 0) && (left.lo == right));
        }

        /// <summary>Returns a value that indicates whether the ulong value is equal to a UInt128.</summary>
        /// <param name="left">The first value to compare.</param>
        /// <param name="right">The second value to compare.</param>
        /// <returns>True if the values are equal, otherwise, false.</returns>
        public static bool operator ==(ulong left, UInt128 right) {
            return ((right.hi == 0) && (right.lo == left));
        }

        /// <summary>Returns a value that indicates whether the two UInt128 are not equal.</summary>
        /// <param name="left">The first value to compare.</param>
        /// <param name="right">The second value to compare.</param>
        /// <returns>True if the values are not equal, otherwise, false.</returns>
        public static bool operator !=(UInt128 left, UInt128 right) {
            return ((left.hi != right.hi) || (left.lo != right.lo));
        }

        /// <summary>Returns a value that indicates whether the a UInt128 is not equal to a ulong value.</summary>
        /// <param name="left">The first value to compare.</param>
        /// <param name="right">The second value to compare.</param>
        /// <returns>True if the values are not equal, otherwise, false.</returns>
        public static bool operator !=(UInt128 left, ulong right) {
            return ((left.hi != 0) || (left.lo != right));
        }

        /// <summary>Returns a value that indicates whether the a ulong value is not equal to a UInt128.</summary>
        /// <param name="left">The first value to compare.</param>
        /// <param name="right">The second value to compare.</param>
        /// <returns>True if the values are not equal, otherwise, false.</returns>
        public static bool operator !=(ulong left, UInt128 right) {
            return ((right.hi != 0) || (right.lo != left));
        }

        /// <summary>Returns a value that indicates whether a UInt128 value is greater than another UInt128 value.</summary>
        /// <param name="left">The first value to compare.</param>
        /// <param name="right">The second value to compare.</param>
        /// <returns>True if the left is greater than right, otherwise, false.</returns>
        public static bool operator >(UInt128 left, UInt128 right) {
            if (left.hi > right.hi) return true;
            if (left.hi < right.hi) return false;
            return left.lo > right.lo;
        }

        /// <summary>Returns a value that indicates whether a UInt128 value is less than another UInt128 value.</summary>
        /// <param name="left">The first value to compare.</param>
        /// <param name="right">The second value to compare.</param>
        /// <returns>True if the left is less than right, otherwise, false.</returns>
        public static bool operator <(UInt128 left, UInt128 right) {
            if (left.hi < right.hi) return true;
            if (left.hi > right.hi) return false;
            return left.lo < right.lo;
        }

        /// <summary>Returns a value that indicates whether a UInt128 value is greater than or equal to another UInt128 value.</summary>
        /// <param name="left">The first value to compare.</param>
        /// <param name="right">The second value to compare.</param>
        /// <returns>True if the left is greater than or equal to right, otherwise, false.</returns>
        public static bool operator >=(UInt128 left, UInt128 right) {
            if (left.hi > right.hi) return true;
            if (left.hi < right.hi) return false;
            return left.lo >= right.lo;
        }

        /// <summary>Returns a value that indicates whether a UInt128 value is less than or equal to another UInt128 value.</summary>
        /// <param name="left">The first value to compare.</param>
        /// <param name="right">The second value to compare.</param>
        /// <returns>True if the left is less than or equal to right, otherwise, false.</returns>
        public static bool operator <=(UInt128 left, UInt128 right) {
            if (left.hi < right.hi) return true;
            if (left.hi > right.hi) return false;
            return left.lo <= right.lo;
        }

        /// <summary>Returns the bitwise one's complement of a UInt128 value.</summary>
        /// <param name="value">The value to be complemented.</param>
        /// <returns>The bitwise one's complement of value.</returns>
        public static UInt128 operator ~(UInt128 value) {
            return new UInt128(~value.hi, ~value.lo);
        }

        /// <summary>Performs a bitwise And operation on two values.</summary>
        /// <param name="left">The first value.</param>
        /// <param name="right">The second value.</param>
        /// <returns>The result of the bitwise And operation.</returns>
        public static UInt128 operator &(UInt128 left, UInt128 right) {
            return new UInt128(left.hi & right.hi, left.lo & right.lo);
        }

        /// <summary>Performs a bitwise Or operation on two values.</summary>
        /// <param name="left">The first value.</param>
        /// <param name="right">The second value.</param>
        /// <returns>The result of the bitwise Or operation.</returns>
        public static UInt128 operator |(UInt128 left, UInt128 right) {
            return new UInt128(left.hi | right.hi, left.lo | right.lo);
        }

        /// <summary>Shifts a UInt128 value a specified number of bits to the left.</summary>
        /// <param name="value">The value whose bits are to be shifted.</param>
        /// <param name="shift">The number of bits to shift value to the left.</param>
        /// <returns>A value that has been shifted to the left by the specified number of bits.</returns>
        public static UInt128 operator <<(UInt128 value, int shift) {
            if (shift == 0) return value;
            return (shift >= 64) ? new UInt128(value.lo << (shift - 64), 0UL)
                : new UInt128((value.hi << shift) | (value.lo >> 64 - shift), value.lo << shift);
        }

        /// <summary>Shifts a UInt128 value a specified number of bits to the right.</summary>
        /// <param name="value">The value whose bits are to be shifted.</param>
        /// <param name="shift">The number of bits to shift value to the right.</param>
        /// <returns>A value that has been shifted to the right by the specified number of bits.</returns>
        public static UInt128 operator >>(UInt128 value, int shift) {
            if (shift == 0) return value;
            return (shift >= 64) ? new UInt128(0UL, value.hi >> (shift - 64))
                : new UInt128(value.hi >> shift, (value.lo >> shift) | (value.hi << 64 - shift));
        }

        /// <summary>Adds two specified UInt128 values.</summary>
        /// <param name="left">The first value to add.</param>
        /// <param name="right">The second value to add.</param>
        /// <returns>The sum of left and right.</returns>
        public static UInt128 operator +(UInt128 left, UInt128 right) {
            ulong newLo = unchecked(left.lo + right.lo);
            ulong newHi = left.hi + right.hi;
            if (newLo < left.lo) newHi++;
            return new UInt128(newHi, newLo);
        }

        public static UInt128 operator +(UInt128 left, ulong right) {
            ulong newLo = unchecked(left.lo + right);
            ulong newHi = left.hi;
            if (newLo < left.lo) newHi++;
            return new UInt128(newHi, newLo);
        }
        public static UInt128 operator +(ulong left, UInt128 right) {
            return right + left;
        }

        /// <summary>Subtracts a UInt128 value from another UInt128 value.</summary>
        /// <param name="left">The value to subtract from.</param>
        /// <param name="right">The value to subtract.</param>
        /// <returns>The value resulting from subtracting right from left.</returns>
        public static UInt128 operator -(UInt128 left, UInt128 right) {
            return new UInt128(left.hi - right.hi - ((left.lo < right.lo) ? 1UL : 0UL), unchecked(left.lo - right.lo));
        }

        public static UInt128 operator -(UInt128 left, ulong right) {
            return new UInt128(left.hi - ((left.lo < right) ? 1UL : 0UL), unchecked(left.lo - right));
        }

        /// <summary>Increments a value by 1.</summary>
        /// <param name="value">The value to be incremented.</param>
        /// <returns>The value of the parameter incremented by 1.</returns>
        public static UInt128 operator ++(UInt128 value) {
            ulong newLo = unchecked(value.lo + 1);
            return new UInt128((newLo != 0) ? value.hi : value.hi + 1, newLo);
        }

        /// <summary>Decrements a value by 1.</summary>
        /// <param name="value">The value to be decremented.</param>
        /// <returns>The value of the parameter decremented by 1.</returns>
        public static UInt128 operator --(UInt128 value) {
            return new UInt128((value.lo != 0) ? value.hi : value.hi - 1, unchecked(value.lo - 1));
        }

        /// <summary>Multiplies two specified UInt128 values.</summary>
        /// <param name="left">The first value to multiply.</param>
        /// <param name="right">The second value to multiply.</param>
        /// <returns>The productof multiplying left and right.</returns>
        public static UInt128 operator *(UInt128 left, UInt128 right) {
            //var result = UInt128.Multiply(left.lo, right.lo);
            //var temp = UInt128.Multiply(left.lo, right.hi);
            //result += new UInt128(temp.lo, 0UL);
            //temp = UInt128.Multiply(left.hi, right.lo);
            //return result + new UInt128(temp.lo, 0UL);
            var result = UInt128.Multiply(left.lo, right.lo);
            return new UInt128(result.hi + (left.lo * right.hi) + (left.hi * right.lo), result.lo);
        }

        public static UInt128 operator *(UInt128 left, ulong right) {
            var result = UInt128.Multiply(left.lo, right);
            return new UInt128(result.hi + (left.hi * right), result.lo);
        }
        public static UInt128 operator *(ulong left, UInt128 right) {
            return right * left;
        }

        /// <summary>Divides a UInt128 value by another UInt128 value using integer division.</summary>
        /// <param name="left">The value to be divided.</param>
        /// <param name="right">The value to divide by.</param>
        /// <returns>The integral result of the division.</returns>
        public static UInt128 operator /(UInt128 left, UInt128 right) {
            if (right.IsULong) return left / right.lo;
            if (left < right) return UInt128.Zero;
            //if (right.IsPowerOf2()) return left >> right.HighBitPosition();
            return left.Divide(right);
        }
        /// <summary>Divides a UInt128 value by an unsigned long value using integer division.</summary>
        /// <param name="left">The value to be divided.</param>
        /// <param name="right">The value to divide by.</param>
        /// <returns>The integral result of the division.</returns>
        public static UInt128 operator /(UInt128 left, ulong right) {
            if (right == (uint)right) return left / (uint)right;
            if (left < right) return UInt128.Zero;
            if (right.IsPowerOf2()) return left >> right.HighBitPosition();
            return left.Divide(right);
        }

        /// <summary>Divides a UInt128 value by an unsigned long value using integer division.</summary>
        /// <param name="left">The value to be divided.</param>
        /// <param name="right">The value to divide by.</param>
        /// <returns>The integral result of the division.</returns>
        public static UInt128 operator /(UInt128 left, uint right) {
            if (right == 0) throw new DivideByZeroException();
            if (left < right) return UInt128.Zero;
            if (left.hi == 0) return left.lo / right;
            //if (right.IsPowerOf2()) return left >> right.HighBitPosition();
            return left.Divide(right);
        }

        /// <summary>Returns the remainder that results from dividing one UInt128 value by another.</summary>
        /// <param name="left">The value to be divided.</param>
        /// <param name="right">The value to divide by.</param>
        /// <returns>The remainder that results from the division.</returns>
        public static UInt128 operator %(UInt128 left, UInt128 right) {
            if (right.IsULong) return left % right.lo;
            if (left < right) return left;
            if (right.IsPowerOf2()) return left & (right - 1);
            return left.Mod(right);
        }

        /// <summary>Returns the remainder that results from dividing a UInt128 value by an unsigned long value.</summary>
        /// <param name="left">The value to be divided.</param>
        /// <param name="right">The value to divide by.</param>
        /// <returns>The remainder that results from the division.</returns>
        public static ulong operator %(UInt128 left, ulong right) {
            if (right == (uint)right) return left % (uint)right;
            if (left < right) return left.lo;
            if (right.IsPowerOf2()) return left.lo & (right - 1);
            return left.Mod(right);
        }

        /// <summary>Returns the remainder that results from dividing a UInt128 value by an unsigned int value.</summary>
        /// <param name="left">The value to be divided.</param>
        /// <param name="right">The value to divide by.</param>
        /// <returns>The remainder that results from the division.</returns>
        public static uint operator %(UInt128 left, uint right) {
            if (right == 0) throw new DivideByZeroException();
            if (left < right) return (uint)left.lo;
            if (left.hi == 0) return (uint)(left.lo % right);
            if (right.IsPowerOf2()) return (uint)left.lo & (right - 1);
            return left.Mod(right);
        }

        internal UInt128 Divide(UInt128 denominator) {
            UInt128 remainder = this;
            UInt128 result = 0;
            ulong resLo, den;
            int denHiBit = denominator.hi.HighBitPosition();
            int remHiBit = this.hi.HighBitPosition();
            int diff = remHiBit - denHiBit;
            if (diff <= 3) {
                // div by subtraction
                resLo = 0;
                do {
                    resLo++;
                    remainder -= denominator;
                } while (remainder >= denominator);
                return resLo;
            }
            if (denHiBit > 10) {
                // div by divide high ulongs
                resLo = this.hi / (denominator.hi + 1); 
            } else {
                // div by shifted divide
                int denShift = denHiBit + 2;
                den = (denominator >> denShift).lo;
                den++;
                if (den >= remainder.hi) {
                    // no danger of overflow
                    resLo = DivUnchecked(remainder.hi, remainder.lo, den);
                    resLo >>= denShift;
                } else {
                    // need overflow check
                    result = remainder.Divide(den);
                    result >>= denShift;
                    resLo = result.lo;
                }
            }
            remainder = this - (denominator * resLo);
            if (remainder < denominator) return resLo;
            return resLo + remainder.Divide(denominator);
        }

        internal UInt128 Divide(ulong denominator) {
            ulong hi = this.hi;
            ulong lo = this.lo;
            //prevent incorrect results if ulong divide would overflow
            ulong resHi = 0;
            if (hi >= denominator) {
                //if (lo != 0) hi++;
                resHi = hi / denominator;
                hi = this.hi - (resHi * denominator);
            }
            return new UInt128(resHi, DivUnchecked(hi, lo, denominator));
        }

        private ulong DivUnchecked(ulong hi, ulong lo, ulong denominator) {
            unchecked {
                //const ulong b = 1ul << 32;
                ulong un1, un0, vn1, vn0, q1, q0, un32, un21, un10, rhat, left, right;
                int s;
                s = denominator.LeadingZeroBits();
                denominator <<= s;
                un10 = lo << s;
                un32 = (s == 0) ? hi : (hi << s) | (lo >> (64 - s));
                un21 = un32 << 32;
                un1 = un10 >> 32;
                un21 += un1;
                un0 = (uint)un10;
                vn0 = (uint)denominator;
                vn1 = denominator >> 32;
                q1 = un32 / vn1;
                if (q1 != 0) {
                    rhat = un32 - ((un32 / vn1) * vn1); // un32 % vn1;
                    left = q1 * vn0;
                    right = (rhat << 32) + un1;
                    while ((left > right) || (q1 != (uint)q1)) {
                        q1--;
                        rhat += vn1;
                        if (rhat != (uint)rhat) break;
                        left -= vn0;
                        right = (rhat << 32) | un1;
                    }
                    un21 -= (q1 * denominator);
                }
                q0 = un21 / vn1;
                rhat = un21 - ((un21 / vn1) * vn1);// un21 % vn1;
                left = q0 * vn0;
                right = (rhat << 32) | un0;
                while ((left > right) || (q0 != (uint)q0)) {
                    q0--;
                    rhat += vn1;
                    if (rhat != (uint)rhat) break;
                    left -= vn0;
                    right = (rhat << 32) | un0;
                }
                return ((q1 << 32) | q0);
            }
        }
        internal UInt128 Divide(uint denominator) {
            uint hihi = (uint)(this.hi >> 32);
            var reshihi = (hihi == 0) ? 0 : hihi / denominator;
            var remainder = (hihi == 0) ? (uint)this.hi : (((ulong)(hihi - (hihi / denominator) * denominator)) << 32) | ((uint)this.hi);
            var reshilo = (uint)(remainder / denominator);
            var remHi = remainder - reshilo * denominator;
            remainder = remHi << 32 | (uint)(this.lo >> 32);
            var reslohi = (uint)(remainder / denominator);
            remHi = remainder - reslohi * denominator;
            remainder = remHi << 32 | (uint)this.lo;
            var reslolo = (uint)(remainder / denominator);
            return new UInt128((ulong)reshihi << 32 | reshilo, (ulong)reslohi << 32 | reslolo);
        }

        internal UInt128 Mod(UInt128 denominator) {
            UInt128 remainder = this;
            ulong resLo, den;
            int denHiBit = denominator.hi.HighBitPosition();
            int remHiBit = this.hi.HighBitPosition();
            int diff = remHiBit - denHiBit;
            if (diff <= 3) {
                // mod by subtraction
                do remainder -= denominator; while (remainder >= denominator);
                return remainder;
            }
            if (denHiBit > 10) { // we don't have to worry about denominator.hi being MaxValue and overflowing, because that case handled above
                // mod by divide high ulongs
                resLo = this.hi / (denominator.hi + 1);
            } else {
                // mod by shifted divide
                int denShift = denHiBit + 2;
                denShift -= 32;
                den = (denominator >> denShift).lo;
                den++;
                if (den > remainder.hi) {
                    resLo = DivUnchecked(remainder.hi, remainder.lo, den);
                    resLo >>= denShift;
                } else {
                    var result = remainder.Divide(den);
                    result >>= denShift;
                    resLo = result.lo;
                }
            }
            remainder = this - (denominator * resLo);
            if (remainder < denominator) return remainder;
            return remainder.Mod(denominator);
        }

        internal ulong Mod(ulong denominator) {
            unchecked {
                ulong hi = this.hi;
                ulong lo = this.lo;
                //prevent incorrect results if divide would overflow
                if (hi >= denominator) hi -= ((hi / denominator) * denominator);
                if (hi == 0) return lo - ((lo / denominator) * denominator);// lo % denominator;

                ulong un1, un0, vn1, vn0, q1, q0, un32, un21, un10, rhat, left, right;
                int s;
                s = denominator.LeadingZeroBits();
                denominator <<= s;
                un10 = lo << s;
                un32 = (s == 0) ? hi : (hi << s) | (lo >> (64 - s));
                un21 = un32 << 32;
                un1 = un10 >> 32;
                un21 += un1;
                un0 = (uint)un10;
                vn0 = (uint)denominator;
                vn1 = denominator >> 32;
                q1 = un32 / vn1;
                if (q1 != 0) {
                    rhat = un32 - ((un32 / vn1) * vn1);// un32 % vn1;
                    left = q1 * vn0;
                    right = (rhat << 32) + un1;
                    while ((left > right) || (q1 != (uint)q1)) {
                        q1--;
                        rhat += vn1;
                        if (rhat != (uint)rhat) break;
                        left -= vn0;
                        right = (rhat << 32) | un1;
                    }
                    un21 -= (q1 * denominator);
                }
                q0 = un21 / vn1;
                rhat = un21 - ((un21 / vn1) * vn1);// un21 % vn1;
                left = q0 * vn0;
                right = (rhat << 32) | un0;
                while ((left > right) || (q0 != (uint)q0)) {
                    q0--;
                    rhat += vn1;
                    if (rhat != (uint)rhat) break;
                    left -= vn0;
                    right = (rhat << 32) | un0;
                }
                return ((un21 << 32) + (un0 - (q0 * denominator))) >> s;
            }
        }

        internal uint Mod(uint denominator) {
            var hihi = (uint)(this.hi >> 32);
            var remainder = (hihi == 0) ? (uint)this.hi : (((ulong)(hihi - (hihi / denominator) * denominator)) << 32) | ((uint)this.hi);
            var remHi = (remainder % denominator) << 32;
            remainder = remHi | (uint)(this.lo >> 32);
            remHi = (remainder % denominator) << 32;
            remainder = remHi | (uint)(this.lo);
            return (uint)(remainder % denominator);
        }

    }
#if StandaloneUInt128
    internal static class SoftWxNumerics {
        public static int HighBitPosition(this ulong value) {
            uint high = (uint)(value >> 32);
            return (high != 0) ? 32 + HighBitPosition(high) : HighBitPosition((uint)value);
        }
        private static readonly byte[] DeBruijnLSBsSet = new byte[] {
            0, 9, 1, 10, 13, 21, 2, 29, 11, 14, 16, 18, 22, 25, 3, 30,
            8, 12, 20, 28, 15, 17, 24, 7, 19, 27, 23, 6, 26, 5, 4, 31
        };
        public static int HighBitPosition(this uint value) {
            if (value == 0) return -1;
            value |= value >> 1;
            value |= value >> 2;
            value |= value >> 4;
            value |= value >> 8;
            return DeBruijnLSBsSet[unchecked((value | value >> 16) * 0x07c4acddu) >> 27];
        }
        /// <summary>Returns the count of leading zero bits in the specified value.</summary>
        /// <remarks>Example: LeadingZeroBits(10) returns 4, i.e. 00001010 has 4 leading 0 bits.</remarks>
        /// <param name="value">The value whose leading zero bit count is desired.</param>
        /// <returns>The count of the value parameter's leading zero bits.</returns>
        public static int LeadingZeroBits(this ulong value) {
            return 63 - HighBitPosition(value);
        }
        /// <summary>Determines if the specified value is a power of 2.</summary>
        /// <param name="value">The value to be tested as a power of 2.</param>
        /// <returns>True if the value is a power of 2, otherwise false.</returns>
        public static bool IsPowerOf2(this uint value) {
            return ((value & unchecked(value - 1)) == 0) && (value != 0);
        }
        /// <summary>Determines if the specified value is a power of 2.</summary>
        /// <param name="value">The value to be tested as a power of 2.</param>
        /// <returns>True if the value is a power of 2, otherwise false.</returns>
        public static bool IsPowerOf2(this ulong value) {
            return ((value & unchecked(value - 1UL)) == 0) && (value != 0);
        }
        /// <summary>Determines if the specified value is a power of 2.</summary>
        /// <param name="value">The value to be tested as a power of 2.</param>
        /// <returns>True if the value is a power of 2, otherwise false.</returns>
        public static bool IsPowerOf2(this UInt128 value) {
            return ((value & unchecked(value - 1)) == 0) && (value != 0);
        }
        /// <summary>Returns the most significant set bit position of the specified value,
        /// or -1 if no bits were set. The least significant bit position is 0.</summary>
        /// <remarks>Example: HighBitPosition(10) returns 3, i.e. high bit of 00001010 is position 3.</remarks>
        /// <param name="value">The value whose most significant bit position is desired.</param>
        /// <returns>The value parameter's most significant bit position.</returns>
        public static int HighBitPosition(this UInt128 value) {
            return (value.High != 0) ? 64 + HighBitPosition(value.High) : HighBitPosition(value.Low);
        }
    }
#endif
}
/*
Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
*/
