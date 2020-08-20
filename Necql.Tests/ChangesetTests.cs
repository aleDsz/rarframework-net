using System;
using System.Linq;

using Necql.Tests.Supports.Schemas;

using NUnit.Framework;

namespace Necql.Tests {
  public class ChangesetTests {
    /// <summary>
    /// 
    /// </summary>
    [Test]
    public void TestValidChangeset () {
      var user = new User ();
      var changeset = User.Validate (user, new { Name = "Alexandre", Age = 24 });

      Assert.IsTrue (changeset.IsValid);
    }

    /// <summary>
    /// 
    /// </summary>
    [Test]
    public void TestInvalidCastField () {
      var user = new User ();

      var exception = Assert.Throws<Exception> (() => {
        User.Validate (user, new { Name = "Alexandre", Age = "24" });
      });

      Assert.AreEqual ("Field Age is invalid", exception.Message);
    }

    /// <summary>
    /// 
    /// </summary>
    [Test]
    public void TestInvalidRequiredField () {
      var user = new User ();
      var changeset = User.Validate (user, new { Name = "Alexandre" });

      switch (changeset) {
        case Changeset { IsValid: false, Errors: var errors } when errors.Count == 1:
          var error = errors.First ();

          Assert.AreEqual ("Age", error["Field"]);
          Assert.AreEqual ("can't be blank", error["Detail"]);
          break;

        default:
          Assert.Fail ();
          break;
      };
    }
  }
}