using System;
using System.Collections.Generic;

public class FacialFeatures
{
    public string EyeColor { get; }
    public decimal PhiltrumWidth { get; }

    public FacialFeatures(string eyeColor, decimal philtrumWidth)
    {
        EyeColor = eyeColor;
        PhiltrumWidth = philtrumWidth;
    }

    public override bool Equals(object? obj)
    {
        // obj is FacialFeatures other checks that obj is a FacialFeatures instance and then names it other.
        return obj is FacialFeatures other && EyeColor == other.EyeColor && PhiltrumWidth == other.PhiltrumWidth;
    }

  public override int GetHashCode()
  {
    return HashCode.Combine(EyeColor, PhiltrumWidth);
  }
}

public class Identity
{
    public string Email { get; }
    public FacialFeatures FacialFeatures { get; }

    public Identity(string email, FacialFeatures facialFeatures)
    {
        Email = email;
        FacialFeatures = facialFeatures;
    }

    public override bool Equals(object? obj)
    {
        return obj is Identity other && Email == other.Email && FacialFeatures.Equals(other.FacialFeatures);
    }
  public override int GetHashCode()
  {
    return HashCode.Combine(Email, FacialFeatures);
  }
}

public class Authenticator
{
    private readonly HashSet<Identity> registeredIds = new();
    public static bool AreSameFace(FacialFeatures faceA, FacialFeatures faceB)
    {
        return faceA.Equals(faceB);
    }

    public bool IsAdmin(Identity identity)
    {
        var admin = new Identity("admin@exerc.ism", new FacialFeatures("green", 0.9m));
        return admin.Equals(identity);
    }

    public bool Register(Identity identity)
    {

      return registeredIds.Add(identity);
    }

    public bool IsRegistered(Identity identity)
    {
        return registeredIds.Contains(identity);
    }

    public static bool AreSameObject(Identity identityA, Identity identityB)
    {
        return ReferenceEquals(identityA, identityB);
    }
}
