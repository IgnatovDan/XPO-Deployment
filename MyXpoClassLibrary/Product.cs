using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Xpo;

namespace PersistentClassesLibrary {
    public class Product : XPObject {
        public Product(Session session) : base(session) { }
        public string Name { get; set; }
        [Association]
        public Person Manager { get; set; }
    }
}
