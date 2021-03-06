/**
 * Autogenerated by Thrift Compiler (0.14.1)
 *
 * DO NOT EDIT UNLESS YOU ARE SURE THAT YOU KNOW WHAT YOU ARE DOING
 *  @generated
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Thrift;
using Thrift.Collections;


#pragma warning disable IDE0079  // remove unnecessary pragmas
#pragma warning disable IDE1006  // parts of the code use IDL spelling

namespace PElementServer.Thrift
{
  public static class PElementServiceExtensions
  {
    public static bool Equals(this List<double> instance, object that)
    {
      if (!(that is List<double> other)) return false;
      if (ReferenceEquals(instance, other)) return true;

      return TCollections.Equals(instance, other);
    }


    public static int GetHashCode(this List<double> instance)
    {
      return TCollections.GetHashCode(instance);
    }


    public static List<double> DeepCopy(this List<double> source)
    {
      if (source == null)
        return null;

      var tmp18 = new List<double>(source.Count);
      foreach (var elem in source)
        tmp18.Add(elem);
      return tmp18;
    }


    public static bool Equals(this List<global::PElementServer.Thrift.PElement> instance, object that)
    {
      if (!(that is List<global::PElementServer.Thrift.PElement> other)) return false;
      if (ReferenceEquals(instance, other)) return true;

      return TCollections.Equals(instance, other);
    }


    public static int GetHashCode(this List<global::PElementServer.Thrift.PElement> instance)
    {
      return TCollections.GetHashCode(instance);
    }


    public static List<global::PElementServer.Thrift.PElement> DeepCopy(this List<global::PElementServer.Thrift.PElement> source)
    {
      if (source == null)
        return null;

      var tmp19 = new List<global::PElementServer.Thrift.PElement>(source.Count);
      foreach (var elem in source)
        tmp19.Add((elem != null) ? elem.DeepCopy() : null);
      return tmp19;
    }


  }
}
