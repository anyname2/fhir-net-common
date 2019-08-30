/* 
 * Copyright (c) 2015, Firely (info@fire.ly) and contributors
 * See the file CONTRIBUTORS for details.
 * 
 * This file is licensed under the BSD 3-Clause license
 * available at https://raw.githubusercontent.com/FirelyTeam/fhir-net-api/master/LICENSE
 */

using System;
using System.Xml;

namespace Hl7.Fhir.Model.Primitives
{
    public abstract class String
    {
        public static string Parse(string value) =>
            TryParse(value, out string result) ? result : throw new FormatException("String value is in an invalid format.");

        public static bool TryParse(string representation, out string value)
        {
            value = representation;   // a bit obvious
            return true;
        }

        // Comparison functions work according to the rules described for CQL, 
        // see https://cql.hl7.org/09-b-cqlreference.html#comparison-operators-4
        // for more details.

        /// <summary>
        /// Compares two booleans according to CQL equality rules.
        /// </summary>
        /// <param name="l"></param>
        /// <param name="r"></param>
        /// <returns>Return true if both arguments are exactly the same boolean value, false otherwise. Returns null if any of the
        /// arguments are null.</returns>
        public static bool? IsEqualTo(string l, string r) =>
            (l == null || r == null)
                ? null
                : (bool?)(l == r);

        /// <summary>
        /// Compares two booleans according to CQL equivalence rules.
        /// </summary>
        /// <param name="l"></param>
        /// <param name="r"></param>
        /// <returns>Return true if both arguments are exactly the same boolean value, false otherwise</returns>
        public static bool IsEquivalentTo(string l, string r) =>
            l == r;

    }
}
