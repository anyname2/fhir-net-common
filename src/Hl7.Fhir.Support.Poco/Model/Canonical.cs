﻿/*
  Copyright (c) 2011+, HL7, Inc.
  All rights reserved.
  
  Redistribution and use in source and binary forms, with or without modification, 
  are permitted provided that the following conditions are met:
  
   * Redistributions of source code must retain the above copyright notice, this 
     list of conditions and the following disclaimer.
   * Redistributions in binary form must reproduce the above copyright notice, 
     this list of conditions and the following disclaimer in the documentation 
     and/or other materials provided with the distribution.
   * Neither the name of HL7 nor the names of its contributors may be used to 
     endorse or promote products derived from this software without specific 
     prior written permission.
  
  THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND 
  ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED 
  WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. 
  IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, 
  INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT 
  NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR 
  PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, 
  WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) 
  ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE 
  POSSIBILITY OF SUCH DAMAGE.
 
*/

using Hl7.Fhir.Introspection;
using System.Runtime.Serialization;
using Hl7.Fhir.Specification;
using System;
using System.Text.RegularExpressions;

namespace Hl7.Fhir.Model
{
    /// <summary>
    /// Primitive Type canonical
    /// </summary>
#if !NETSTANDARD1_1
    [Serializable]
#endif
    [System.Diagnostics.DebuggerDisplay(@"\{{Value}}")] // http://blogs.msdn.com/b/jaredpar/archive/2011/03/18/debuggerdisplay-attribute-best-practices.aspx
    [FhirType("canonical")]
    [DataContract]
    public class Canonical : PrimitiveType, IStringValue
    {
        public override string TypeName { get { return "canonical"; } }
        
        // Must conform to the pattern "\S*"
        public const string PATTERN = @"\S*";

		public Canonical(string value)
		{
			Value = value;
		}

		public Canonical(): this((string)null) {}

        public Canonical(Uri uri) : this(uri?.OriginalString) { }

        public static implicit operator Canonical(string value)
        {
            return new Canonical(value);
        }
        public static implicit operator string(Canonical value)
        {
            return value?.Value;
        }

        /// <summary>
        /// Primitive value of the element
        /// </summary>
        [FhirElement("value", IsPrimitiveValue=true, XmlSerialization=XmlRepresentation.XmlAttr, InSummary=true, Order=30)]
        [DataMember]
        public string Value
        {
            get { return (string)ObjectValue; }
            set { ObjectValue = value; OnPropertyChanged("Value"); }
        }

        public static bool IsValidValue(string value) => Regex.IsMatch(value, "^" + PATTERN + "$", RegexOptions.Singleline);
    }

}
