using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Xpo;

namespace PersistentClassesLibrary {
    public class Person : XPObject {
        public Person(Session session) : base(session) { }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [PersistentAlias("FirstName + LastName")]
        public string FullName { get { return FirstName + " " + LastName; } }
        [Association]
        public XPCollection<Product> Products {
            get { return GetCollection<Product>("Products"); }
        }
    }
}
