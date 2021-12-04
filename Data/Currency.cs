using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    /// <summary>
    /// Currency class
    /// </summary>
    public class Currency : IEquatable<Currency>, IComparable<Currency>, IComparable
    {
        #region Properties

        /// <summary>
        /// Short name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Full Name
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Exchange Rate
        /// </summary>
        public double ExchangeRate { get; set; }

        #endregion

        #region operators
        public static bool operator == (Currency first, Currency second)
        {
            return Equals(first, second);     
        }

        public static bool operator !=(Currency first, Currency second)
        {
            return !(first == second);
        }
        #endregion

        #region static methods

        public static bool Equals(Currency first, Currency second)
        {
            if (Object.ReferenceEquals(first, null))
                return false;

            if (Object.ReferenceEquals(second, null))
                return false;

            return String.Equals(first.Name, second.Name,
                StringComparison.InvariantCultureIgnoreCase);
        }

        #endregion

        #region overriden

        public override bool Equals(object obj)
        {
            if (Object.ReferenceEquals(obj, null))
                return false;
            if (obj.GetType() != this.GetType())
                return false;

            return Equals(this, obj as Currency);
        }

        public override string ToString()
        {
            return this.Name;
        }

        #endregion

        #region IEquatables
        public bool Equals(Currency other)
        {
            return Equals(this, other);
        }

        #endregion

        #region IComparable
        public int CompareTo(Currency other)
        {
            if (other == null || other.ExchangeRate == 0)
                return 1;

            return ExchangeRate.CompareTo(other.ExchangeRate);
        }

        public int CompareTo(object obj)
        {
            if (obj == null)
                return 1;

            if (obj.GetType() == this.GetType())
                return 1;

            return CompareTo(obj as Currency);
        }
        #endregion
    }
}
