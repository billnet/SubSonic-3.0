using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SubSonic
{
    public class RowVersionField
    {
        public const string DbReservedFieldName = "__Version";

        public RowVersionField()
        {
        }

        public RowVersionField(Byte[] bytes)
        {
            _bytes = bytes;
        }

        public RowVersionField(string value)
        {
            _bytes = Convert.FromBase64String(value);
        }

        protected Byte[] _bytes = new Byte[] { };

        public Byte[] Bytes
        {
            get
            {
                return _bytes;
            }
        }

        public bool HasValue
        {
            get
            {
                return _bytes.Length > 0;
            }
        }

        public void Update()
        {
            _bytes = Guid.NewGuid().ToByteArray();
        }

        public override bool Equals(object obj)
        {
            if (obj is RowVersionField)
                return ((RowVersionField)obj).ToString().Equals(this.ToString());
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return Convert.ToBase64String(_bytes);
        }

        public static RowVersionField FromString(string value)
        {
            return new RowVersionField(value);
        }

        public static RowVersionField FromBytes(Byte[] bytes)
        {
            return new RowVersionField(bytes);
        }

    }
}
