// Copyright 2020 Siemens AG
// SPDX-License-Identifier: MIT

using System;

namespace opc.ua.pubsub.dotnet.binary
{
    public class EncodingOptions : IEquatable<EncodingOptions>
    {
        public bool LegacyFieldFlagEncoding { get; set; }
        public bool SendMetaMessageWithoutRetain { get; set; }

        public bool Equals( EncodingOptions other )
        {
            if ( ReferenceEquals( null, other ) )
            {
                return false;
            }
            if ( ReferenceEquals( this, other ) )
            {
                return true;
            }
            return 
                (LegacyFieldFlagEncoding == other.LegacyFieldFlagEncoding) && 
                (SendMetaMessageWithoutRetain == other.SendMetaMessageWithoutRetain);
        }

        public override bool Equals( object obj )
        {
            if ( ReferenceEquals( null, obj ) )
            {
                return false;
            }
            if ( ReferenceEquals( this, obj ) )
            {
                return true;
            }
            if ( obj.GetType() != GetType() )
            {
                return false;
            }
            return Equals( (EncodingOptions)obj );
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = LegacyFieldFlagEncoding.GetHashCode();
                hashCode = ( hashCode * 397 ) ^ ( SendMetaMessageWithoutRetain.GetHashCode() );
                return hashCode;
            }
        }

        public static bool operator ==( EncodingOptions left, EncodingOptions right )
        {
            return Equals( left, right );
        }

        public static bool operator !=( EncodingOptions left, EncodingOptions right )
        {
            return !Equals( left, right );
        }
    }
}