﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

#pragma warning disable SA1028 // ignore whitespace warnings for generated code
using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Cryptography.Asn1;

#nullable enable
namespace System.Security.Cryptography.Asn1
{
    [StructLayout(LayoutKind.Sequential)]
    internal partial struct ECDomainParameters
    {
        internal System.Security.Cryptography.Asn1.SpecifiedECDomain? Specified;
        internal Oid Named;

#if DEBUG
        static ECDomainParameters()
        {
            var usedTags = new System.Collections.Generic.Dictionary<Asn1Tag, string>();
            Action<Asn1Tag, string> ensureUniqueTag = (tag, fieldName) =>
            {
                if (usedTags.TryGetValue(tag, out string? existing))
                {
                    throw new InvalidOperationException($"Tag '{tag}' is in use by both '{existing}' and '{fieldName}'");
                }

                usedTags.Add(tag, fieldName);
            };

            ensureUniqueTag(Asn1Tag.Sequence, "Specified");
            ensureUniqueTag(Asn1Tag.ObjectIdentifier, "Named");
        }
#endif

        internal void Encode(AsnWriter writer)
        {
            bool wroteValue = false;

            if (Specified.HasValue)
            {
                if (wroteValue)
                    throw new CryptographicException();

                Specified.Value.Encode(writer);
                wroteValue = true;
            }

            if (Named != null)
            {
                if (wroteValue)
                    throw new CryptographicException();

                writer.WriteObjectIdentifier(Named);
                wroteValue = true;
            }

            if (!wroteValue)
            {
                throw new CryptographicException();
            }
        }

        internal static ECDomainParameters Decode(ReadOnlyMemory<byte> encoded, AsnEncodingRules ruleSet)
        {
            AsnValueReader reader = new AsnValueReader(encoded.Span, ruleSet);

            Decode(ref reader, encoded, out ECDomainParameters decoded);
            reader.ThrowIfNotEmpty();
            return decoded;
        }

        internal static void Decode(ref AsnValueReader reader, ReadOnlyMemory<byte> rebind, out ECDomainParameters decoded)
        {
            decoded = default;
            Asn1Tag tag = reader.PeekTag();

            if (tag.HasSameClassAndValue(Asn1Tag.Sequence))
            {
                System.Security.Cryptography.Asn1.SpecifiedECDomain tmpSpecified;
                System.Security.Cryptography.Asn1.SpecifiedECDomain.Decode(ref reader, rebind, out tmpSpecified);
                decoded.Specified = tmpSpecified;

            }
            else if (tag.HasSameClassAndValue(Asn1Tag.ObjectIdentifier))
            {
                decoded.Named = reader.ReadObjectIdentifier();
            }
            else
            {
                throw new CryptographicException();
            }
        }
    }
}
