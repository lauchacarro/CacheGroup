using System;

namespace CacheGroup
{
    public struct ArrayEquatable<T> : IEquatable<ArrayEquatable<T>>
    {
        public T[] Value { get; set; }

        public bool Equals(ArrayEquatable<T> otherArray)
        {
            if (this.Value.Length != otherArray.Value.Length) return false;

            for (int i = 0; i < this.Value.Length; i++)
            {
                if (!this.Value[i].Equals(otherArray.Value[i]))
                    return false;
            }

            return true;
        }

        public override int GetHashCode()
        {
            return this.Value.GetHashCode();
        }

        public override bool Equals(object obj) => obj is ArrayEquatable<T> array && Equals(array);


        public static bool operator ==(ArrayEquatable<T> operand1, ArrayEquatable<T> operand2) => operand1.Equals(operand2);

        public static bool operator !=(ArrayEquatable<T> operand1, ArrayEquatable<T> operand2) => !operand1.Equals(operand2);

        public static implicit operator ArrayEquatable<T>(T[] array) => new()
        {
            Value = array
        };

        public static explicit operator T[](ArrayEquatable<T> arrayEquatable) => arrayEquatable.Value;
    }
}
