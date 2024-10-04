using System;

namespace DonMacaron.Exceptions;

public class DuplicateMacaronException(string publicUrl) : Exception($"A Macaron with the public URL '{publicUrl}' already exists.")
{
}